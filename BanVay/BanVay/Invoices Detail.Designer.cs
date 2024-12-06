namespace BanVay
{
    partial class Invoices_Detail
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
            this.btnview = new System.Windows.Forms.Button();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btbexitSupplier = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtmaxInvoiceDate = new System.Windows.Forms.TextBox();
            this.txtminInvoiceDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(367, 12);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 62;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.Size = new System.Drawing.Size(721, 613);
            this.dgv.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnview);
            this.groupBox2.Controls.Add(this.btnsearch);
            this.groupBox2.Controls.Add(this.btbexitSupplier);
            this.groupBox2.Location = new System.Drawing.Point(20, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 122);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Funcsion";
            // 
            // btnview
            // 
            this.btnview.Location = new System.Drawing.Point(107, 43);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(75, 35);
            this.btnview.TabIndex = 3;
            this.btnview.Text = "View";
            this.btnview.UseVisualStyleBackColor = true;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(16, 43);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 35);
            this.btnsearch.TabIndex = 1;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // btbexitSupplier
            // 
            this.btbexitSupplier.Location = new System.Drawing.Point(203, 43);
            this.btbexitSupplier.Name = "btbexitSupplier";
            this.btbexitSupplier.Size = new System.Drawing.Size(106, 35);
            this.btbexitSupplier.TabIndex = 1;
            this.btbexitSupplier.Text = "View Home";
            this.btbexitSupplier.UseVisualStyleBackColor = true;
            this.btbexitSupplier.Click += new System.EventHandler(this.btbexitSupplier_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtmaxInvoiceDate);
            this.groupBox1.Controls.Add(this.txtminInvoiceDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 170);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // txtmaxInvoiceDate
            // 
            this.txtmaxInvoiceDate.Location = new System.Drawing.Point(171, 109);
            this.txtmaxInvoiceDate.Name = "txtmaxInvoiceDate";
            this.txtmaxInvoiceDate.Size = new System.Drawing.Size(120, 26);
            this.txtmaxInvoiceDate.TabIndex = 2;
            // 
            // txtminInvoiceDate
            // 
            this.txtminInvoiceDate.Location = new System.Drawing.Point(171, 53);
            this.txtminInvoiceDate.Name = "txtminInvoiceDate";
            this.txtminInvoiceDate.Size = new System.Drawing.Size(120, 26);
            this.txtminInvoiceDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Invoice End Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice Start Date";
            // 
            // Invoices_Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(1100, 637);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Invoices_Detail";
            this.Text = "Invoices_Detail";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnview;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Button btbexitSupplier;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtmaxInvoiceDate;
        private System.Windows.Forms.TextBox txtminInvoiceDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}