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
    public partial class UC_CreateGroup : UserControl
    {
        public UC_CreateGroup()
        {
            InitializeComponent();
        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO [Group] VALUES (@Created_on)", con);
            cmd.Parameters.AddWithValue("@Created_on", dateTimePicker1.Value);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");

        }
    }
}
