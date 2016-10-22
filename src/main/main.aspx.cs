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
            SqlCommand getItems = new SqlCommand("SELECT * FROM dbo.[ItemSale] i, dbo.[FollowerList] f WHERE i.UserID = f.UserID AND f.FollowerID = " + Session["userid"] + " AND i.TimeEnd >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ORDER BY Time DESC;", conn);
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
            SqlCommand getGlobalItems = new SqlCommand("SELECT TOP 100 * FROM dbo.[ItemSale] WHERE Status = 1 AND TimeEnd >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ORDER BY Time DESC", conn);
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double price = Convert.ToDouble(e.Row.Cells[6].Text);
                DateTime start = Convert.ToDateTime(e.Row.Cells[7].Text);
                DateTime end = Convert.ToDateTime(e.Row.Cells[8].Text);
                double difference = Convert.ToDouble(e.Row.Cells[9].Text);
                int soldCount = Convert.ToInt32(e.Row.Cells[10].Text);
                double endPrice = Convert.ToDouble(e.Row.Cells[11].Text);
                int quantity = Convert.ToInt32(e.Row.Cells[5].Text);
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
                e.Row.Cells[11].Visible = false;

                double total = 0;
                if (soldCount == 0)
                {
                    //(Starting Price)-((Starting Price)-(Ending Price))*{((Current Time)-(Starting Time))/(Ending Time)-(Starting Time))}
                    total = (price - (price - endPrice) * ((DateTime.Now.Subtract(start).TotalHours) / end.Subtract(start).TotalHours));
                }
                else
                {
                    //(Starting Price)-((Starting Price)-(Ending Price))*{((Current Time)-(Starting Time))/(Ending Time)-(Starting Time))} 
                    //      +((Available quantity)-(Quantity sold))*Price Difference

                    total = (price - (price - endPrice) * ((DateTime.Now.Subtract(start).TotalHours) / end.Subtract(start).TotalHours) + (quantity - soldCount) * difference);
                }

                e.Row.Cells[6].Text = Math.Round(total, 2).ToString();
                

            }
        }

        protected void GlobalItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double price = Convert.ToDouble(e.Row.Cells[6].Text);
                DateTime start = Convert.ToDateTime(e.Row.Cells[7].Text);
                DateTime end = Convert.ToDateTime(e.Row.Cells[8].Text);
                double difference = Convert.ToDouble(e.Row.Cells[9].Text);
                int soldCount = Convert.ToInt32(e.Row.Cells[10].Text);
                double endPrice = Convert.ToDouble(e.Row.Cells[11].Text);
                int quantity = Convert.ToInt32(e.Row.Cells[5].Text);
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
                e.Row.Cells[11].Visible = false;

                double total = 0;
                if (soldCount == 0)
                {
                    total = (price - (price - endPrice) * ((DateTime.Now.Subtract(start).TotalHours) / end.Subtract(start).TotalHours));
                }
                else
                {
                    total = (price - (price - endPrice) * ((DateTime.Now.Subtract(start).TotalHours) / end.Subtract(start).TotalHours) + (quantity-soldCount)*difference); 
                }
                

                e.Row.Cells[6].Text = Math.Round(total, 2).ToString();
            }
        }
    }
}