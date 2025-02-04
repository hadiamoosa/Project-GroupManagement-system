using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mid_Project
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void lblexit_Click(object sender, EventArgs e)
        {
            Openingpage mainForm = new Openingpage();
            mainForm.Show();
            this.Hide();
        }
        private void loadfroms(UserControl frm)
        {
            try
            {
                this.pbproj.Controls.Clear();
                UserControl f = frm as UserControl;
                f.Dock = DockStyle.Fill;
                this.pbproj.Controls.Add(f);
                this.pbproj.Tag = f;
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lbladdproj_Click(object sender, EventArgs e)
        {
            loadfroms(new UC_Addproject());
        }

        private void lblviewproj_Click(object sender, EventArgs e)
        {
            loadfroms(new UC_ViewProject());
        }
    }
}
