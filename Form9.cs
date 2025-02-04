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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        private void loadfroms(UserControl frm)
        {
            try
            {
                this.pictureBox1.Controls.Clear();
                UserControl f = frm as UserControl;
                f.Dock = DockStyle.Fill;
                this.pictureBox1.Controls.Add(f);
                this.pictureBox1.Tag = f;
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
            loadfroms(new UC_MarkEvaluation());
        }

        private void lblcrud_Click(object sender, EventArgs e)
        {
            loadfroms(new UC_ViewMarkedEvaluation());
        }
    }
}
