using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;

namespace AutoPriceMobile.src. main
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["userID"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            if (!Page.IsPostBack)
            {
                FillFriendList();
                FillGlobalList();
            }
        }

        protected void FillFriendList()
        {
            SqlConnection conn = new SqlConnection(Shared.SqlConnString);
            SqlCommand getItems = new SqlCommand("SELECT * FROM dbo.[ItemSale] i, dbo.[FollowerList] f WHERE i.UserID = f.UserID AND f.FollowerID = " + Session["userid"] + " AND i.TimeEnd >= '" + DateTime.Now.ToString("HH:mm:ss tt") + "' ORDER BY Time DESC;", conn);
            SqlDataAdapter da = new SqlDataAdapter(getItems);
            DataSet dt = new DataSet();
            da.Fill(dt);
            FriendItems.DataSource = dt;
            FriendItems.DataBind();
            getItems.Dispose();
            conn.Close();
        }

        protected void FillGlobalList()
        {
            SqlConnection conn = new SqlConnection(Shared.SqlConnString);
            SqlCommand getGlobalItems = new SqlCommand("SELECT TOP 100 * FROM dbo.[ItemSale] WHERE Status = 1 AND TimeEnd >= '" + DateTime.Now.ToString("HH:mm:ss tt") + "' ORDER BY Time DESC", conn);
            SqlDataAdapter da = new SqlDataAdapter(getGlobalItems);
            DataSet dt = new DataSet();
            da.Fill(dt);
            GlobalItems.DataSource = dt;
            GlobalItems.DataBind();
            getGlobalItems.Dispose();
            conn.Close();
        }

        protected void GlobalItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
  
        }

        protected void FriendItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void FriendItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void GlobalItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}