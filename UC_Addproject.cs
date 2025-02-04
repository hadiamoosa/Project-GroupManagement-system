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
    public partial class UC_Addproject : UserControl
    {
        public UC_Addproject()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Project (Description, Title) VALUES (@Description, @Title)", con))
                {
                    if (string.IsNullOrEmpty(txtdesc.Text))
                    {
                        cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Description", txtdesc.Text);
                    }

                    cmd.Parameters.AddWithValue("@Title", txttitle.Text);

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Successfully saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
