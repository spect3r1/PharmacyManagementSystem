namespace PharmacyManagementSystem.Forms
{
    partial class SalesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbCustomers;
        private System.Windows.Forms.DataGridView dgvAvailableMedicines;
        private System.Windows.Forms.DataGridView dgvOrderMedicines;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAddToOrder;
        private System.Windows.Forms.Button btnCompleteOrder;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblQuantity;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.dgvAvailableMedicines = new System.Windows.Forms.DataGridView();
            this.dgvOrderMedicines = new System.Windows.Forms.DataGridView();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnAddToOrder = new System.Windows.Forms.Button();
            this.btnCompleteOrder = new System.Windows.Forms.Button();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableMedicines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderMedicines)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.FormattingEnabled = true;
            this.cmbCustomers.Location = new System.Drawing.Point(150, 30);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.Size = new System.Drawing.Size(150, 21);
            this.cmbCustomers.TabIndex = 0;
            // 
            // dgvAvailableMedicines
            // 
            this.dgvAvailableMedicines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableMedicines.Location = new System.Drawing.Point(50, 70);
            this.dgvAvailableMedicines.Name = "dgvAvailableMedicines";
            this.dgvAvailableMedicines.Size = new System.Drawing.Size(300, 200);
            this.dgvAvailableMedicines.TabIndex = 1;
            // 
            // dgvOrderMedicines
            // 
            this.dgvOrderMedicines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderMedicines.Location = new System.Drawing.Point(360, 70);
            this.dgvOrderMedicines.Name = "dgvOrderMedicines";
            this.dgvOrderMedicines.Size = new System.Drawing.Size(300, 200);
            this.dgvOrderMedicines.TabIndex = 2;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(150, 280);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 3;
            // 
            // btnAddToOrder
            // 
            this.btnAddToOrder.Location = new System.Drawing.Point(260, 280);
            this.btnAddToOrder.Name = "btnAddToOrder";
            this.btnAddToOrder.Size = new System.Drawing.Size(90, 23);
            this.btnAddToOrder.TabIndex = 4;
            this.btnAddToOrder.Text = "Add to Order";
            this.btnAddToOrder.UseVisualStyleBackColor = true;
            this.btnAddToOrder.Click += new System.EventHandler(this.btnAddToOrder_Click);
            // 
            // btnCompleteOrder
            // 
            this.btnCompleteOrder.Location = new System.Drawing.Point(360, 280);
            this.btnCompleteOrder.Name = "btnCompleteOrder";
            this.btnCompleteOrder.Size = new System.Drawing.Size(90, 23);
            this.btnCompleteOrder.TabIndex = 5;
            this.btnCompleteOrder.Text = "Complete Order";
            this.btnCompleteOrder.UseVisualStyleBackColor = true;
            this.btnCompleteOrder.Click += new System.EventHandler(this.btnCompleteOrder_Click);
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(50, 320);
            this.txtInvoice.Multiline = true;
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.ReadOnly = true;
            this.txtInvoice.Size = new System.Drawing.Size(610, 150);
            this.txtInvoice.TabIndex = 6;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(50, 30);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(56, 13);
            this.lblCustomer.TabIndex = 7;
            this.lblCustomer.Text = "Customer:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(50, 280);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(52, 13);
            this.lblQuantity.TabIndex = 8;
            this.lblQuantity.Text = "Quantity:";
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.txtInvoice);
            this.Controls.Add(this.btnCompleteOrder);
            this.Controls.Add(this.btnAddToOrder);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.dgvOrderMedicines);
            this.Controls.Add(this.dgvAvailableMedicines);
            this.Controls.Add(this.cmbCustomers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SalesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Process Sales";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableMedicines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderMedicines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}