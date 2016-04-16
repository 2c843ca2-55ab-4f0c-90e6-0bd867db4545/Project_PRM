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
    public partial class AddToStock : Form
    {

        public PRM.BusinessAccessLayer.SelfServicebusinessLayer ObjBL = new PRM.BusinessAccessLayer.SelfServicebusinessLayer();
        public static int FormLoad;
        private static AddToStock m_SChildform;

        public static AddToStock GetChildInstance()
        {
            if (m_SChildform == null) //if not created yet, Create an instance
                m_SChildform = new AddToStock();
            return m_SChildform;  //just created or created earlier.Return it
        }

        public AddToStock()
        {
            FormLoad = 0;
            InitializeComponent();
            LoadProductCategory();
            
            
        }

        public void LoadProductCategory()
        {
            DataSet ds = new DataSet();
            

            string Table = "ProductCategory";
            StringBuilder Fields = new StringBuilder();
            Fields.AppendLine("CategoryId,Name");
            StringBuilder Condition = new StringBuilder();

            ds = ObjBL.SelectQuerySqlCeDataSet(Table, Fields, Condition);

            cbProductCategory.DataSource = ds.Tables[0];
            cbProductCategory.ValueMember = "CategoryId";
            cbProductCategory.DisplayMember = "Name";
            cbProductCategory.Refresh();
        }

        private void cbProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();


            string Table = "Product";

            StringBuilder Fields = new StringBuilder();
            Fields.AppendLine("ProductId,ProductName");

            StringBuilder Condition = new StringBuilder();

            if (FormLoad == 0)
            {
                Condition.AppendLine("ProductCategoryId='1'");
                FormLoad++;
            }
            else
            Condition.AppendLine("ProductCategoryId='" + cbProductCategory.SelectedValue + "'");


            ds = ObjBL.SelectQuerySqlCeDataSet(Table, Fields, Condition);

            cbProduct.DataSource = ds.Tables[0];
            cbProduct.ValueMember = "ProductId";
            cbProduct.DisplayMember = "ProductName";
            cbProduct.Refresh();
        }

    }
}
