using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;


namespace AutoPriceMobile
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["userid"] = null;

            RedirectToLogin();
        }

        private void RedirectToLogin()
        {
            /////////////////////////////////////////////////////////////////////
            /// Redirects the user to the SignIn.aspx page after 3 seconds
            /////////////////////////////////////////////////////////////////////

            Response.AddHeader("REFRESH", "0;URL=SignIn.aspx");
        }
    }
}