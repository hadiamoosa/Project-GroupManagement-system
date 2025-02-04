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
    public partial class UC_ViewMarkedEvaluation : UserControl
    {
        public UC_ViewMarkedEvaluation()
        {
            InitializeComponent();
            LoadGroupIds();
            LoadEvaluationIds();
        }
        private void LoadEvaluationIds()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                using (SqlCommand command = new SqlCommand("SELECT Id FROM Evaluation", con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        cmbevaluate.Items.Clear();
                        while (reader.Read())
                        {
                            cmbevaluate.Items.Add(reader["Id"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading EvaluationIds: " + ex.Message);
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
                        cmbgroup.Items.Clear();
                        while (reader.Read())
                        {
                            cmbgroup.Items.Add(reader["Id"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading GroupIds: " + ex.Message);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                // Get data from the selected row
                cmbgroup.Text = row.Cells["GroupId"].Value.ToString();
                cmbevaluate.Text = row.Cells["EvaluationId"].Value.ToString();
                txtobtain.Text = row.Cells["ObtainedMarks"].Value.ToString();
                dateTimePicker1.Text = row.Cells["EvaluationDate"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM GroupEvaluation ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void removeDataFromTextBoxes()
        {
            cmbgroup.Text = string.Empty;
            cmbevaluate.Text = string.Empty;
            txtobtain.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM GroupEvaluation WHERE GroupId = @GroupId AND EvaluationId = @EvaluationId", con);
                cmd.Parameters.AddWithValue("@GroupId", cmbgroup.Text);
                cmd.Parameters.AddWithValue("@EvaluationId", cmbevaluate.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted successfully");
                removeDataFromTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnmark_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                int totalMarks = GetTotalMarks();

                int obtainedMarks;
                if (!int.TryParse(txtobtain.Text, out obtainedMarks))
                {
                    MessageBox.Show("Please enter a valid number for Obtained Marks.");
                    return;
                }

                if (obtainedMarks < 0)
                {
                    MessageBox.Show("Please enter a non-negative number for Obtained Marks.");
                    return;
                }

                if (obtainedMarks > totalMarks)
                {
                    MessageBox.Show("Obtained Marks cannot be greater than Total Marks.");
                    return;
                }

                SqlCommand cmd = new SqlCommand("UPDATE GroupEvaluation SET ObtainedMarks = @ObtainedMarks, EvaluationDate = @EvaluationDate WHERE GroupId = @GroupId AND EvaluationId = @EvaluationId", con);
                cmd.Parameters.AddWithValue("@ObtainedMarks", obtainedMarks);
                cmd.Parameters.AddWithValue("@GroupId", cmbgroup.Text);
                cmd.Parameters.AddWithValue("@EvaluationId", cmbevaluate.Text);
                cmd.Parameters.AddWithValue("@EvaluationDate", dateTimePicker1.Value);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private int GetTotalMarks()
        {
            int totalMarks = 0;
            try
            {
                var con = Configuration.getInstance().getConnection();
                using (SqlCommand cmd = new SqlCommand("SELECT TotalMarks FROM Evaluation WHERE Id = @EvaluationId", con))
                {
                    cmd.Parameters.AddWithValue("@EvaluationId", cmbevaluate.Text);
                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out totalMarks))
                    {
                    }
                    else
                    {
                        totalMarks = 0;
                        MessageBox.Show("Total marks could not be retrieved for the specified evaluation.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving total marks: " + ex.Message);
            }
            return totalMarks;
        }

    }
}
