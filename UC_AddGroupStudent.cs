using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mid_Project
{
    public partial class UC_AddGroupStudent : UserControl
    {

        public UC_AddGroupStudent()
        {
            InitializeComponent();
            LoadStudentIds();
            LoadGroupIds();
        }


        private void LoadStudentIds()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                var con2 = Configuration.getInstance().getConnection();
                using (SqlCommand command = new SqlCommand("SELECT Id FROM Student", con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        comboBox1.Items.Clear();
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["Id"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading StudentIds: " + ex.Message);
            }
        }
        private void LoadGroupIds()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                using (SqlCommand command = new SqlCommand("SELECT Id FROM [Group]", con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        comboBox2.Items.Clear();
                        while (reader.Read())
                        {
                            comboBox2.Items.Add(reader["Id"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading StudentIds: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedStudentId = comboBox1.SelectedItem?.ToString();
            string selectedGroupId = comboBox2.SelectedItem?.ToString();

            // Check if both StudentId and GroupId are selected
            if (!string.IsNullOrEmpty(selectedStudentId) && !string.IsNullOrEmpty(selectedGroupId))
            {
                // Check if the student is not already in a group
                if (!IsStudentInGroup(selectedStudentId))
                {
                    // Check if the count for the selected GroupId is less than three
                    if (CountStudentsInGroup(selectedGroupId) < 3)
                    {
                        try
                        {
                            var con = Configuration.getInstance().getConnection();
                            int statusId = GetStatusIdFromLookup(comboBox3.Text, con);

                            using (SqlCommand cmd = new SqlCommand("INSERT INTO GroupStudent VALUES (@GroupId, @StudentId, @Status, @AssignmentDate)", con))
                            {
                                cmd.Parameters.AddWithValue("@GroupId", selectedGroupId);
                                cmd.Parameters.AddWithValue("@StudentId", selectedStudentId);
                                cmd.Parameters.AddWithValue("@Status", statusId);
                                cmd.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Value);
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Student added to group successfully.");
                        }
                        catch
                        {
                            MessageBox.Show("Error adding student to group.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Group is already full (maximum 3 students).");
                    }
                }
                else
                {
                    MessageBox.Show("Selected student is already in a group.");
                }
            }
            else
            {
                MessageBox.Show("Please select both StudentId and GroupId.");
            }
        }

        private bool IsStudentInGroup(string studentId)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                // Check if the student is already in any group
                string query = $"SELECT COUNT(*) FROM GroupStudent WHERE StudentId = '{studentId}'";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking if student is in a group: " + ex.Message);
                return false;
            }
        }

        private int CountStudentsInGroup(string groupId)
        {
            int count = 0;

            try
            {
                var con = Configuration.getInstance().getConnection();

                // Count the number of students for the selected GroupId in the GroupStudent table 
                string query = $"SELECT COUNT(*) FROM GroupStudent WHERE GroupId = '{groupId}'";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    count = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error counting students in group: " + ex.Message);
            }

            return count;
        }

        private int GetStatusIdFromLookup(string statusText, SqlConnection connection)
        {
            int statusId = 0;
            // Query the GenderLookup table to get the corresponding ID
            using (SqlCommand cmd = new SqlCommand("SELECT ID FROM Lookup WHERE Value = @Status", connection))
            {
                cmd.Parameters.AddWithValue("@Status", statusText);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        statusId = reader.GetInt32(0);
                    }
                }
            }

            return statusId;
        }
    }
}
