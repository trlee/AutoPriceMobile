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

namespace AutoPriceMobile.src.main
{
    public partial class searchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["userID"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else if(Request.QueryString["q"] == null)
            {
                Response.Redirect("main.aspx");
            }
            if (!Page.IsPostBack)
            {
                int wordCount = 0;
                string q = Request.QueryString["q"];
                char[] queryWord = new char[20];
                string keyword;
                int x = 0;
                bool isWord = false;
                int endLine = q.Length - 1;
                for (int i = 0; i < q.Length; i++)
                {
                    if (Char.IsLetter(q.ElementAt(i)) && i != endLine)
                    {
                        isWord = true;
                        queryWord[x] = q.ElementAt(i);
                        x++;
                    }
                    else if(!Char.IsLetter(q.ElementAt(i)) && isWord)
                    {
                        isWord = false;
                        keyword = new string(queryWord);
                        wordCount++;
                        x = 0;
                    }
                    else if (Char.IsLetter(q.ElementAt(i)) && i == endLine)
                    {
                        wordCount++;
                        x = 0;
                    }
                }

                FillUserResults();
                FillItemResults();
            }
        }

        protected void FillUserResults()
        {
            SqlConnection conn = new SqlConnection(Shared.SqlConnString);
            SqlCommand getUsers = new SqlCommand("SELECT * FROM dbo.[UserInfo] WHERE UserName LIKE '%" + Request.QueryString["q"] +"%' OR Email LIKE '%" + Request.QueryString["q"] + "%'", conn);
            //getUsers.Parameters.AddWithValue("@param", Request.QueryString["q"]);
            SqlDataAdapter da = new SqlDataAdapter(getUsers);
            DataSet dt = new DataSet();
            da.Fill(dt);
            UserResults.DataSource = dt;
            UserResults.DataBind();
            getUsers.Dispose();
            conn.Close();
        }

        protected void FillItemResults()
        {
            SqlConnection conn = new SqlConnection(Shared.SqlConnString);
            SqlCommand getItems = new SqlCommand("SELECT * FROM [dbo].ItemSale WHERE ItemName LIKE '%" + Request.QueryString["q"] + "%' OR ItemDescription LIKE '%" + Request.QueryString["q"] + "%' OR UserName LIKE '%" + Request.QueryString["q"] + "%' AND Status = 1", conn);
            //getItems.Parameters.AddWithValue("@param", Request.QueryString["q"]);
            SqlDataAdapter da = new SqlDataAdapter(getItems);
            DataSet dt = new DataSet();
            da.Fill(dt);
            ItemResults.DataSource = dt;
            ItemResults.DataBind();
            getItems.Dispose();
            conn.Close();
        }

        protected void UserResults_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void UserResults_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void ItemResults_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ItemResults_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}