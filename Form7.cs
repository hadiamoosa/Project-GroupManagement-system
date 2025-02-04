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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        private void loadfroms(UserControl frm)
        {
            try
            {
                this.pictureBox2.Controls.Clear();
                UserControl f = frm as UserControl;
                f.Dock = DockStyle.Fill;
                this.pictureBox2.Controls.Add(f);
                this.pictureBox2.Tag = f;
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void lblexit_Click(object sender, EventArgs e)
        {
            Openingpage mainForm = new Openingpage();
            mainForm.Show();
            this.Hide();
        }

        private void lblcreategrp_Click(object sender, EventArgs e)
        {
            loadfroms(new UC_AdvisorAssign());
        }

        private void lblcrud_Click(object sender, EventArgs e)
        {
            loadfroms(new UC_ViewAdvisorAssign());
        }
    }
}
