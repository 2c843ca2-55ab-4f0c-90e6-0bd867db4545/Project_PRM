using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Collections;

namespace PRM
{
    public partial class ProductCategory : Form
    {
        public PRM.BusinessAccessLayer.SelfServicebusinessLayer ObjBL = new PRM.BusinessAccessLayer.SelfServicebusinessLayer();
        public SqlCeResultSet rs;
        private static ProductCategory m_SChildform;

        //private Products objFormProduct;
        //private Products ObjFormProduct
        //{
        //    get
        //    {
        //        if (objFormProduct == null)
        //            objFormProduct = new Products();
        //        return objFormProduct;
        //    }

        //}


        public static ProductCategory GetChildInstance()
        {
            if (m_SChildform == null) //if not created yet, Create an instance
                m_SChildform = new ProductCategory();
            return m_SChildform;  //just created or created earlier.Return it
        }

        public ProductCategory()
        {
            InitializeComponent();
            LoadSearchItems();
            LoadProductCategory();
        }

        private void LoadSearchItems()
        {
            //BindingSource m_bindResults = new BindingSource();

            Hashtable m_results = new Hashtable();
            m_results.Add("Description", "Description");
            m_results.Add("Name", "Name");


            //m_bindResults.DataSource = m_results;

            ArrayList arr_list = new ArrayList(m_results);
            cbSearch.ValueMember = "Key";
            cbSearch.DisplayMember = "Value";
            cbSearch.DataSource = arr_list;

        }

        private void LoadProductCategory()
        {
            string Table = "ProductCategory";

            Hashtable RsOptions = new Hashtable();
            RsOptions.Add("Updatable", "Y");
            RsOptions.Add("Scrollable", "Y");
            RsOptions.Add("Sensitive", "Y");
            RsOptions.Add("Insensitive", "Y");
            RsOptions.Add("None", "Y");

            StringBuilder Fields = new StringBuilder();
            Fields.AppendLine("Name,Description,CategoryId");

            StringBuilder Condition = new StringBuilder();

            string SearchItem = txtSearch.Text.ToString();
            if (SearchItem != "")
            {
                Condition.AppendLine(cbSearch.SelectedValue + " LIKE '" + SearchItem + "%'");
            }

            rs = ObjBL.SelectQuerySqlCe(Table, Fields, Condition, RsOptions);
            dtProductCategory.DataSource = rs;

            dtProductCategory.Columns["CategoryId"].Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProductCategory();
        }


        private void dtProductCategory_Leave(object sender, EventArgs e)
        {
            Products objfrmSChild1 = Products.GetChildInstance();
            objfrmSChild1.LoadProductCategory();

            AddToStock objfrmSChild2 = AddToStock.GetChildInstance();
            objfrmSChild2.LoadProductCategory();
        }



    }
}
