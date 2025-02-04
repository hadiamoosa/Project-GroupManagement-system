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
    public partial class UC_Addstudent : UserControl
    {
        public UC_Addstudent()
        {
            InitializeComponent();
        }

        private void UC_Addstudent_Load(object sender, EventArgs e)
        {
            BackColor = Color.AliceBlue;
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    int id = GetPredefinedPersonId();
        //    var con = Configuration.getInstance().getConnection();
        //    var con2 = Configuration.getInstance().getConnection();
        //    SqlCommand cmd = new SqlCommand("Insert into Person values ( @FirstName, @LastName, @Contact, @Email, @DateOfBirth, SET @Gender = CASE WHEN @Gender = 'Male' THEN 1 WHEN @Gender = 'Female' THEN 2)", con);
        //    SqlCommand cmd2 = new SqlCommand("Insert into Student values (@Id, @RegistrationNo)", con2);
        //    cmd.Parameters.AddWithValue("@FirstName", txtfirstname.Text);
        //    cmd.Parameters.AddWithValue("@LastName", txtlastname.Text);
        //    cmd.Parameters.AddWithValue("@Contact", txtcontact.Text);
        //    cmd.Parameters.AddWithValue("@Email", txtemail.Text);
        //    cmd.Parameters.AddWithValue("@DateOfBirth", datetime_dobstudent.Value);
        //    cmd.Parameters.AddWithValue("@Gender", txtgender.Text);
        //    cmd.ExecuteNonQuery();
        //    cmd2.Parameters.AddWithValue("@Id", id);
        //    cmd2.Parameters.AddWithValue("@RegistrationNo", txtregno.Text);
        //    cmd2.ExecuteNonQuery();
        //    MessageBox.Show("Successfully saved");
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = GetPredefinedPersonId();
                var con = Configuration.getInstance().getConnection();
                var con2 = Configuration.getInstance().getConnection();
                int genderId = GetGenderIdFromLookup(comboBox1.Text, con);

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Person VALUES (@FirstName, @LastName, @Contact, @Email, @DateOfBirth, @Gender)", con))
                {
                    cmd.Parameters.AddWithValue("@FirstName", txtfirstname.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtlastname.Text);

                    // Check for null or empty contact
                    if (string.IsNullOrEmpty(txtcontact.Text))
                    {
                        cmd.Parameters.AddWithValue("@Contact", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Contact", txtcontact.Text);
                    }

                    cmd.Parameters.AddWithValue("@Email", txtemail.Text);

                    // Check for null DateOfBirth
                    if (datetime_dobstudent.Value == null)
                    {
                        cmd.Parameters.AddWithValue("@DateOfBirth", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DateOfBirth", datetime_dobstudent.Value);
                    }

                    // Check for null Gender
                    if (genderId == 0)
                    {
                        cmd.Parameters.AddWithValue("@Gender", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Gender", genderId);
                    }

                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd2 = new SqlCommand("INSERT INTO Student VALUES (@Id, @RegistrationNo)", con2))
                {
                    cmd2.Parameters.AddWithValue("@Id", id);
                    cmd2.Parameters.AddWithValue("@RegistrationNo", txtregno.Text);
                    cmd2.ExecuteNonQuery();
                }

                MessageBox.Show("Successfully saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private int GetGenderIdFromLookup(string genderText, SqlConnection connection)
        {
            int genderId = 0;
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
