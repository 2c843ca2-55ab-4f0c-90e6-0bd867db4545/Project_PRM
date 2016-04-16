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
    public partial class Customer : Form
    {
        public PRM.BusinessAccessLayer.SelfServicebusinessLayer ObjBL = new PRM.BusinessAccessLayer.SelfServicebusinessLayer();
        public SqlCeResultSet rs;
        private static Customer m_SChildform;

        public Customer()
        {
            InitializeComponent();
            LoadSearchItems();
            LoadCustomer();
        }

        public static Customer GetChildInstance()
        {
            if (m_SChildform == null) //if not created yet, Create an instance
                m_SChildform = new Customer();
            return m_SChildform;  //just created or created earlier.Return it
        }

        private void LoadSearchItems()
        {
            //BindingSource m_bindResults = new BindingSource();

            Hashtable m_results = new Hashtable();
            m_results.Add("PostalCode", "PostalCode");
            m_results.Add("Website", "Website");
            m_results.Add("Email", "Email");
            m_results.Add("Country", "Country");
            m_results.Add("City", "City");
            m_results.Add("WorkPhone", "WorkPhone");
            m_results.Add("MobilePhone", "MobilePhone");
            m_results.Add("Name", "Name");

          


            //m_bindResults.DataSource = m_results;

            ArrayList arr_list = new ArrayList(m_results);
            cbSearch.ValueMember = "Key";
            cbSearch.DisplayMember = "Value";
            cbSearch.DataSource = arr_list;

        }

        private void LoadCustomer()
        {
            string Table = "Customer";

            Hashtable RsOptions = new Hashtable();
            RsOptions.Add("Updatable", "Y");
            RsOptions.Add("Scrollable", "Y");
            RsOptions.Add("Sensitive", "Y");
            RsOptions.Add("Insensitive", "Y");
            RsOptions.Add("None", "Y");

            StringBuilder Fields = new StringBuilder();
            Fields.AppendLine("Name,MobilePhone,WorkPhone,StreetAddress1,StreetAddress2,Email,Website,City,Country,PostalCode,CustomerId");

            StringBuilder Condition = new StringBuilder();

            string SearchItem = txtSearch.Text.ToString();
            if (SearchItem != "")
            {
                Condition.AppendLine(cbSearch.SelectedValue + " LIKE '" + SearchItem + "%'");
            }

            rs = ObjBL.SelectQuerySqlCe(Table, Fields, Condition, RsOptions);
            dtCustomer.DataSource = rs;

            dtCustomer.Columns["CustomerId"].Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCustomer();
        }
    }
}
