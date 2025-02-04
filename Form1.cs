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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lblexitstu_Click(object sender, EventArgs e)
        {
            Openingpage mainForm = new Openingpage();
            mainForm.Show();
            this.Hide();
        }
        private void loadfroms(UserControl frm)
        {
            try
            {

                this.picboxchange.Controls.Clear();
                UserControl f = frm as UserControl;
                f.Dock = DockStyle.Fill;
                this.picboxchange.Controls.Add(f);
                this.picboxchange.Tag = f;
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void lbladdstudent_Click(object sender, EventArgs e)
        {
            loadfroms(new UC_Addstudent());
        }

        private void lblviewstudent_Click(object sender, EventArgs e)
        {
            loadfroms(new UC_ViewStudents());
        }
    }
}
