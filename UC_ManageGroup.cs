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
    public partial class UC_ManageGroup : UserControl
    {
        public UC_ManageGroup()
        {
            InitializeComponent();
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Group]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                // Get data from the selected row
                txtid.Text = row.Cells["Id"].Value.ToString();
                dtpcreate.Text = row.Cells["Created_On"].Value.ToString();
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE [Group] SET Created_On = @Created_On", con);
                cmd.Parameters.AddWithValue("@Created_On", dtpcreate.Value);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void removeDataFromTextBoxes()
        {
            txtid.Text = string.Empty;
            dtpcreate.Value = DateTime.Now;

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
                        // Delete from ProjectAdvisor table
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM GroupProject WHERE GroupId = @GroupId", con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@GroupId", txtid.Text);
                            cmd.ExecuteNonQuery();
                        }

                        // Delete from Project table
                        using (SqlCommand cmd3 = new SqlCommand("DELETE FROM GroupStudent WHERE GroupId = @GroupId", con, transaction))
                        {
                            cmd3.Parameters.AddWithValue("@GroupId", txtid.Text);
                            cmd3.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd4 = new SqlCommand("DELETE FROM GroupEvaluation WHERE GroupId = @GroupId", con, transaction))
                        {
                            cmd4.Parameters.AddWithValue("@GroupId", txtid.Text);
                            cmd4.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd2 = new SqlCommand("DELETE FROM [Group] WHERE Id = @Id", con, transaction))
                        {
                            cmd2.Parameters.AddWithValue("@Id", txtid.Text);
                            cmd2.ExecuteNonQuery();
                        }

                        removeDataFromTextBoxes();
                        transaction.Commit();
                        MessageBox.Show("Group and associated records removed successfully.");
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
