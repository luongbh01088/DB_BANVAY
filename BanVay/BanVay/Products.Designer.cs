namespace BanVay
{
    partial class Products
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupboxImageProduct = new System.Windows.Forms.GroupBox();
            this.pictureBoxProduct = new System.Windows.Forms.PictureBox();
            this.btnview = new System.Windows.Forms.Button();
            this.txtproduct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btncreate = new System.Windows.Forms.Button();
            this.btbexitSupplier = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtimage = new System.Windows.Forms.TextBox();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.btnimage = new System.Windows.Forms.Button();
            this.txtcategory = new System.Windows.Forms.TextBox();
            this.Po = new System.Windows.Forms.Label();
            this.txtsupplierID = new System.Windows.Forms.TextBox();
            this.txtstock = new System.Windows.Forms.TextBox();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupboxImageProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(374, 12);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 62;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.Size = new System.Drawing.Size(714, 613);
            this.dgv.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupboxImageProduct);
            this.groupBox2.Controls.Add(this.btnview);
            this.groupBox2.Controls.Add(this.txtproduct);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnsearch);
            this.groupBox2.Controls.Add(this.btnupdate);
            this.groupBox2.Controls.Add(this.btndelete);
            this.groupBox2.Controls.Add(this.btncreate);
            this.groupBox2.Controls.Add(this.btbexitSupplier);
            this.groupBox2.Location = new System.Drawing.Point(20, 378);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 247);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Funcsion";
            // 
            // groupboxImageProduct
            // 
            this.groupboxImageProduct.Controls.Add(this.pictureBoxProduct);
            this.groupboxImageProduct.Location = new System.Drawing.Point(205, 25);
            this.groupboxImageProduct.Name = "groupboxImageProduct";
            this.groupboxImageProduct.Size = new System.Drawing.Size(104, 189);
            this.groupboxImageProduct.TabIndex = 30;
            this.groupboxImageProduct.TabStop = false;
            this.groupboxImageProduct.Text = "Image";
            // 
            // pictureBoxProduct
            // 
            this.pictureBoxProduct.Location = new System.Drawing.Point(3, 35);
            this.pictureBoxProduct.Name = "pictureBoxProduct";
            this.pictureBoxProduct.Size = new System.Drawing.Size(101, 148);
            this.pictureBoxProduct.TabIndex = 0;
            this.pictureBoxProduct.TabStop = false;
            // 
            // btnview
            // 
            this.btnview.Location = new System.Drawing.Point(112, 66);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(75, 35);
            this.btnview.TabIndex = 3;
            this.btnview.Text = "View";
            this.btnview.UseVisualStyleBackColor = true;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // txtproduct
            // 
            this.txtproduct.Location = new System.Drawing.Point(112, 114);
            this.txtproduct.Name = "txtproduct";
            this.txtproduct.Size = new System.Drawing.Size(75, 26);
            this.txtproduct.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Product ID";
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(65, 194);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 35);
            this.btnsearch.TabIndex = 1;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Location = new System.Drawing.Point(112, 153);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(75, 35);
            this.btnupdate.TabIndex = 1;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(17, 153);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 35);
            this.btndelete.TabIndex = 1;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btncreate
            // 
            this.btncreate.Location = new System.Drawing.Point(17, 66);
            this.btncreate.Name = "btncreate";
            this.btncreate.Size = new System.Drawing.Size(75, 35);
            this.btncreate.TabIndex = 1;
            this.btncreate.Text = "Create";
            this.btncreate.UseVisualStyleBackColor = true;
            this.btncreate.Click += new System.EventHandler(this.btncreate_Click);
            // 
            // btbexitSupplier
            // 
            this.btbexitSupplier.Location = new System.Drawing.Point(54, 25);
            this.btbexitSupplier.Name = "btbexitSupplier";
            this.btbexitSupplier.Size = new System.Drawing.Size(106, 35);
            this.btbexitSupplier.TabIndex = 1;
            this.btbexitSupplier.Text = "View Home";
            this.btbexitSupplier.UseVisualStyleBackColor = true;
            this.btbexitSupplier.Click += new System.EventHandler(this.btbexitSupplier_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtimage);
            this.groupBox1.Controls.Add(this.txtdescription);
            this.groupBox1.Controls.Add(this.btnimage);
            this.groupBox1.Controls.Add(this.txtcategory);
            this.groupBox1.Controls.Add(this.Po);
            this.groupBox1.Controls.Add(this.txtsupplierID);
            this.groupBox1.Controls.Add(this.txtstock);
            this.groupBox1.Controls.Add(this.txtprice);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Price);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 349);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // txtimage
            // 
            this.txtimage.Location = new System.Drawing.Point(117, 304);
            this.txtimage.Name = "txtimage";
            this.txtimage.Size = new System.Drawing.Size(160, 26);
            this.txtimage.TabIndex = 2;
            // 
            // txtdescription
            // 
            this.txtdescription.Location = new System.Drawing.Point(117, 254);
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(160, 26);
            this.txtdescription.TabIndex = 2;
            // 
            // btnimage
            // 
            this.btnimage.Location = new System.Drawing.Point(21, 298);
            this.btnimage.Name = "btnimage";
            this.btnimage.Size = new System.Drawing.Size(75, 32);
            this.btnimage.TabIndex = 11;
            this.btnimage.Text = "Image";
            this.btnimage.UseVisualStyleBackColor = true;
            this.btnimage.Click += new System.EventHandler(this.btnimage_Click_1);
            // 
            // txtcategory
            // 
            this.txtcategory.Location = new System.Drawing.Point(117, 77);
            this.txtcategory.Name = "txtcategory";
            this.txtcategory.Size = new System.Drawing.Size(160, 26);
            this.txtcategory.TabIndex = 2;
            // 
            // Po
            // 
            this.Po.AutoSize = true;
            this.Po.Location = new System.Drawing.Point(28, 83);
            this.Po.Name = "Po";
            this.Po.Size = new System.Drawing.Size(73, 20);
            this.Po.TabIndex = 0;
            this.Po.Text = "Category";
            // 
            // txtsupplierID
            // 
            this.txtsupplierID.Location = new System.Drawing.Point(117, 209);
            this.txtsupplierID.Name = "txtsupplierID";
            this.txtsupplierID.Size = new System.Drawing.Size(160, 26);
            this.txtsupplierID.TabIndex = 2;
            // 
            // txtstock
            // 
            this.txtstock.Location = new System.Drawing.Point(117, 167);
            this.txtstock.Name = "txtstock";
            this.txtstock.Size = new System.Drawing.Size(160, 26);
            this.txtstock.TabIndex = 2;
            // 
            // txtprice
            // 
            this.txtprice.Location = new System.Drawing.Point(117, 122);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(160, 26);
            this.txtprice.TabIndex = 2;
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(117, 35);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(160, 26);
            this.txtname.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Supplier ID ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Stock";
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Location = new System.Drawing.Point(28, 128);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(44, 20);
            this.Price.TabIndex = 0;
            this.Price.Text = "Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(1100, 637);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Products";
            this.Text = "Products";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupboxImageProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnview;
        private System.Windows.Forms.TextBox txtproduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btncreate;
        private System.Windows.Forms.Button btbexitSupplier;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.TextBox txtcategory;
        private System.Windows.Forms.Label Po;
        private System.Windows.Forms.TextBox txtsupplierID;
        private System.Windows.Forms.TextBox txtstock;
        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtimage;
        private System.Windows.Forms.Button btnimage;
        private System.Windows.Forms.GroupBox groupboxImageProduct;
        private System.Windows.Forms.PictureBox pictureBoxProduct;
    }
}