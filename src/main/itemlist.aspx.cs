using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Configuration;

namespace AutoPriceMobile.src.main
{
    public partial class itemlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["userID"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            if(!IsPostBack)
            {
                FillItemList();
            }
        }

        protected void FillItemList() 
        {
            SqlConnection sqlConn = new SqlConnection(Shared.SqlConnString);
            SqlCommand getItems = new SqlCommand("SELECT * FROM dbo.[ItemSale] WHERE UserID = " + Session["userid"] + "", sqlConn);
            SqlDataAdapter da = new SqlDataAdapter(getItems);
            DataSet dt = new DataSet();
            da.Fill(dt);
            ItemList.DataSource = dt;
            ItemList.DataBind();
            getItems.Dispose();
            sqlConn.Close();
        }

        protected void submit_quickadd_Click(object sender, EventArgs e)
        {
            
        }

        protected void ItemList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(Shared.SqlConnString);
            SqlCommand deleteItem = new SqlCommand("DELETE FROM dbo.[ItemSale] WHERE StockName = @StockName AND StockDescription = @StockDescription AND Time = @Time", sqlConn);
            deleteItem.Parameters.AddWithValue("@StockName", ItemList.Rows[e.RowIndex].Cells[0].Text);
            deleteItem.Parameters.AddWithValue("@StockDescription", ItemList.Rows[e.RowIndex].Cells[2].Text);
            deleteItem.Parameters.AddWithValue("@Time", ItemList.Rows[e.RowIndex].Cells[7].Text);

            using (sqlConn)
            {
                try
                {
                    sqlConn.Open();
                    deleteItem.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }

            FillItemList();
        }

        protected void addItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("itemupload.aspx");
        }
    }
}