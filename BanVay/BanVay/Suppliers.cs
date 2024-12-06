﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;


namespace BanVay
{
    public partial class Suppliers : Form
    {
        SqlConnection conn;
        public Suppliers()
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
                string sql = "select * from Suppliers";
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

        private void CreateSupplier()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                // Câu lệnh SQL chèn dữ liệu vào bảng Suppliers
                string sql = "INSERT INTO Suppliers (Name, Contact, Address, Email, Phone) " +
                             "VALUES (@Name, @Contact, @Address, @Email, @Phone)";

                // Gắn các tham số với giá trị từ giao diện
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                cmd.Parameters["@Name"].Value = txtname.Text.ToString();

                cmd.Parameters.Add("@Contact", SqlDbType.NVarChar);
                cmd.Parameters["@Contact"].Value = txtcontact.Text.ToString();

                cmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                cmd.Parameters["@Address"].Value = txtaddress.Text.ToString();

                cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                cmd.Parameters["@Email"].Value = txtemail.Text.ToString();

                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                cmd.Parameters["@Phone"].Value = txtphone.Text.ToString();

                cmd.CommandText = sql;

                // Thực thi lệnh SQL
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create Supplier Successful");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Creating Supplier: " + ex.Message);
            }
        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            DisplayData();
            CreateSupplier();
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

                String sql = " DELETE FROM Suppliers WHERE SupplierID = @SupplierID";

                cmd.Parameters.Add("@SupplierID", SqlDbType.Int);
                cmd.Parameters["@SupplierID"].Value = Convert.ToInt32(txtsupplier.Text.ToString());

                cmd.CommandText = sql;

                cmd.ExecuteNonQuery();
                MessageBox.Show(" xoa thanh cong");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erorr Delete " + ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            String SupplierID = btndelete.Text.ToString();
            DialogResult re = MessageBox.Show("" + SupplierID, "ok", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                string sql = "UPDATE Suppliers SET Name = @Name, Contact = @Contact, Address = @Address, Email = @Email, Phone = @Phone WHERE SupplierID = @SupplierID";

                cmd.Parameters.Add("@SupplierID", SqlDbType.Int);
                cmd.Parameters["@SupplierID"].Value = Convert.ToInt32(txtsupplier.Text.ToString());

                cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                cmd.Parameters["@Name"].Value = txtname.Text.ToString();

                cmd.Parameters.Add("@Contact", SqlDbType.NVarChar);
                cmd.Parameters["@Contact"].Value = txtcontact.Text.ToString();

                cmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                cmd.Parameters["@Address"].Value = txtaddress.Text.ToString();

                cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                cmd.Parameters["@Email"].Value = txtemail.Text.ToString();

                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                cmd.Parameters["@Phone"].Value = txtphone.Text.ToString();

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successful ");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            DisplayData();
            Update();
        }

        private void Search(string supplierId)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                // Câu lệnh SQL để lấy thông tin từ bảng Suppliers
                string sql = "SELECT SupplierID, Name, Contact, Address, Email, Phone, CreatedDate FROM Suppliers WHERE SupplierID = @SupplierID";
                cmd.CommandText = sql;

                // Thêm tham số SupplierID
                cmd.Parameters.Add("@SupplierID", SqlDbType.Int);
                cmd.Parameters["@SupplierID"].Value = supplierId;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Đọc các giá trị từ bảng Suppliers
                    string supplierIdResult = reader["SupplierID"].ToString();
                    string nameResult = reader["Name"].ToString();
                    string contactResult = reader["Contact"].ToString();
                    string addressResult = reader["Address"].ToString();
                    string emailResult = reader["Email"].ToString();
                    string phoneResult = reader["Phone"].ToString();
                    string createdDateResult = reader["CreatedDate"].ToString();

                    // Hiển thị thông tin
                    MessageBox.Show("Supplier ID: " + supplierIdResult + "\n" +
                                     "Name: " + nameResult + "\n" +
                                     "Contact: " + contactResult + "\n" +
                                     "Address: " + addressResult + "\n" +
                                     "Email: " + emailResult + "\n" +
                                     "Phone: " + phoneResult + "\n" +
                                     "Created Date: " + createdDateResult);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Error Searching Supplier: " + ex.Message);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string SupplierID = txtsupplier.Text;
            Search(SupplierID);
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
