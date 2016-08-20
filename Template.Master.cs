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

namespace AutoPriceMobile
{
    public partial class Template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null || Session["userID"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
            }
            if (Session["username"] == null || Session["userID"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            if (Session["username"] != null)
            {
                HyperLink2.NavigateUrl = "~/src/main/profileView.aspx?ID="+ Session["userID"] +"";
                welcome_msg.Text = "Welcome, <strong>" + Session["username"] + "</strong>!!";
            }
        }

        protected void searchSubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect("searchResults.aspx?q="+searchbox.Text);
        }

    }
}