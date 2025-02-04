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
    public partial class UC_Evaluation : UserControl
    {
        public UC_Evaluation()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtname.Text) && !string.IsNullOrEmpty(txttotal.Text) && !string.IsNullOrEmpty(txttotalw.Text))
            {
                // Check if the name is not already in use
                if (!IsNameInUse(txtname.Text))
                {
                    // Attempt to parse TotalMarks and TotalWeightage
                    if (int.TryParse(txttotal.Text, out int totalMarks) && int.TryParse(txttotalw.Text, out int totalWeightage))
                    {
                        try
                        {
                            var con = Configuration.getInstance().getConnection();

                            using (SqlCommand cmd = new SqlCommand("INSERT INTO Evaluation (Name, TotalMarks, TotalWeightage) VALUES (@Name, @TotalMarks, @TotalWeightage)", con))
                            {
                                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                                cmd.Parameters.AddWithValue("@TotalMarks", totalMarks);
                                cmd.Parameters.AddWithValue("@TotalWeightage", totalWeightage);
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Evaluation added successfully.");
                        }
                        catch
                        {
                            MessageBox.Show("Error adding evaluation.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid numeric values for TotalMarks and TotalWeightage.");
                    }
                }
                else
                {
                    MessageBox.Show("Evaluation with the entered name already exists.");
                }
            }
            else
            {
                MessageBox.Show("Please enter all required fields.");
            }
        }
        private bool IsNameInUse(string name)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Evaluation WHERE Name = @Name", con))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking if name is in use: " + ex.Message);
                return false;
            }
        }

    }
}
