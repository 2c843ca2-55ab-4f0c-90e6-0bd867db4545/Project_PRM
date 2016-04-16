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
using Microsoft.Reporting;
using Microsoft.ReportingServices;


namespace PRM
{
    public partial class Products : Form
    {
        public PRM.BusinessAccessLayer.SelfServicebusinessLayer ObjBL = new PRM.BusinessAccessLayer.SelfServicebusinessLayer();
        public static int FormLoad;
        public SqlCeResultSet rs;
        private static Products m_SChildform;

        public static Products GetChildInstance()
        {
            if (m_SChildform == null) //if not created yet, Create an instance
                m_SChildform = new Products();
            return m_SChildform;  //just created or created earlier.Return it
        }

        public Products()
        {

            InitializeComponent();


            DataTable InvoiceTable = new DataTable();

            InvoiceTable.Columns.Add("ProductName", Type.GetType("System.String"));
            InvoiceTable.Columns.Add("ProductDescription", Type.GetType("System.String"));
            InvoiceTable.Columns.Add("ProductId",typeof(int));

            DataRow dr = InvoiceTable.NewRow();
            dr["ProductName"] = "Manjesh";
            dr["ProductDescription"] = "Creative";
            dr["ProductId"] = 123;
            InvoiceTable.Rows.Add(dr);

            DataRow dr1 = InvoiceTable.NewRow();
            dr1["ProductName"] = "Manjesh";
            dr1["ProductDescription"] = "Creative";
            dr1["ProductId"] = 123;
            InvoiceTable.Rows.Add(dr1);

            //Microsoft.Reporting.WinForms.ReportDataSource rdl = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1_InvoiceTable", InvoiceTable);
            //reportViewer1.LocalReport.DataSources.Add(rdl);
            //reportViewer1.LocalReport.Refresh();

            ProductBindingSource.DataSource = InvoiceTable;
            this.reportViewer1.RefreshReport();

            FormLoad = 0;
            LoadProductCategory();
            LoadSearchItems();

        }

        private void LoadSearchItems()
        {
            string[] arr = new string[]{"ProductName","ProductDescription","PurchaseUOM","SalesUOM","UOMConverter"};
            cbSearch.DataSource = arr;

        }

        public void LoadProductCategory()
        {
            cbProductCategory.DataSource = null;

            string Table = "ProductCategory";

            Hashtable RsOptions = new Hashtable();
            RsOptions.Add("Updatable", "Y");
            RsOptions.Add("Scrollable", "Y");
            RsOptions.Add("Sensitive", "Y");
            RsOptions.Add("Insensitive", "N");
            RsOptions.Add("None", "N");

            StringBuilder Fields = new StringBuilder();
            Fields.AppendLine("CategoryId,Name");

            StringBuilder Condition = new StringBuilder();

            SqlCeResultSet rsProductCategory = ObjBL.SelectQuerySqlCe(Table, Fields, Condition, RsOptions);
            cbProductCategory.DataSource = null;
            cbProductCategory.DataSource = rsProductCategory;
            cbProductCategory.DisplayMember="Name";
            cbProductCategory.ValueMember="CategoryId";

            cbProductCategory.Refresh();
        }

        private void LoadProducts()
        {
            string Table = "Product";

            Hashtable RsOptions = new Hashtable();
            RsOptions.Add("Updatable", "Y");
            RsOptions.Add("Scrollable", "Y");
            RsOptions.Add("Sensitive", "Y");
            RsOptions.Add("Insensitive", "Y");
            RsOptions.Add("None", "Y");

            StringBuilder Fields = new StringBuilder();
            Fields.AppendLine("ProductName,ProductDescription,PurchaseUOM,SalesUOM,UOMConverter,ProductCategoryId");

            StringBuilder Condition = new StringBuilder();

            if (FormLoad == 0)
            {
                Condition.AppendLine("ProductCategoryId='1'");
                FormLoad++;
            }
            else
            {
                string SearchItem = txtSearch.Text.ToString();

                if (SearchItem == "")
                {
                    Condition.AppendLine("ProductCategoryId='" + cbProductCategory.SelectedValue + "'");
                }
                else
                {
                    Condition.AppendLine("ProductCategoryId='" + cbProductCategory.SelectedValue + "' and " + cbSearch.SelectedValue + " LIKE '" + SearchItem + "%'");
                }
            }
            
            rs = ObjBL.SelectQuerySqlCe(Table, Fields, Condition, RsOptions);
            dtProducts.DataSource = rs;

            dtProducts.Columns["ProductCategoryId"].Visible = false;
           

         

           

             //SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions. | ResultSetOptions.Scrollable);

            //  //SqlCeUpdatableRecord rec = rs.CreateRecord();

            //  //rec.SetString(0, "Sample text");
            //  ////rec.SetInt32(0, 32);
            //  ////rec.SetDecimal(1, (decimal)44.66);
            //  //rec.SetInt32(1, 32);
            //  //rec.SetString(2, "Sample text");


            //  //rs.Insert(rec);

            //  int ordProductName = rs.GetOrdinal("ProductName");

            //  int ordProductDescription = rs.GetOrdinal("ProductDescription");



            //// Hold the output

            //StringBuilder output = new StringBuilder();



            //// Read the first record and get it’s data

            ////rs.ReadFirst();

            ////output.AppendLine(rs.GetString(ordProductName)

            ////  + " " + rs.GetString(ordProductDescription));



            //// Now read thru the rest of the records.

            //// When there’s no more data, .Read returns false.

            //while (rs.Read())
            //{

            //    output.AppendLine(rs.GetString(ordProductName)

            //    + " " + rs.GetString(ordProductDescription));

            //}



            //// Set the output in the label

            //MessageBox.Show(output.ToString());


            

            //Hashtable hashtable = new Hashtable();
            //hashtable.Add("Test", "dfd");
            //hashtable.Add("Perimeter", 55);
            //hashtable.Add("Mortgage", 540);



            //cmd.Dispose();
            //sqlCon.Close();

        }

        public void cbProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           dtProducts.Rows[e.RowIndex].Cells["ProductCategoryId"].Value = cbProductCategory.SelectedValue.ToString();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            //MessageBox.Show("Error happened " + anError.Context.ToString());

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("ProductName is a required field");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.Product' table. You can move, or remove it, as needed.
            this.ProductTableAdapter.Fill(this.DataSet1.Product);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void ProductsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

     
        
    }
}
