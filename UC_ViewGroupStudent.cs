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
    public partial class UC_ViewGroupStudent : UserControl
    {
        public UC_ViewGroupStudent()
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
                using (SqlCommand command = new SqlCommand("SELECT Id FROM [Group]", con2))
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                // Get data from the selected row
                comboBox2.Text = row.Cells["GroupId"].Value.ToString();
                comboBox1.Text = row.Cells["StudentId"].Value.ToString();
                comboBox3.Text = row.Cells["Status"].Value.ToString();
                dateTimePicker1.Text = row.Cells["AssignmentDate"].Value.ToString();
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT GS.GroupId, GS.StudentId, L.Value AS Status, GS.AssignmentDate FROM GroupStudent GS JOIN Lookup L ON GS.Status = L.Id; ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void removeDataFromTextBoxes()
        {
            comboBox2.Text = string.Empty;
            comboBox1.Text = string.Empty;
            comboBox3.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM GroupStudent WHERE GroupId = @GroupId AND StudentId = @StudentId", con);
                cmd.Parameters.AddWithValue("@GroupId", comboBox2.Text);
                cmd.Parameters.AddWithValue("@StudentId", comboBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Group deleted successfully");
                removeDataFromTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string selectedStudentId = comboBox1.SelectedItem?.ToString();
            string selectedGroupId = comboBox2.SelectedItem?.ToString();

            // Check if both StudentId and GroupId are selected
            if (!string.IsNullOrEmpty(selectedStudentId) && !string.IsNullOrEmpty(selectedGroupId))
            {
                // Check if the student is not already in a group
                if (!IsStudentInGroup(selectedStudentId))
                {
                    if (CountStudentsInGroup(selectedGroupId) < 3)
                    {
                        try
                        {
                            var con = Configuration.getInstance().getConnection();
                            int statusId = GetStatusIdFromLookup(comboBox3.Text, con);

                            using (SqlCommand cmd = new SqlCommand("UPDATE GroupStudent SET Status = @Status, AssignmentDate = @AssignmentDate WHERE StudentId = @StudentId AND GroupId = @GroupId", con))
                            {
                                cmd.Parameters.AddWithValue("@GroupId", selectedGroupId);
                                cmd.Parameters.AddWithValue("@StudentId", selectedStudentId);
                                cmd.Parameters.AddWithValue("@Status", statusId);
                                cmd.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Value);
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Student added to group successfully.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating student to group: " + ex.Message);
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
