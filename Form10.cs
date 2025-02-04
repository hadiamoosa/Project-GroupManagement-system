using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Mid_Project
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();
        }
        private void LoadDataIntoDataGridView()
        {
            String ConnectionStr = @"Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStr))
                {
                    connection.Open();
                    string query = "SELECT P.Id AS ProjectId, P.Title, A.Id AS AdvisorId, LAdvisor.Value AS AdvisorDesignation, CONCAT(Pe.FirstName, ' ', Pe.LastName) AS AdvisorName, PA.AdvisorRole, LRole.Value AS AdvisorRoleValue, S.Id AS StudentId FROM Project AS P INNER JOIN ProjectAdvisor AS PA ON P.Id = PA.ProjectId INNER JOIN Advisor AS A ON PA.AdvisorId = A.Id INNER JOIN Person AS Pe ON A.Id = Pe.Id LEFT JOIN GroupStudent AS GS ON P.Id = GS.GroupId LEFT JOIN Student AS S ON GS.StudentId = S.Id LEFT JOIN Person AS PeS ON S.Id = PeS.Id LEFT JOIN Lookup AS LAdvisor ON A.Designation = LAdvisor.Id LEFT JOIN Lookup AS LRole ON PA.AdvisorRole = LRole.Id;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Create a new PDF document
            Document doc = new Document();

            try
            {
                // Path to save the PDF file in the "bin" directory
                string pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.pdf");

                // Create a PdfWriter instance
                PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));

                // Open the document for writing
                doc.Open();

                // Create a PdfPTable with columns equal to the number of columns in the DataGridView
                PdfPTable table = new PdfPTable(dataGridView1.ColumnCount);

                // Add DataGridView header row data to PdfPTable
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    table.AddCell(new Phrase(dataGridView1.Columns[i].HeaderText));
                }

                // Add DataGridView data to PdfPTable
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            table.AddCell(new Phrase(dataGridView1.Rows[i].Cells[j].Value.ToString()));
                        }
                    }
                }

                // Add PdfPTable to the document
                doc.Add(table);

                // Close the document
                doc.Close();

                MessageBox.Show("PDF generated successfully and saved in bin directory.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating PDF: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Openingpage mainForm = new Openingpage();
            mainForm.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    

