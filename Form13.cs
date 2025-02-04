using iTextSharp.text;
using iTextSharp.text.pdf;
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

namespace Mid_Project
{
    public partial class Form13 : Form
    {
        public Form13()
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
                    string query = "SELECT A.Id AS AdvisorId, A.Salary, CONCAT(P.FirstName, ' ', P.LastName) AS AdvisorName, L.Value AS Designation FROM Advisor AS A INNER JOIN Person AS P ON A.Id = P.Id INNER JOIN Lookup AS L ON A.Designation = L.Id;";

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

        private void button2_Click(object sender, EventArgs e)
        {
            Openingpage mainForm = new Openingpage();
            mainForm.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Create a new PDF document
            Document doc = new Document();

            try
            {
                // Path to save the PDF file in the "bin" directory
                string pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output4.pdf");

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
    }
}
