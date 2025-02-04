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
    public partial class UC_Addadvisor : UserControl
    {
        public UC_Addadvisor()
        {
            InitializeComponent();
        }

        private void btnadd_adv_Click(object sender, EventArgs e)
        {
            try
            {
                int id = GetPredefinedPersonId();
                var con = Configuration.getInstance().getConnection();
                int genderId = GetGenderIdFromLookup(comboBox1.Text, con);
                var con2 = Configuration.getInstance().getConnection();
                int designationText = GetDesigIdFromLookup(cmbdesig.Text, con2);

                using (SqlCommand cmd = new SqlCommand("Insert into Person values (@FirstName, @LastName, @Contact, @Email, @DateOfBirth, @Gender)", con))
                {
                    cmd.Parameters.AddWithValue("@FirstName", GetNullableParameter(txtfirstname.Text));
                    cmd.Parameters.AddWithValue("@LastName", GetNullableParameter(txtlastname.Text));
                    cmd.Parameters.AddWithValue("@Contact", GetNullableParameter(txtcontact.Text));
                    cmd.Parameters.AddWithValue("@Email", GetNullableParameter(txtemail.Text));
                    cmd.Parameters.AddWithValue("@DateOfBirth", GetNullableParameter(datetime_dobadvisor.Checked ? datetime_dobadvisor.Value.ToString() : null));
                    cmd.Parameters.AddWithValue("@Gender", genderId);
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd2 = new SqlCommand("Insert into Advisor values (@Id, @Designation, @Salary)", con2))
                {
                    cmd2.Parameters.AddWithValue("@Id", id);
                    cmd2.Parameters.AddWithValue("@Designation", designationText);
                    cmd2.Parameters.AddWithValue("@Salary", GetNullableDecimalParameter(txtsalary_adv.Text));
                    cmd2.ExecuteNonQuery();
                }

                MessageBox.Show("Successfully saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private object GetNullableParameter(string value)
        {
            return string.IsNullOrEmpty(value) ? DBNull.Value : (object)value;
        }
        private object GetNullableDecimalParameter(string value)
        {
            return string.IsNullOrEmpty(value) ? DBNull.Value : (object)decimal.Parse(value);
        }

        private int GetDesigIdFromLookup(string designationText, SqlConnection connection)
        {
            int designationId = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ID FROM Lookup WHERE Value = @Designation", connection))
                {
                    cmd.Parameters.AddWithValue("@Designation", designationText);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            designationId = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving designation ID: {ex.Message}");
            }

            return designationId;
        }

        private int GetGenderIdFromLookup(string genderText, SqlConnection connection)
        {
            int genderId = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ID FROM Lookup WHERE Value = @Gender", connection))
                {
                    cmd.Parameters.AddWithValue("@Gender", genderText);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            genderId = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving gender ID: {ex.Message}");
            }

            return genderId;
        }


        private int GetPredefinedPersonId()
        {
            var con = Configuration.getInstance().getConnection();

            var cmd = new SqlCommand("SELECT MAX(Id) FROM Person", con);
            {
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result) + 1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
