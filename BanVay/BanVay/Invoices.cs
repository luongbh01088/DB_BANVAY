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
    public partial class Invoices : Form
    {
        SqlConnection conn;
        public Invoices()
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
                string sql = "select * from Invoices";
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

        private void Create()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                // SQL query for inserting data into the Invoices table
                String sql = "INSERT INTO Invoices (CustomerID, EmployeeID, TotalAmount, PaymentMethod, Notes) " +
                             "VALUES (@CustomerID, @EmployeeID, @TotalAmount, @PaymentMethod, @Notes)";

                // Add parameters to the SQL command
                cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                cmd.Parameters["@CustomerID"].Value = Convert.ToInt32(txtcustomerID.Text); // Assuming txtCustomerID is the input for CustomerID

                cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
                cmd.Parameters["@EmployeeID"].Value = Convert.ToInt32(txtemployeeID.Text); // Assuming txtEmployeeID is the input for EmployeeID

                cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal);
                cmd.Parameters["@TotalAmount"].Value = Convert.ToDecimal(txttotalAmount.Text); // Assuming txtTotalAmount is the input for TotalAmount

                cmd.Parameters.Add("@PaymentMethod", SqlDbType.NVarChar, 50);
                cmd.Parameters["@PaymentMethod"].Value = cbbpaymethod.SelectedItem.ToString(); // Assuming txtPaymentMethod is the input for PaymentMethod

                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 500);
                cmd.Parameters["@Notes"].Value = txtnote.Text; // Assuming txtNotes is the input for Notes

                cmd.CommandText = sql;

                // Execute the command to insert the data
                cmd.ExecuteNonQuery();

                MessageBox.Show("Invoice created successfully!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating invoice: " + ex.Message);
            }
        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            DisplayData();
            Create();
        }

        private void btbexitSupplier_Click(object sender, EventArgs e)
        {
            Home suppliersForm = new Home();
            suppliersForm.Show();
            this.Hide();
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void Delete()
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandType = System.Data.CommandType.Text;

                String sql = " DELETE FROM Invoices WHERE InvoiceID = @InvoiceID";

                cmd.Parameters.Add("@InvoiceID", SqlDbType.Int);
                cmd.Parameters["@InvoiceID"].Value = Convert.ToInt32(txtinvoice.Text.ToString());

                cmd.CommandText = sql;

                cmd.ExecuteNonQuery();
                MessageBox.Show(" Delete Successful");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erorr Delete  " + ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            String InvoiceID = btndelete.Text.ToString();
            DialogResult re = MessageBox.Show("  " + InvoiceID, "ok", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.Yes)
            {
                DisplayData();
                Delete();
            }
            DisplayData();
            Delete();
        }

        private void Update()
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                // Câu lệnh SQL để cập nhật bảng Invoices
                string sql = "UPDATE Invoices SET CustomerID = @CustomerID, EmployeeID = @EmployeeID, TotalAmount = @TotalAmount, PaymentMethod = @PaymentMethod, Notes = @Notes WHERE InvoiceID = @InvoiceID";

                // Thêm các tham số và gán giá trị từ giao diện người dùng
                cmd.Parameters.Add("@InvoiceID", SqlDbType.Int);
                cmd.Parameters["@InvoiceID"].Value = Convert.ToInt32(txtinvoice.Text.ToString());

                cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                cmd.Parameters["@CustomerID"].Value = Convert.ToInt32(txtinvoice.Text.ToString());

                cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
                cmd.Parameters["@EmployeeID"].Value = Convert.ToInt32(txtemployeeID.Text.ToString());

                cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal);
                cmd.Parameters["@TotalAmount"].Value = Convert.ToDecimal(txttotalAmount.Text.ToString());

                cmd.Parameters.Add("@PaymentMethod", SqlDbType.NVarChar);
                cmd.Parameters["@PaymentMethod"].Value = cbbpaymethod.SelectedItem.ToString();

                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar);
                cmd.Parameters["@Notes"].Value = txtnote.Text.ToString();

                // Thực thi lệnh SQL
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Invoice Updated Successfully");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Updating Invoice: " + ex.Message);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            Update();
            DisplayData();
        }

        private void Search(string invoiceId)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                // Câu lệnh SQL để lấy thông tin từ bảng Invoices
                string sql = "SELECT InvoiceID, CustomerID, EmployeeID, InvoiceDate, TotalAmount, PaymentMethod, Notes FROM Invoices WHERE InvoiceID = @InvoiceID";
                cmd.CommandText = sql;

                // Thêm tham số InvoiceID
                cmd.Parameters.Add("@InvoiceID", SqlDbType.Int);
                cmd.Parameters["@InvoiceID"].Value = invoiceId;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Đọc các giá trị từ bảng Invoices
                    string invoiceIdResult = reader["InvoiceID"].ToString();
                    string customerIdResult = reader["CustomerID"].ToString();
                    string employeeIdResult = reader["EmployeeID"].ToString();
                    string invoiceDateResult = reader["InvoiceDate"].ToString();
                    string totalAmountResult = reader["TotalAmount"].ToString();
                    string paymentMethodResult = reader["PaymentMethod"].ToString();
                    string notesResult = reader["Notes"].ToString();

                    // Hiển thị thông tin
                    MessageBox.Show("Invoice ID: " + invoiceIdResult + "\n" +
                                     "Customer ID: " + customerIdResult + "\n" +
                                     "Employee ID: " + employeeIdResult + "\n" +
                                     "Invoice Date: " + invoiceDateResult + "\n" +
                                     "Total Amount: " + totalAmountResult + "\n" +
                                     "Payment Method: " + paymentMethodResult + "\n" +
                                     "Notes: " + notesResult);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Error Searching Invoice: " + ex.Message);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string InvoiceID = txtinvoice.Text;
            Search(InvoiceID);
            DisplayData();

        }
    }
}
