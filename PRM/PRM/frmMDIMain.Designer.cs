namespace PRM
{
    partial class frmMDIMain
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
            this.mnsPRM = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEditStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsPRM.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsPRM
            // 
            this.mnsPRM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.addEditStockToolStripMenuItem});
            this.mnsPRM.Location = new System.Drawing.Point(0, 0);
            this.mnsPRM.Name = "mnsPRM";
            this.mnsPRM.Size = new System.Drawing.Size(468, 24);
            this.mnsPRM.TabIndex = 1;
            this.mnsPRM.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productToolStripMenuItem,
            this.productCategoryToolStripMenuItem,
            this.customerToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.openToolStripMenuItem.Text = "Add/Edit";
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.productToolStripMenuItem.Text = "Product";
            this.productToolStripMenuItem.Click += new System.EventHandler(this.productToolStripMenuItem_Click);
            // 
            // productCategoryToolStripMenuItem
            // 
            this.productCategoryToolStripMenuItem.Name = "productCategoryToolStripMenuItem";
            this.productCategoryToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.productCategoryToolStripMenuItem.Text = "ProductCategory";
            this.productCategoryToolStripMenuItem.Click += new System.EventHandler(this.productCategoryToolStripMenuItem_Click_1);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.customerToolStripMenuItem.Text = "Customer";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // addEditStockToolStripMenuItem
            // 
            this.addEditStockToolStripMenuItem.Name = "addEditStockToolStripMenuItem";
            this.addEditStockToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.addEditStockToolStripMenuItem.Text = "Add/Edit Stock";
            this.addEditStockToolStripMenuItem.Click += new System.EventHandler(this.addEditStockToolStripMenuItem_Click);
            // 
            // frmMDIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 262);
            this.Controls.Add(this.mnsPRM);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsPRM;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMDIMain";
            this.Text = "PRM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnsPRM.ResumeLayout(false);
            this.mnsPRM.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsPRM;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEditStockToolStripMenuItem;
    }
}