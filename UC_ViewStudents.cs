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
    public partial class UC_ViewStudents : UserControl
    {
        public UC_ViewStudents()
        {
            InitializeComponent();
        }

        private void datagrid_students_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < datagrid_students.Rows.Count)
            {
                DataGridViewRow row = this.datagrid_students.Rows[e.RowIndex];
                // Get data from the selected row
                txtid.Text = row.Cells["Id"].Value.ToString();
                txtfirstname.Text = row.Cells["FirstName"].Value.ToString();
                txtlastname.Text = row.Cells["LastName"].Value.ToString();
                txtcontact.Text = row.Cells["Contact"].Value.ToString();
                txtemail.Text = row.Cells["Email"].Value.ToString();
                datetime_dobstudent.Text = row.Cells["DateOfBirth"].Value.ToString();
                comboBox1.Text = row.Cells["Gender"].Value.ToString();
                txtreg.Text = row.Cells["RegistrationNo"].Value.ToString();
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT s.*, p.FirstName, p.LastName, p.Contact, p.Email, p.DateOfBirth, l.Value AS Gender FROM Student s INNER JOIN Person p ON s.Id = p.Id LEFT JOIN Lookup l ON p.Gender = l.Id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    if (row.IsNull(col))
                    {
                        row[col.ColumnName] = DBNull.Value;
                    }
                }
            }

            datagrid_students.DataSource = dt;
        }
        
        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                var con2 = Configuration.getInstance().getConnection();
                int genderId = GetGenderIdFromLookup(comboBox1.Text, con);

                using (SqlCommand cmd = new SqlCommand("UPDATE Person SET FirstName = @FirstName, LastName = @LastName, Contact = @Contact, Email = @Email, DateOfBirth = @DateOfBirth, Gender = @Gender WHERE Id = @Id", con))
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

                    cmd.Parameters.AddWithValue("@Id", txtid.Text);
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd2 = new SqlCommand("UPDATE Student SET RegistrationNo = @RegistrationNo WHERE Id = @Id", con2))
                {
                    cmd2.Parameters.AddWithValue("@RegistrationNo", txtreg.Text);
                    cmd2.Parameters.AddWithValue("@Id", txtid.Text);
                    cmd2.ExecuteNonQuery();
                }

                MessageBox.Show("Successfully updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private int GetGenderIdFromLookup(string genderText, SqlConnection connection)
        {
            int genderId = 0;
            // Query the GenderLookup table to get the corresponding ID
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
        private void removeDataFromTextBoxes()
        {
            txtid.Text = string.Empty;
            txtfirstname.Text = string.Empty;
            txtlastname.Text = string.Empty;
            txtcontact.Text = string.Empty;
            txtemail.Text = string.Empty;
            datetime_dobstudent.Value = DateTime.Now;
            comboBox1.Text = string.Empty;
            txtreg.Text = string.Empty;

        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM GroupStudent WHERE StudentId = @StudentId", con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@StudentId", txtid.Text);
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd2 = new SqlCommand("DELETE FROM Student WHERE Id = @Id", con, transaction))
                        {
                            cmd2.Parameters.AddWithValue("@Id", txtid.Text);
                            cmd2.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show("Student and associated records removed successfully.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }  
            
        }

    }
}

