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

namespace BanVay
{
    public partial class Invoices_Detail : Form
    {
        SqlConnection conn;
        public Invoices_Detail()
        {
            InitializeComponent();
            createConnection();
        }
        private void createConnection()
        {
            try
            {
                String stringConnection = "Server=DESKTOP-TMCDUUR\\LUCKDAT;Database=BanVay; Integrated Security = true";
                conn = new SqlConnection(stringConnection);
                //MessageBox.Show(" Connect Successful Databases");
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erorr createconnection Databases" + ex.Message);
            }

        }

        private void DisplayData()
        {

            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                string sql = "select * from InvoiceDetails";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                DataTable data = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(data);
                dgv.DataSource = data;
                //MessageBox.Show(" View Successful");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erorr DisplayData" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        private DataTable GetFilteredInvoiceDetails(DateTime? minInvoiceDate, DateTime? maxInvoiceDate)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            StringBuilder query = new StringBuilder("SELECT * FROM InvoiceDetails WHERE 1 = 1");

            if (minInvoiceDate.HasValue)
            {
                query.Append(" AND InvoiceDate >= @minInvoiceDate");
            }
            if (maxInvoiceDate.HasValue)
            {
                query.Append(" AND InvoiceDate <= @maxInvoiceDate");
            }

            using (SqlCommand command = new SqlCommand(query.ToString(), conn))
            {
                if (minInvoiceDate.HasValue)
                {
                    command.Parameters.Add(new SqlParameter("@minInvoiceDate", SqlDbType.DateTime) { Value = minInvoiceDate.Value });
                }
                if (maxInvoiceDate.HasValue)
                {
                    command.Parameters.Add(new SqlParameter("@maxInvoiceDate", SqlDbType.DateTime) { Value = maxInvoiceDate.Value });
                }

                DataTable dt = new DataTable();

                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error querying data: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                return dt;
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string minInvoiceDateText = txtminInvoiceDate.Text.Trim();
            string maxInvoiceDateText = txtmaxInvoiceDate.Text.Trim();

            DateTime? minInvoiceDate = string.IsNullOrWhiteSpace(minInvoiceDateText) ? (DateTime?)null : Convert.ToDateTime(minInvoiceDateText);
            DateTime? maxInvoiceDate = string.IsNullOrWhiteSpace(maxInvoiceDateText) ? (DateTime?)null : Convert.ToDateTime(maxInvoiceDateText);

            // Call the method to get filtered InvoiceDetails based on date range
            DataTable filteredInvoiceDetails = GetFilteredInvoiceDetails(minInvoiceDate, maxInvoiceDate);

            if (filteredInvoiceDetails.Rows.Count == 0)
            {
                MessageBox.Show("No invoice details found matching the filter criteria.");
                dgv.DataSource = null;  // Clear the data grid if no results
            }
            else
            {
                dgv.DataSource = filteredInvoiceDetails;  // Bind the filtered data to the grid
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btbexitSupplier_Click(object sender, EventArgs e)
        {
            Home suppliersForm = new Home();
            suppliersForm.Show();
            this.Hide();
        }
    }
}
