namespace WindowsFormsApp
{
    partial class Form2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.regionButton = new System.Windows.Forms.Button();
            this.shipperButton = new System.Windows.Forms.Button();
            this.categoryButton = new System.Windows.Forms.Button();
            this.customerButton = new System.Windows.Forms.Button();
            this.employeeButton = new System.Windows.Forms.Button();
            this.orderButton = new System.Windows.Forms.Button();
            this.productButton = new System.Windows.Forms.Button();
            this.supplierButton = new System.Windows.Forms.Button();
            this.territoryButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(124, 192);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(521, 200);
            this.dataGridView1.TabIndex = 1;
            // 
            // regionButton
            // 
            this.regionButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.regionButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.regionButton.Location = new System.Drawing.Point(124, 103);
            this.regionButton.Name = "regionButton";
            this.regionButton.Size = new System.Drawing.Size(107, 46);
            this.regionButton.TabIndex = 3;
            this.regionButton.Text = "Region";
            this.regionButton.UseVisualStyleBackColor = false;
            this.regionButton.Click += new System.EventHandler(this.regionButton_Click);
            // 
            // shipperButton
            // 
            this.shipperButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.shipperButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.shipperButton.Location = new System.Drawing.Point(262, 103);
            this.shipperButton.Name = "shipperButton";
            this.shipperButton.Size = new System.Drawing.Size(107, 46);
            this.shipperButton.TabIndex = 2;
            this.shipperButton.Text = "Shipper";
            this.shipperButton.UseVisualStyleBackColor = false;
            this.shipperButton.Click += new System.EventHandler(this.shipperButton_Click);
            // 
            // categoryButton
            // 
            this.categoryButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.categoryButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.categoryButton.Location = new System.Drawing.Point(69, 40);
            this.categoryButton.Name = "categoryButton";
            this.categoryButton.Size = new System.Drawing.Size(107, 46);
            this.categoryButton.TabIndex = 4;
            this.categoryButton.Text = "Category";
            this.categoryButton.UseVisualStyleBackColor = false;
            this.categoryButton.Click += new System.EventHandler(this.categoryButton_Click);
            // 
            // customerButton
            // 
            this.customerButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.customerButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.customerButton.Location = new System.Drawing.Point(198, 40);
            this.customerButton.Name = "customerButton";
            this.customerButton.Size = new System.Drawing.Size(107, 46);
            this.customerButton.TabIndex = 5;
            this.customerButton.Text = "Customer";
            this.customerButton.UseVisualStyleBackColor = false;
            this.customerButton.Click += new System.EventHandler(this.customerButton_Click);
            // 
            // employeeButton
            // 
            this.employeeButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.employeeButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.employeeButton.Location = new System.Drawing.Point(336, 40);
            this.employeeButton.Name = "employeeButton";
            this.employeeButton.Size = new System.Drawing.Size(107, 46);
            this.employeeButton.TabIndex = 6;
            this.employeeButton.Text = "Employee";
            this.employeeButton.UseVisualStyleBackColor = false;
            this.employeeButton.Click += new System.EventHandler(this.employeeButton_Click);
            // 
            // orderButton
            // 
            this.orderButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.orderButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.orderButton.Location = new System.Drawing.Point(479, 40);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(107, 46);
            this.orderButton.TabIndex = 7;
            this.orderButton.Text = "Order";
            this.orderButton.UseVisualStyleBackColor = false;
            this.orderButton.Click += new System.EventHandler(this.orderButton_Click);
            // 
            // productButton
            // 
            this.productButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.productButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.productButton.Location = new System.Drawing.Point(609, 40);
            this.productButton.Name = "productButton";
            this.productButton.Size = new System.Drawing.Size(107, 46);
            this.productButton.TabIndex = 8;
            this.productButton.Text = "Product";
            this.productButton.UseVisualStyleBackColor = false;
            this.productButton.Click += new System.EventHandler(this.productButton_Click);
            // 
            // supplierButton
            // 
            this.supplierButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.supplierButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.supplierButton.Location = new System.Drawing.Point(400, 103);
            this.supplierButton.Name = "supplierButton";
            this.supplierButton.Size = new System.Drawing.Size(107, 46);
            this.supplierButton.TabIndex = 9;
            this.supplierButton.Text = "Supplier";
            this.supplierButton.UseVisualStyleBackColor = false;
            this.supplierButton.Click += new System.EventHandler(this.supplierButton_Click);
            // 
            // territoryButton
            // 
            this.territoryButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.territoryButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.territoryButton.Location = new System.Drawing.Point(538, 103);
            this.territoryButton.Name = "territoryButton";
            this.territoryButton.Size = new System.Drawing.Size(107, 46);
            this.territoryButton.TabIndex = 10;
            this.territoryButton.Text = "Territory";
            this.territoryButton.UseVisualStyleBackColor = false;
            this.territoryButton.Click += new System.EventHandler(this.territoryButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.territoryButton);
            this.Controls.Add(this.supplierButton);
            this.Controls.Add(this.productButton);
            this.Controls.Add(this.orderButton);
            this.Controls.Add(this.employeeButton);
            this.Controls.Add(this.customerButton);
            this.Controls.Add(this.categoryButton);
            this.Controls.Add(this.shipperButton);
            this.Controls.Add(this.regionButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button regionButton;
        private System.Windows.Forms.Button shipperButton;
        private System.Windows.Forms.Button categoryButton;
        private System.Windows.Forms.Button customerButton;
        private System.Windows.Forms.Button employeeButton;
        private System.Windows.Forms.Button orderButton;
        private System.Windows.Forms.Button productButton;
        private System.Windows.Forms.Button supplierButton;
        private System.Windows.Forms.Button territoryButton;
    }
}