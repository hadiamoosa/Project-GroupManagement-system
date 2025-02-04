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
    public partial class UC_ProjectAssign : UserControl
    {
        public UC_ProjectAssign()
        {
            InitializeComponent();
            LoadProjectIds();
            LoadGroupIds();
        }

        private void LoadProjectIds()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                using (SqlCommand command = new SqlCommand("SELECT Id FROM Project", con))
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
            string selectedProjectId = comboBox1.SelectedItem?.ToString();
            string selectedGroupId = comboBox2.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedProjectId) && !string.IsNullOrEmpty(selectedGroupId))
            {
                if (!IsProjectAssigned(selectedProjectId))
                {
                    try
                    {
                        var con = Configuration.getInstance().getConnection();
                        if (!IsGroupAssigned(selectedGroupId))
                        {
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO GroupProject VALUES (@ProjectId, @GroupId, @AssignmentDate)", con))
                            {
                                cmd.Parameters.AddWithValue("@ProjectId", selectedProjectId);
                                cmd.Parameters.AddWithValue("@GroupId", selectedGroupId);
                                cmd.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Value);
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Project assigned to group successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Selected group is already assigned to a project.");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error assigning Project to group.");
                    }
                }
                else
                {
                    MessageBox.Show("Selected project is already assigned to a group.");
                }
            }
            else
            {
                MessageBox.Show("Please select both ProjectId and GroupId.");
            }
        }
        private bool IsProjectAssigned(string projectId)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM GroupProject WHERE ProjectId = @ProjectId", con))
                {
                    cmd.Parameters.AddWithValue("@ProjectId", projectId);
                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool IsGroupAssigned(string groupId)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = "SELECT COUNT(*) FROM GroupProject WHERE GroupId = @GroupId";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@GroupId", groupId);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking if group has already assigned with project: " + ex.Message);
                return false;
            }
        }


    }

}
