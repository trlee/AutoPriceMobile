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
using System.IO;

namespace AutoPriceMobile.src.main
{
    public partial class editProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["userID"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            edit_name.Text = Session["username"].ToString();
            SqlConnection sqlConn = new SqlConnection(Shared.SqlConnString);

            using (sqlConn)
            {
                try
                {
                    SqlCommand getUserInfo = new SqlCommand("SELECT Email FROM dbo.[UserInfo] WHERE UserID = @UserID", sqlConn);
                    getUserInfo.Parameters.AddWithValue("@UserID", Session["userID"].ToString());
                    sqlConn.Open();

                    SqlDataReader reader = getUserInfo.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            edit_email.Text = reader[0].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }

        }

        protected void followingstat_ServerClick(object sender, EventArgs e)
        {

        }

        protected void submitbtn_ServerClick(object sender, EventArgs e)
        {
            if (edit_pass1.Text == "")
            {
                edit_error.Text = "Please enter your old password to save any changes made.";
            }
            else if (edit_name.Text == "" || edit_email.Text == "")
            {
                edit_error.Text = "Please fill in your Username and Email fields.";
            }
            else if(edit_pass2.Text != edit_pass3.Text)
            {
                edit_error.Text = "Please make sure new password matches the confirmed new password.";
            }
            else if ((edit_pass2.Text == "" || edit_pass3.Text == "") && !edit_avatar.HasFile)
            {
                SqlConnection sqlConn = new SqlConnection(Shared.SqlConnString);
                SqlCommand updateProfile = new SqlCommand("UPDATE dbo.[UserInfo] SET UserName = @UserName, Email = @Email WHERE UserID = @UserID", sqlConn);
                updateProfile.Parameters.AddWithValue("@UserName", edit_name.Text);
                updateProfile.Parameters.AddWithValue("@Email", edit_email.Text);
                updateProfile.Parameters.AddWithValue("@UserID", Session["userID"].ToString());

                using (sqlConn)
                {
                    try
                    {
                        sqlConn.Open();
                        updateProfile.ExecuteNonQuery();
                        Session["username"] = edit_name.Text;
                    }
                    catch(Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                }
                Response.Redirect("main.aspx");
                //Response.Redirect("profileView.aspx?ID="+Session["userID"].ToString());

            }
            else if(!edit_avatar.HasFile)
            {
                bool oldPasswordCheck = checkOldPassword(edit_pass1.Text);
                if (oldPasswordCheck == true)
                {
                    MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                    Byte[] hashedBytes;
                    UTF32Encoding encoder = new UTF32Encoding();
                    hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(edit_pass3.Text));

                    SqlConnection sqlConn = new SqlConnection(Shared.SqlConnString);
                    SqlCommand updateProfile = new SqlCommand("UPDATE dbo.[UserInfo] SET UserName = @UserName, Email = @Email, Password = @Password WHERE UserID = @UserID", sqlConn);
                    updateProfile.Parameters.AddWithValue("@UserName", edit_name.Text);
                    updateProfile.Parameters.AddWithValue("@Email", edit_email.Text);
                    updateProfile.Parameters.AddWithValue("@Password", hashedBytes);
                    updateProfile.Parameters.AddWithValue("@UserID", Session["userID"].ToString());

                    using (sqlConn)
                    {
                        try
                        {
                            sqlConn.Open();
                            updateProfile.ExecuteNonQuery();
                            Session["username"] = edit_name.Text;
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);
                        }
                    }
                    Response.Redirect("main.aspx");
                    //Response.Redirect("profileView.apsx?ID=" + Session["userID"].ToString());
                }
                else
                {
                    edit_error.Text = "Please make sure your old password is correct.";
                }
            }
            else if (edit_pass2.Text == "" || edit_pass3.Text == "")
            {
                HttpPostedFile postedFile = edit_avatar.PostedFile;
                Stream stream = postedFile.InputStream;
                BinaryReader reader = new BinaryReader(stream);
                byte[] imgByte = reader.ReadBytes((int)stream.Length);

                SqlConnection sqlConn = new SqlConnection(Shared.SqlConnString);
                SqlCommand updateProfile = new SqlCommand("UPDATE dbo.[UserInfo] SET UserName = @UserName, Email = @Email, Avatar = @Avatar WHERE UserID = @UserID", sqlConn);
                updateProfile.Parameters.AddWithValue("@UserName", edit_name.Text);
                updateProfile.Parameters.AddWithValue("@Email", edit_email.Text);
                updateProfile.Parameters.Add("@Avatar", SqlDbType.VarBinary).Value = imgByte;
                updateProfile.Parameters.AddWithValue("@UserID", Session["userID"].ToString());

                using (sqlConn)
                {
                    try
                    {
                        sqlConn.Open();
                        updateProfile.ExecuteNonQuery();
                        Session["username"] = edit_name.Text;
                        Response.Redirect("main.aspx");
                        //Response.Redirect("profileView.apsx?ID=" + Session["userID"].ToString());
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                }
            }
            else
            {
                bool oldPasswordCheck = checkOldPassword(edit_pass1.Text);
                if (oldPasswordCheck == true)
                {
                    HttpPostedFile postedFile = edit_avatar.PostedFile;
                    Stream stream = postedFile.InputStream;
                    BinaryReader reader = new BinaryReader(stream);
                    byte[] imgByte = reader.ReadBytes((int)stream.Length);

                    MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                    Byte[] hashedBytes;
                    UTF32Encoding encoder = new UTF32Encoding();
                    hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(edit_pass3.Text));

                    SqlConnection sqlConn = new SqlConnection(Shared.SqlConnString);
                    SqlCommand updateProfile = new SqlCommand("UPDATE dbo.[UserInfo] SET UserName = @UserName, Email = @Email, Password = @Password, Avatar = @Avatar WHERE UserID = @UserID", sqlConn);
                    updateProfile.Parameters.AddWithValue("@UserName", edit_name.Text);
                    updateProfile.Parameters.AddWithValue("@Email", edit_email.Text);
                    updateProfile.Parameters.AddWithValue("@Password", hashedBytes);
                    updateProfile.Parameters.Add("@Avatar", SqlDbType.VarBinary).Value = imgByte;
                    updateProfile.Parameters.AddWithValue("@UserID", Session["userID"].ToString());

                    using (sqlConn)
                    {
                        try
                        {
                            sqlConn.Open();
                            updateProfile.ExecuteNonQuery();
                            Session["username"] = edit_name.Text;
                            Response.Redirect("main.aspx");
                            //Response.Redirect("profileView.apsx?ID=" + Session["userID"].ToString());
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);
                        }
                    }
                }
                else
                {
                    edit_error.Text = "Please make sure your old password is correct.";
                }
                
            }
        }

        protected void cancel_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("profileView.aspx?ID=" + Session["userID"].ToString());
        }

        protected bool checkOldPassword(string oldPassword)
        {
            bool isCorrect = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(Shared.SqlConnString))
                {
                    conn.Open();
                    MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                    Byte[] hashedBytes;
                    UTF32Encoding encoder = new UTF32Encoding();

                    hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(oldPassword));

                    using (SqlCommand cmd = new SqlCommand("SELECT * from dbo.[UserInfo] where UserID=@UserID and Password=@Password;", conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", Session["userID"].ToString());
                        cmd.Parameters.AddWithValue("@Password", hashedBytes);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                isCorrect = true;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("An unknown error occured, please contact the administrator.");
            }
            return isCorrect;
        }
        
    }
}