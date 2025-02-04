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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Openingpage mainForm = new Openingpage();
            mainForm.Show();
            this.Hide();
        }
        private void loadfroms(UserControl frm)
        {
            try
            {
                this.picboxadvisor.Controls.Clear();
                UserControl f = frm as UserControl;
                f.Dock = DockStyle.Fill;
                this.picboxadvisor.Controls.Add(f);
                this.picboxadvisor.Tag = f;
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lbladdadv_Click(object sender, EventArgs e)
        {
            loadfroms(new UC_Addadvisor());
        }

        private void lblviewadv_Click(object sender, EventArgs e)
        {
            loadfroms(new UC_ViewAdvisors());
        }
    }
}
