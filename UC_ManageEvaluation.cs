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
    public partial class UC_ManageEvaluation : UserControl
    {
        public UC_ManageEvaluation()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                // Get data from the selected row
                txtid.Text = row.Cells["Id"].Value.ToString();
                txtname.Text = row.Cells["Name"].Value.ToString();
                txttotal.Text = row.Cells["TotalMarks"].Value.ToString();
                txttotalweight.Text = row.Cells["TotalWeightage"].Value.ToString();
            }
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Evaluation", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Evaluation SET Name = @Name, TotalMarks = @TotalMarks,TotalWeightage= @TotalWeightage  WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@TotalMarks", txttotal.Text);
                cmd.Parameters.AddWithValue("@TotalWeightage", txttotalweight.Text);
                cmd.Parameters.AddWithValue("@Id", txtid.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Evaluation WHERE Id = @Id", con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Id", txtid.Text);
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd2 = new SqlCommand("DELETE FROM GroupEvaluation WHERE EvaluationId = @EvaluationId", con, transaction))
                        {
                            cmd2.Parameters.AddWithValue("@EvaluationId", txtid.Text);
                            cmd2.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show("Evaluation and associated records removed successfully.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

    }
}

