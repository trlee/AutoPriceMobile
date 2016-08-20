using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Drawing;
using System.Resources;

namespace AutoPriceMobile
{    
    public partial class signup : System.Web.UI.Page
    {
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {   
            MemoryStream ms = new MemoryStream();   
            imageIn.Save(ms,System.Drawing.Imaging.ImageFormat.Gif);
            return  ms.ToArray();   
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void signup_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(Shared.SqlConnString);

            
            bool isValid = true;
                
                try 
                {
                    sqlConn.Open();
                    SqlCommand checkValid = new SqlCommand("SELECT * FROM dbo.[UserInfo] WHERE Email = @Email", sqlConn);
                    checkValid.Parameters.AddWithValue("@Email", txtbox_email.Text);                    

                    using (SqlDataReader reader = checkValid.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            isValid = false;
                        }
                    }

                    if (isValid == true)
                    {
                        MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                        Byte[] hashedBytes;
                        UTF32Encoding encoder = new UTF32Encoding();

                        var bmp = new Bitmap(AutoPriceMobile.Properties.Resources.anon);
                        byte[] imgByte = imageToByteArray(bmp);
                        //MemoryStream ms = new MemoryStream();
                        //bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        //BinaryReader reader = new BinaryReader(ms);
                        //byte[] imgByte = reader.ReadBytes((int)ms.Length);

                        hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(txtbox_passw.Text));

                        string InsertNewUser = "INSERT INTO dbo.[UserInfo](UserName, Email, Password, Avatar) VALUES (@UserName, @Email, @Password, @Avatar)";
                        SqlConnection SqlConn1 = new SqlConnection(Shared.SqlConnString);
                        SqlCommand InsertDB = new SqlCommand(InsertNewUser, SqlConn1);
                        InsertDB.Parameters.AddWithValue("@UserName", txtbox_username.Text);
                        InsertDB.Parameters.AddWithValue("@Email", txtbox_email.Text);
                        InsertDB.Parameters.AddWithValue("@Password", hashedBytes);
                        InsertDB.Parameters.Add("@Avatar", SqlDbType.VarBinary).Value = imgByte;

                        using (SqlConn1)
                        {
                            try
                            {
                                SqlConn1.Open();
                                InsertDB.ExecuteNonQuery();

                                using (SqlCommand cmd = new SqlCommand("SELECT * from dbo.[UserInfo] where Email=@UserEmail and Password=@Password;", SqlConn1))
                                {
                                    cmd.Parameters.AddWithValue("@UserEmail", txtbox_email.Text);
                                    cmd.Parameters.AddWithValue("@Password", hashedBytes);

                                    using (SqlDataReader dr = cmd.ExecuteReader())
                                    {
                                        while (dr.Read())
                                        {
                                            string userID = dr["UserID"].ToString();
                                            string username = dr["UserName"].ToString();

                                            Session["userID"] = userID;
                                            Session["username"] = username;

                                            string followingSelf = "INSERT INTO dbo.[FollowerList](UserID, FollowerID, Status) VALUES (@UserID, @FollowerID, 1)";
                                            SqlConnection SqlConn2 = new SqlConnection(Shared.SqlConnString);
                                            SqlCommand InsertFollowing = new SqlCommand(followingSelf, SqlConn2);
                                            InsertFollowing.Parameters.AddWithValue("@UserID", userID);
                                            InsertFollowing.Parameters.AddWithValue("@FollowerID", userID);

                                            using (SqlConn2)
                                            {
                                                try
                                                {
                                                    SqlConn2.Open();
                                                    InsertFollowing.ExecuteNonQuery();

                                                }
                                                catch (Exception ex)
                                                {
                                                    Response.Write(ex.Message);
                                                }
                                            }
                                        }
                                    }
                                    Response.Redirect("~/src/main/main.aspx");
                                }
                            }
                            catch (Exception ex)
                            {
                                Response.Write(ex.Message);
                            }
                        }
                    }
                    else 
                    {
                        signup_status.Text= "A user with the same email has already been registered.";
                    }
                }
                catch (Exception ex)
                {
                    signup_status.Text = "Unexpected Error, please contact admin!";
                }
            
            
        }
    }
}