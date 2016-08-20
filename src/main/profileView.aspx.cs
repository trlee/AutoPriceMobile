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
using System.Drawing;
using System.IO;

namespace AutoPriceMobile.src.main
{
    public partial class profileView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["userID"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else if (Request.QueryString["ID"] == null || Request.QueryString["ID"] == "")
            {
                Response.Redirect("main.aspx");
            }
            loadStatus();           

        }

        protected void loadStatus()
        {
            if (Request.QueryString["ID"] != Session["userID"].ToString())
            {
                Edit.Visible = false;
            }
            SqlConnection sqlConn3 = new SqlConnection(Shared.SqlConnString);

            using (sqlConn3)
            {
                try
                {
                    SqlCommand getUserInfo = new SqlCommand("SELECT UserName FROM dbo.[UserInfo] WHERE UserID = @UserID", sqlConn3);
                    getUserInfo.Parameters.AddWithValue("@UserID", Request.QueryString["ID"]);
                    sqlConn3.Open();

                    SqlDataReader reader = getUserInfo.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            username_label.Text = reader[0].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }

            SqlConnection sqlConn = new SqlConnection(Shared.SqlConnString);
            using (sqlConn)
            {
                try
                {
                    SqlCommand getUserInfo = new SqlCommand("SELECT Email FROM dbo.[UserInfo] WHERE UserID = @UserID", sqlConn);
                    getUserInfo.Parameters.AddWithValue("@UserID", Request.QueryString["ID"]);
                    sqlConn.Open();

                    SqlDataReader reader = getUserInfo.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            email_label.Text = reader[0].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }

            SqlConnection sqlConn1 = new SqlConnection(Shared.SqlConnString);
            using (sqlConn1)
            {
                try
                {
                    SqlCommand getFollower = new SqlCommand("SELECT UserID FROM dbo.[FollowerList] WHERE FollowerID = @FollowerID AND UserID = @UserID", sqlConn1);
                    getFollower.Parameters.AddWithValue("@FollowerID", Session["userID"].ToString());
                    getFollower.Parameters.AddWithValue("@UserID", Request.QueryString["ID"]);
                    sqlConn1.Open();

                    SqlDataReader reader = getFollower.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader[0].ToString() == Session["userID"].ToString())
                            {
                                follow_label.Text = "Self";
                                friends_label.Text = "Self";
                                followingstat.Text = "Followed";
                            }
                            else
                            {
                                follow_label.Text = "Yes";
                                friends_label.Text = "Yes";
                                followingstat.Text = "Unfollow?";
                            }
                        }
                    }
                    else
                    {
                        follow_label.Text = "No";
                        friends_label.Text = "No";
                        followingstat.Text = "Follow Friend?";
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            }

            SqlConnection sqlConn2 = new SqlConnection(Shared.SqlConnString);
            using (sqlConn2)
            {
                try
                {
                    SqlCommand getAvatar = new SqlCommand("SELECT Avatar FROM dbo.[UserInfo] WHERE UserID=@UserID", sqlConn2);
                    getAvatar.Parameters.AddWithValue("@UserID", Request.QueryString["ID"]);
                    sqlConn2.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(getAvatar);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);

                    if (dataSet.Tables[0].Rows.Count == 1)
                    {
                        Byte[] data = new Byte[0];
                        data = (Byte[])(dataSet.Tables[0].Rows[0]["Avatar"]);

                        string base64string = Convert.ToBase64String(data);
                        avatar.ImageUrl = "data:image/png;base64," + base64string;
                    }
                    else
                    {
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
            SqlConnection conn = new SqlConnection(Shared.SqlConnString);
            using (conn)
            {
                try
                {
                    SqlCommand getFollower = new SqlCommand("SELECT UserID FROM dbo.[FollowerList] WHERE FollowerID = @FollowerID AND UserID = @UserID", conn);
                    getFollower.Parameters.AddWithValue("@FollowerID", Session["userID"].ToString());
                    getFollower.Parameters.AddWithValue("@UserID", Request.QueryString["ID"]);
                    conn.Open();

                    SqlDataReader reader = getFollower.ExecuteReader();
                    
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader[0].ToString() == Session["userID"].ToString())
                            {
                                followStatus.Text = "Cannot unfollow yourself!";
                                followStatus.ForeColor = System.Drawing.Color.Red;
                                loadStatus();
                            }
                            else
                            {
                                conn.Close();
                                SqlConnection conn1 = new SqlConnection(Shared.SqlConnString);
                                SqlCommand removeFollower = new SqlCommand("DELETE FROM dbo.[FollowerList] WHERE FollowerID = @FollowerID AND UserID = @UserID", conn1);
                                removeFollower.Parameters.AddWithValue("@FollowerID", Session["userID"].ToString());
                                removeFollower.Parameters.AddWithValue("@UserID", Request.QueryString["ID"]);
                                
                                using (conn1)
                                {
                                   conn1.Open();
                                   removeFollower.ExecuteNonQuery();
                                   followStatus.Text = "Friend unfollowed!";
                                   loadStatus();    
                                }

                            }
                        }
                        
                    }
                    else
                    {
                        conn.Close();
                        SqlCommand addFollower = new SqlCommand("INSERT INTO dbo.[FollowerList](UserID, FollowerID) VALUES (@UserID, @FollowerID)", conn);
                        addFollower.Parameters.AddWithValue("@FollowerID", Session["userID"].ToString());
                        addFollower.Parameters.AddWithValue("@UserID", Request.QueryString["ID"]);

                        using (conn)
                        {
                            try
                            {
                                conn.Open();
                                addFollower.ExecuteNonQuery();
                                followStatus.Text = "Friend followed!";
                                loadStatus();
                                
                            }
                            catch (Exception ex)
                            {
                                Response.Write(ex.ToString());
                            }
                        }

                        
                        
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

    }
}