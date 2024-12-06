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
    public partial class Login : Form
    {
        SqlConnection conn;
        public Login()
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

 

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit?", "Ok", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
                //Login suppliersForm = new Login();
                //suppliersForm.Show();
                //this.Hide();
            }
            else
            {
                return;
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtusername.Text;
                string password = txtpassword.Text;

                conn.Open();
                // Create SQL command
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                // Use parameters in SQL statement to avoid SQL Injection
                cmd.CommandText = "SELECT * FROM Users WHERE username = @username AND password = @password";
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Show success message
                    MessageBox.Show("Login successful!");

                    Home suppliersForm = new Home();
                    suppliersForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password!");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred in btnLogin_Click: " + ex.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
