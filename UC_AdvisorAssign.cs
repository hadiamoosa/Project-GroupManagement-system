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
    public partial class UC_AdvisorAssign : UserControl
    {
        public UC_AdvisorAssign()
        {
            InitializeComponent();
            LoadAdvisorIds();
            LoadProjectIds();
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
        private void LoadAdvisorIds()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                using (SqlCommand command = new SqlCommand("SELECT Id FROM Advisor", con))
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                int advisorRoleId = GetLookupIdFromValue(comboBox3.Text, con);
                if (!IsAdvisorAlreadyInGroup(comboBox1.Text, con))
                {
                    if (!IsAdvisorRoleAlreadyAssignedToGroup(comboBox1.Text, comboBox2.Text, advisorRoleId, con))
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO ProjectAdvisor (AdvisorId, ProjectId, AdvisorRole, AssignmentDate) VALUES (@AdvisorId, @ProjectId, @AdvisorRole, @AssignmentDate)", con))
                        {
                            cmd.Parameters.AddWithValue("@ProjectId", comboBox2.Text);
                            cmd.Parameters.AddWithValue("@AdvisorId", comboBox1.Text);
                            cmd.Parameters.AddWithValue("@AdvisorRole", advisorRoleId);
                            cmd.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Value);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Advisor assigned to group successfully.");
                    }
                    else
                    {
                        MessageBox.Show("The selected advisor role is already assigned to the same group.");
                    }
                }
                else
                {
                    MessageBox.Show("Selected advisor is already assigned to a group.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private bool IsAdvisorRoleAlreadyAssignedToGroup(string advisorId, string projectId, int advisorRoleId, SqlConnection connection)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM ProjectAdvisor WHERE AdvisorRole = @AdvisorRole", connection))
                {
                    command.Parameters.AddWithValue("@AdvisorId", advisorId);
                    command.Parameters.AddWithValue("@ProjectId", projectId);
                    command.Parameters.AddWithValue("@AdvisorRole", advisorRoleId);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking if advisor role is already assigned to the group: " + ex.Message);
                return false;
            }
        }

        private bool IsAdvisorAlreadyInGroup(string advisorId, SqlConnection connection)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM ProjectAdvisor WHERE AdvisorId = @AdvisorId", connection))
                {
                    command.Parameters.AddWithValue("@AdvisorId", advisorId);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking if advisor is in a group: " + ex.Message);
                return false;
            }
        }
        private int GetLookupIdFromValue(string value, SqlConnection connection)
        {
            int lookupId = 0;

            using (SqlCommand cmd = new SqlCommand("SELECT Id FROM Lookup WHERE Value = @Value", connection))
            {
                cmd.Parameters.AddWithValue("@Value", value);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lookupId = reader.GetInt32(0);
                    }
                }
            }

            return lookupId;
        
    }

    }
}
