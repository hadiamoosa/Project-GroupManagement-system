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
    public partial class UC_ViewAdvisorAssign : UserControl
    {
        public UC_ViewAdvisorAssign()
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                // Get data from the selected row
                comboBox1.Text = row.Cells["AdvisorId"].Value.ToString();
                comboBox2.Text = row.Cells["ProjectId"].Value.ToString();
                comboBox3.Text = row.Cells["AdvisorRole"].Value.ToString();
                dateTimePicker1.Text = row.Cells["AssignmentDate"].Value.ToString();
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT GS.AdvisorId, GS.ProjectId,l.Value AS AdvisorRole, GS.AssignmentDate FROM ProjectAdvisor GS INNER JOIN Lookup l ON GS.AdvisorRole = l.Id", con);
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
        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                int newAdvisorRoleId = GetLookupIdFromValue(comboBox3.Text, con);

                if (IsAdvisorInGroup(comboBox1.Text, comboBox2.Text, con))
                {
                    // Check if the updated role is already assigned to another advisor in the same group
                    if (!IsAdvisorRoleAlreadyAssignedToGroup(comboBox1.Text, comboBox2.Text, newAdvisorRoleId, con))
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE ProjectAdvisor SET AdvisorRole = @AdvisorRole WHERE AdvisorId = @AdvisorId AND ProjectId = @ProjectId", con))
                        {
                            cmd.Parameters.AddWithValue("@ProjectId", comboBox2.Text);
                            cmd.Parameters.AddWithValue("@AdvisorId", comboBox1.Text);
                            cmd.Parameters.AddWithValue("@AdvisorRole", newAdvisorRoleId);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Advisor role updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("The selected advisor role is already assigned to another advisor in the same group.");
                    }
                }
                else
                {
                    MessageBox.Show("Selected advisor is not assigned to the specified group.");
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

        private bool IsAdvisorInGroup(string advisorId, string projectId, SqlConnection connection)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM ProjectAdvisor WHERE AdvisorId = @AdvisorId AND ProjectId = @ProjectId", connection))
                {
                    command.Parameters.AddWithValue("@AdvisorId", advisorId);
                    command.Parameters.AddWithValue("@ProjectId", projectId);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking if advisor is in the group: " + ex.Message);
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM ProjectAdvisor WHERE AdvisorId = @AdvisorId AND ProjectId = @ProjectId ", con);
                cmd.Parameters.AddWithValue("@AdvisorId", comboBox1.Text);
                cmd.Parameters.AddWithValue("@ProjectId", comboBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted successfully");
                removeDataFromTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }
    }
}
