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
    public partial class UC_MarkEvaluation : UserControl
    {
        public UC_MarkEvaluation()
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

        private void btnmark_Click(object sender, EventArgs e)
        {
            string selectedGroupId = cmbgroup.SelectedItem?.ToString();
            string selectedEvaluationId = cmbevaluate.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedGroupId) && !string.IsNullOrEmpty(selectedEvaluationId))
            {
                try
                {
                    var con = Configuration.getInstance().getConnection();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO GroupEvaluation (GroupId, EvaluationId, ObtainedMarks, EvaluationDate) VALUES (@GroupId, @EvaluationId, @ObtainedMarks, @EvaluationDate)", con))
                    {
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

                        cmd.Parameters.AddWithValue("@GroupId", selectedGroupId);
                        cmd.Parameters.AddWithValue("@EvaluationId", selectedEvaluationId);
                        cmd.Parameters.AddWithValue("@ObtainedMarks", obtainedMarks); // Use the obtainedMarks variable here
                        cmd.Parameters.AddWithValue("@EvaluationDate", dateTimePicker1.Value);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("GroupEvaluation record added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding GroupEvaluation record: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Group, Evaluation, Obtained Marks, and Evaluation Date cannot be null.");
            }

        }
        public int GetTotalMarks()
        {
            int totalMarks = 0;
            string selectedEvaluationId = cmbevaluate.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedEvaluationId))
            {
                MessageBox.Show("No evaluation selected.");
                return totalMarks;
            }

            try
            {
                var con = Configuration.getInstance().getConnection();
                using (SqlCommand cmd = new SqlCommand("SELECT TotalMarks FROM Evaluation WHERE Id = @EvaluationId", con))
                {
                    cmd.Parameters.AddWithValue("@EvaluationId", selectedEvaluationId);
                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out totalMarks))
                    {
                        // Total marks retrieved successfully
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

