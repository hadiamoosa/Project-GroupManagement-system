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
    public partial class ViewProjectAssign : UserControl
    {
        public ViewProjectAssign()
        {
            InitializeComponent();
        }
      
        private void btnview_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT GS.ProjectId, GS.GroupId, GS.AssignmentDate FROM GroupProject GS", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void removeDataFromTextBoxes()
        {
            comboBox2.Text = string.Empty;
            comboBox1.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;

        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM GroupProject WHERE ProjectId = @ProjectId AND GroupId = @GroupId ", con);
                cmd.Parameters.AddWithValue("@ProjectId", comboBox1.Text);
                cmd.Parameters.AddWithValue("@GroupId", comboBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted successfully");
                removeDataFromTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                // Get data from the selected row
                comboBox1.Text = row.Cells["ProjectId"].Value.ToString();
                comboBox2.Text = row.Cells["GroupId"].Value.ToString();
                dateTimePicker1.Text = row.Cells["AssignmentDate"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT GS.GroupId, GS.ProjectId, G.Description, G.Title, GS.AssignmentDate FROM GroupProject GS JOIN Project G ON GS.ProjectId = G.Id;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                using (SqlCommand cmd = new SqlCommand("UPDATE GroupProject SET AssignmentDate = @AssignmentDate WHERE ProjectId = @ProjectId AND GroupId = @GroupId", con))
                {
                    cmd.Parameters.AddWithValue("@ProjectId", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@GroupId", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Value);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Assignmentdate updated to group successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Assignmentdate to group: " + ex.Message);
            }
        }
    }
}
