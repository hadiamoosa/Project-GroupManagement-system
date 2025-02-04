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
    public partial class UC_ViewAdvisors : UserControl
    {
        public UC_ViewAdvisors()
        {
            InitializeComponent();
        }

        private void btnadd_adv_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT  a.Id, p.FirstName, p.LastName, p.Contact, p.Email, p.DateOfBirth, l.Value AS Gender, lg.Value AS Designation, a.Salary FROM Advisor a INNER JOIN Person p ON a.Id = p.Id INNER JOIN Lookup l ON p.Gender = l.Id INNER JOIN Lookup lg ON a.Designation = lg.Id  ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                int genderId = GetGenderIdFromLookup(comboBox1.Text, con);

                var con2 = Configuration.getInstance().getConnection();
                int designationId = GetDesigIdFromLookup(comboBox2.Text, con2);

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE Person SET FirstName = @FirstName, LastName = @LastName, Contact = @Contact, Email = @Email, DateOfBirth = @DateOfBirth, Gender = @Gender WHERE Id = @Id", con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@FirstName", GetNullableParameter(txtfirstname.Text));
                            cmd.Parameters.AddWithValue("@LastName", GetNullableParameter(txtlastname.Text));
                            cmd.Parameters.AddWithValue("@Contact", GetNullableParameter(txtcontact.Text));
                            cmd.Parameters.AddWithValue("@Email", GetNullableParameter(txtemail.Text));
                            cmd.Parameters.AddWithValue("@DateOfBirth", GetNullableParameter(datetime_dobadvisor.Checked ? datetime_dobadvisor.Value.ToString() : null));
                            cmd.Parameters.AddWithValue("@Gender", genderId);
                            cmd.Parameters.AddWithValue("@Id", txtid.Text);
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd2 = new SqlCommand("UPDATE Advisor SET Designation = @Designation, Salary = @Salary WHERE Id = @Id", con2, transaction))
                        {
                            cmd2.Parameters.AddWithValue("@Designation", designationId);
                            cmd2.Parameters.AddWithValue("@Salary", GetNullableDecimalParameter(txtsalary.Text));
                            cmd2.Parameters.AddWithValue("@Id", txtid.Text);
                            cmd2.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Successfully updated");
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
        private void removeDataFromTextBoxes()
        {
            txtid.Text = string.Empty;
            txtfirstname.Text = string.Empty;
            txtlastname.Text = string.Empty;
            txtcontact.Text = string.Empty;
            txtemail.Text = string.Empty;
            datetime_dobadvisor.Value = DateTime.Now;
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            txtsalary.Text = string.Empty;

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
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM ProjectAdvisor WHERE AdvisorId = @AdvisorId", con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@AdvisorId", txtid.Text);
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd2 = new SqlCommand("DELETE FROM Advisor WHERE Id = @Id", con, transaction))
                        {
                            cmd2.Parameters.AddWithValue("@Id", txtid.Text);
                            cmd2.ExecuteNonQuery();
                        }
                        removeDataFromTextBoxes();
                        transaction.Commit();
                        MessageBox.Show("Advisor and associated records removed successfully.");
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                // Get data from the selected row
                txtid.Text = row.Cells["Id"].Value.ToString();
                txtfirstname.Text = row.Cells["FirstName"].Value.ToString();
                txtlastname.Text = row.Cells["LastName"].Value.ToString();
                txtcontact.Text = row.Cells["Contact"].Value.ToString();
                txtemail.Text = row.Cells["Email"].Value.ToString();
                datetime_dobadvisor.Text = row.Cells["DateOfBirth"].Value.ToString();
                comboBox1.Text = row.Cells["Gender"].Value.ToString();
                comboBox2.Text = row.Cells["Designation"].Value.ToString();
                txtsalary.Text = row.Cells["Salary"].Value.ToString();
            }
        }
    }
}

