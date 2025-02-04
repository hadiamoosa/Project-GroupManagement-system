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
    public partial class UC_ViewProject : UserControl
    {
        public UC_ViewProject()
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
                txtdescription.Text = row.Cells["Description"].Value.ToString();
                txttitle.Text = row.Cells["Title"].Value.ToString();
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  p.* FROM Project p", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void removeDataFromTextBoxes()
        {
            txtid.Text = string.Empty;
            txtdescription.Text = string.Empty;
            txttitle.Text = string.Empty;

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Project SET Description = @Description, Title = @Title WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", txtid.Text);
                if (string.IsNullOrEmpty(txtdescription.Text))
                {
                    cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Description", txtdescription.Text);
                }

                cmd.Parameters.AddWithValue("@Title", txttitle.Text);
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
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM GroupProject WHERE ProjectId = @ProjectId", con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ProjectId", txtid.Text);
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd3 = new SqlCommand("DELETE FROM ProjectAdvisor WHERE ProjectId = @ProjectId", con, transaction))
                        {
                            cmd3.Parameters.AddWithValue("@ProjectId", txtid.Text);
                            cmd3.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd2 = new SqlCommand("DELETE FROM Project WHERE Id = @Id", con, transaction))
                        {
                            cmd2.Parameters.AddWithValue("@Id", txtid.Text);
                            cmd2.ExecuteNonQuery();
                        }
                        removeDataFromTextBoxes();
                        transaction.Commit();
                        MessageBox.Show("Project and associated records removed successfully.");
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
