using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVay
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnsuppliers_Click(object sender, EventArgs e)
        {
            
            Suppliers suppliersForm = new Suppliers();
            suppliersForm.Show();
            this.Hide();
        }

        private void btnemployees_Click(object sender, EventArgs e)
        {

            Employees suppliersForm = new Employees();
            suppliersForm.Show();
            this.Hide();
        }

        private void btnproducts_Click(object sender, EventArgs e)
        {
            Products suppliersForm = new Products();
            suppliersForm.Show();
            this.Hide();
        }

        private void btncustomers_Click(object sender, EventArgs e)
        {
            Customers suppliersForm = new Customers();
            suppliersForm.Show();
            this.Hide();
        }

        private void btninvoices_Click(object sender, EventArgs e)
        {
            Invoices suppliersForm = new Invoices();
            suppliersForm.Show();
            this.Hide();
        }

        private void btninvoicesDetail_Click(object sender, EventArgs e)
        {
            Invoices_Detail suppliersForm = new Invoices_Detail();
            suppliersForm.Show();
            this.Hide();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit?", "Ok", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //Application.Exit();
                Login suppliersForm = new Login();
                suppliersForm.Show();
                this.Hide();
            }
            else
            {
                return;
            }
        }
    }
}
