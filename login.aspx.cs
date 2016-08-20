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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
          protected void login_Click(object sender,  EventArgs e)
          {
              bool isCorrect = false;
              bool disabled = false;

              try
              {
                  using (SqlConnection conn = new SqlConnection(Shared.SqlConnString))
                  {
                      conn.Open();
                    MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                    Byte[] hashedBytes;
                    UTF32Encoding encoder = new UTF32Encoding();

                    hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(txtbox_passw.Text));

                    using (SqlCommand cmd = new SqlCommand("SELECT * from dbo.[UserInfo] where Email=@UserEmail and Password=@Password;",conn))
                    {
                        cmd.Parameters.AddWithValue("@UserEmail", txtbox_email.Text);
                        cmd.Parameters.AddWithValue("@Password", hashedBytes);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while(dr.Read())
                            {
                                isCorrect = true;

                                string username = dr["UserName"].ToString();
                                string userid = dr["UserID"].ToString();

                                Session["username"] = username;
                                Session["userID"] = userid;
                            }
                        }
                    }

                }

                    if (isCorrect)
                    {
                        Response.Redirect("~/src/main/main.aspx");
                    }
                    else
                    {
                        lblLoginStatusMsg.ForeColor = System.Drawing.Color.Red;
                        lblLoginStatusMsg.Text = "Login credentials incorrect";
                    }
            }
            catch (Exception ex)
            {
                Response.Write("An unknown error occured, please contact the administrator.");
            }
           
          }
         
    }
}