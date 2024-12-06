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
using System.Globalization;
using System.IO;
using System.Net.NetworkInformation;

namespace BanVay
{
    public partial class Products : Form
    {
        SqlConnection conn;
        public Products()
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
                string sql = "select * from Products";
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



        private void btnimage_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();


            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif|All Files|*.*";
            openFileDialog.Title = "Select a File";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                txtimage.Text = openFileDialog.FileName;
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

        private void CreateProduct()
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                string sql = "INSERT INTO Products (Name, Category, Price, StockQuantity, SupplierID, Description, Image) " +
                             "VALUES (@name, @category, @price, @stockQuantity, @supplierID, @description, @imageData)";

                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = txtname.Text.ToString();
                cmd.Parameters.Add("@category", SqlDbType.NVarChar, 50).Value = txtcategory.Text.ToString();
                cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = Convert.ToDecimal(txtprice.Text);
                cmd.Parameters.Add("@stockQuantity", SqlDbType.Int).Value = Convert.ToInt32(txtstock.Text.ToString());

                // Assuming you have a way to get the SupplierID
                cmd.Parameters.Add("@supplierID", SqlDbType.Int).Value = Convert.ToInt32(txtsupplierID.Text);

                cmd.Parameters.Add("@description", SqlDbType.NVarChar, 500).Value = txtdescription.Text;

                // Handling image
                byte[] imageData = File.ReadAllBytes(txtimage.Text);
                cmd.Parameters.Add("@imageData", SqlDbType.VarBinary).Value = imageData;

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Product successfully created.");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating product: " + ex.Message);
            }
        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            DisplayData();
            CreateProduct();
        }

        private void DeleteProduct()
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandType = System.Data.CommandType.Text;

                String sql = " DELETE FROM Products WHERE ProductID = @ProductID";

                cmd.Parameters.Add("@ProductID", SqlDbType.Int);
                cmd.Parameters["@ProductID"].Value = Convert.ToInt32(txtproduct.Text.ToString());

                cmd.CommandText = sql;

                cmd.ExecuteNonQuery();
                MessageBox.Show(" Successful Delete");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erorr Delete Product " + ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            String ProductID = btndelete.Text.ToString();
            DialogResult re = MessageBox.Show("  " + ProductID, "Ok", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.Yes)
            {
                DisplayData();
                DeleteProduct();
            }
            DisplayData();
            DeleteProduct();
        }

        private void Update()
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandType = System.Data.CommandType.Text;
                string sql = "UPDATE Products SET Name = @Name, Category = @Category, Price = @Price, StockQuantity = @StockQuantity, SupplierID = @SupplierID, Description = @Description, Image = @Image WHERE ProductID = @ProductID";

                // Add parameters for the SQL command
                cmd.Parameters.Add("@ProductID", SqlDbType.Int);
                cmd.Parameters["@ProductID"].Value = Convert.ToInt32(txtproduct.Text.ToString());

                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
                cmd.Parameters["@Name"].Value = txtname.Text.ToString();

                cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 50);
                cmd.Parameters["@Category"].Value = txtcategory.Text.ToString();

                cmd.Parameters.Add("@Price", SqlDbType.Decimal);
                cmd.Parameters["@Price"].Value = Convert.ToDecimal(txtprice.Text.ToString());

                cmd.Parameters.Add("@StockQuantity", SqlDbType.Int);
                cmd.Parameters["@StockQuantity"].Value = Convert.ToInt32(txtstock.Text.ToString());

                cmd.Parameters.Add("@SupplierID", SqlDbType.Int);
                cmd.Parameters["@SupplierID"].Value = Convert.ToInt32(txtsupplierID.Text.ToString()); 

                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 500);
                cmd.Parameters["@Description"].Value = txtdescription.Text;

                // Handle image data as a byte array
                byte[] imageData = File.ReadAllBytes(txtimage.Text);
                cmd.Parameters.Add("@Image", SqlDbType.VarBinary).Value = imageData;

                // Execute the SQL command
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successful Edit");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Edit: " + ex.Message);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            DisplayData();
            Update();
        }

        private void SearchProduct(string productId)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                // Update SQL query to match the new column names
                string sql = "SELECT ProductID, Name, Category, Price, StockQuantity, SupplierID, Description, Image FROM Products WHERE ProductID = @ProductID";
                cmd.CommandText = sql;

                cmd.Parameters.Add("@ProductID", SqlDbType.Int);
                cmd.Parameters["@ProductID"].Value = Convert.ToInt32(productId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Fetch product details from the database
                    string productIdResult = reader["ProductID"].ToString();
                    string productNameResult = reader["Name"].ToString();
                    string categoryResult = reader["Category"].ToString();
                    string priceResult = reader["Price"].ToString();
                    string stockQuantityResult = reader["StockQuantity"].ToString();
                    string supplierIdResult = reader["SupplierID"].ToString(); // Optionally display SupplierID
                    string descriptionResult = reader["Description"].ToString();

                    byte[] imageData = (byte[])reader["Image"]; // Retrieve image as byte array
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBoxProduct.Image = Image.FromStream(ms); // Display image in PictureBox
                    }

                    // Show product details in a message box
                    MessageBox.Show("Product Id: " + productIdResult + "\n" +
                                    "Product Name: " + productNameResult + "\n" +
                                    "Category: " + categoryResult + "\n" +
                                    "Price: " + priceResult + "\n" +
                                    "Stock Quantity: " + stockQuantityResult + "\n" +
                                    "Supplier ID: " + supplierIdResult + "\n" + // If you want to show Supplier
                                    "Description: " + descriptionResult);
                }
                else
                {
                    MessageBox.Show("No product found with this product Id.");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when fetching product information by ProductId: " + ex.Message);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string productId = txtproduct.Text;
            SearchProduct(productId);
            DisplayData();
        }
    }
}
