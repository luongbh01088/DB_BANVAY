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
using System.Xml.Linq;

namespace BanVay
{
    public partial class Employees : Form
    {
        SqlConnection conn;
        public Employees()
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
                string sql = "select * from Employees";
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

        private void CreateEmployee()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                // Câu lệnh SQL chèn dữ liệu vào bảng Employees
                string sql = "INSERT INTO Employees (Name, Position, Contact, Address, Phone, Salary, Status) " +
                             "VALUES (@Name, @Position, @Contact, @Address, @Phone, @Salary, @Status)";

                // Gắn các tham số với giá trị từ giao diện
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                cmd.Parameters["@Name"].Value = txtname.Text.ToString();

                cmd.Parameters.Add("@Position", SqlDbType.NVarChar);
                cmd.Parameters["@Position"].Value = txtposition.Text.ToString();

                cmd.Parameters.Add("@Contact", SqlDbType.NVarChar);
                cmd.Parameters["@Contact"].Value = txtcontact.Text.ToString();

                cmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                cmd.Parameters["@Address"].Value = txtaddress.Text.ToString();

                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                cmd.Parameters["@Phone"].Value = txtphone.Text.ToString();

                cmd.Parameters.Add("@Salary", SqlDbType.Decimal);
                cmd.Parameters["@Salary"].Value = Convert.ToDecimal(txtsalary.Text);

                cmd.Parameters.Add("@Status", SqlDbType.NVarChar);
                cmd.Parameters["@Status"].Value = cbbstatu.SelectedItem.ToString(); // Giá trị mặc định hoặc nhập từ giao diện

                cmd.CommandText = sql;

                // Thực thi lệnh SQL
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create Employee Successful");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Creating Employee: " + ex.Message);
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            DisplayData();
            CreateEmployee();
        }

        private void btbexitSupplier_Click(object sender, EventArgs e)
        {
            Home suppliersForm = new Home();
            suppliersForm.Show();
            this.Hide();
        }

        private void Delete()
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandType = System.Data.CommandType.Text;

                String sql = " DELETE FROM Employees WHERE EmployeeID = @EmployeeID";

                cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
                cmd.Parameters["@EmployeeID"].Value = Convert.ToInt32(txtemployee.Text.ToString());

                cmd.CommandText = sql;

                cmd.ExecuteNonQuery();
                MessageBox.Show(" xoa thanh cong");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erorr Delete  " + ex.Message);
            }
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            String EmployeeID = btndelete.Text.ToString();
            DialogResult re = MessageBox.Show("  " + EmployeeID, "ok", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

                string sql = "UPDATE Employees SET Name = @Name, Position = @Position, Contact = @Contact, Address = @Address, Phone = @Phone, Salary = @Salary, Status = @Status WHERE EmployeeID = @EmployeeID";

                // Thêm các tham số và gán giá trị từ giao diện
                cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
                cmd.Parameters["@EmployeeID"].Value = Convert.ToInt32(txtemployee.Text.ToString());

                cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                cmd.Parameters["@Name"].Value = txtname.Text.ToString();

                cmd.Parameters.Add("@Position", SqlDbType.NVarChar);
                cmd.Parameters["@Position"].Value = txtposition.Text.ToString();

                cmd.Parameters.Add("@Contact", SqlDbType.NVarChar);
                cmd.Parameters["@Contact"].Value = txtcontact.Text.ToString();

                cmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                cmd.Parameters["@Address"].Value = txtaddress.Text.ToString();

                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                cmd.Parameters["@Phone"].Value = txtphone.Text.ToString();

                cmd.Parameters.Add("@Salary", SqlDbType.Decimal);
                cmd.Parameters["@Salary"].Value = Convert.ToDecimal(txtsalary.Text.ToString());

                cmd.Parameters.Add("@Status", SqlDbType.NVarChar);
                cmd.Parameters["@Status"].Value = cbbstatu.SelectedItem.ToString();

                // Thực thi lệnh SQL
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Updated Employee");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Updating Employee: " + ex.Message);
            }
        }


        private void btnupdate_Click(object sender, EventArgs e)
        {
            DisplayData();
            Update();
        }

        private void Search(string employeeId)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                // Câu lệnh SQL để lấy thông tin từ bảng Employees
                string sql = "SELECT EmployeeID, Name, Position, Contact, Address, Phone, Salary, Status FROM Employees WHERE EmployeeID = @EmployeeID";
                cmd.CommandText = sql;

                // Thêm tham số EmployeeID
                cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
                cmd.Parameters["@EmployeeID"].Value = employeeId;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Đọc các giá trị từ bảng Employees
                    string employeeIdResult = reader["EmployeeID"].ToString();
                    string nameResult = reader["Name"].ToString();
                    string positionResult = reader["Position"].ToString();
                    string contactResult = reader["Contact"].ToString();
                    string addressResult = reader["Address"].ToString();
                    string phoneResult = reader["Phone"].ToString();
                    string salaryResult = reader["Salary"].ToString();
                    string statusResult = reader["Status"].ToString();

                    // Hiển thị thông tin
                    MessageBox.Show("Employee ID: " + employeeIdResult + "\n" +
                                     "Name: " + nameResult + "\n" +
                                     "Position: " + positionResult + "\n" +
                                     "Contact: " + contactResult + "\n" +
                                     "Address: " + addressResult + "\n" +
                                     "Phone: " + phoneResult + "\n" +
                                     "Salary: " + salaryResult + "\n" +
                                     "Status: " + statusResult);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Error Searching Employee: " + ex.Message);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string employeeID = txtemployee.Text;
            Search(employeeID);
            DisplayData();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
