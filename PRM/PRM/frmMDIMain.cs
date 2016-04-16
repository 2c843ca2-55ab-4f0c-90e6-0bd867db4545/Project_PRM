using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PRM
{
    public partial class frmMDIMain : Form
    {
        public frmMDIMain()
        {
            InitializeComponent();
        }

        //private void CloseChildMDI()
        //{
        //    for (int i = 0; i < MdiChildren.Length; i++)
        //    {
        //        if (this.ActiveMdiChild != MdiChildren[i])
        //        {
        //            MdiChildren[i].Close();
        //        }
        //    }
        //}


        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CloseChildMDI();
            Products objfrmSChild = Products.GetChildInstance();
            objfrmSChild.MdiParent = this;
            objfrmSChild.WindowState = FormWindowState.Maximized;
            objfrmSChild.Dock = DockStyle.Fill;
            objfrmSChild.Show();
            objfrmSChild.BringToFront();  
        }

        private void productCategoryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //CloseChildMDI();
            ProductCategory objfrmSChild = ProductCategory.GetChildInstance();
            objfrmSChild.MdiParent = this;
            objfrmSChild.WindowState = FormWindowState.Maximized;
            objfrmSChild.Dock = DockStyle.Fill;
            objfrmSChild.Show();
            objfrmSChild.BringToFront();

        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer objfrmSChild = Customer.GetChildInstance();
            objfrmSChild.MdiParent = this;
            objfrmSChild.WindowState = FormWindowState.Maximized;
            objfrmSChild.Dock = DockStyle.Fill;
            objfrmSChild.Show();
            objfrmSChild.BringToFront();
        }

        private void addEditStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddToStock objfrmSChild = AddToStock.GetChildInstance();
            objfrmSChild.MdiParent = this;
            objfrmSChild.WindowState = FormWindowState.Maximized;
            objfrmSChild.Dock = DockStyle.Fill;
            objfrmSChild.Show();
            objfrmSChild.BringToFront();
        }
    }
}
