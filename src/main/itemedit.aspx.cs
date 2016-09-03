﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Drawing;
using System.Data;

namespace AutoPriceMobile.src.main
{
    public partial class itemedit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Session["username"] == null || Session["userID"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else if (Request.QueryString["ItemID"] == null || Request.QueryString["ItemID"] == "")
            {
                Response.Redirect("main.aspx");
            }

            string userID = Session["userID"].ToString();
            SqlConnection sqlConn = new SqlConnection(Shared.SqlConnString);
            using (sqlConn)
            {
                try
                {
                    SqlCommand getUserInfo = new SqlCommand("SELECT UserID FROM dbo.[ItemSale] WHERE ItemID = @ItemID", sqlConn);
                    getUserInfo.Parameters.AddWithValue("@ItemID", Request.QueryString["ItemID"]);
                    sqlConn.Open();

                    SqlDataReader reader = getUserInfo.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            userID = reader[0].ToString();
                        }
                    }
                }
                catch(Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }

            if (userID == Session["userID"].ToString())
            {
                if(!IsPostBack)
                {
                    fillValues();
                }
                
            }
            else
            {
                Response.Redirect("main.aspx");
            }
            
        }

        protected void fillValues()
        {
            SqlConnection sqlConn = new SqlConnection(Shared.SqlConnString);
            using (sqlConn)
            {
                try
                {
                    SqlCommand getPic = new SqlCommand("SELECT ItemImage FROM dbo.[ItemSale] WHERE ItemID=@ItemID", sqlConn);
                    getPic.Parameters.AddWithValue("@ItemID", Request.QueryString["ItemID"]);
                    sqlConn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(getPic);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);

                    if (dataSet.Tables[0].Rows.Count == 1)
                    {
                        Byte[] data = new Byte[0];
                        data = (Byte[])(dataSet.Tables[0].Rows[0]["ItemImage"]);

                        string base64string = Convert.ToBase64String(data);
                        itemimage.ImageUrl = "data:image/png;base64," + base64string;
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

            SqlConnection sqlConn2 = new SqlConnection(Shared.SqlConnString);
            using (sqlConn2)
            {
                try
                {
                    SqlCommand getItemName = new SqlCommand("SELECT ItemName FROM dbo.[ItemSale] WHERE ItemID = @ItemID", sqlConn2);
                    getItemName.Parameters.AddWithValue("@ItemID", Request.QueryString["ItemID"]);
                    sqlConn2.Open();

                    SqlDataReader reader = getItemName.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            edit_itemName.Text = reader[0].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }

            SqlConnection sqlConn3 = new SqlConnection(Shared.SqlConnString);
            using (sqlConn3)
            {
                try
                {
                    SqlCommand getUserInfo = new SqlCommand("SELECT ItemDescription FROM dbo.[ItemSale] WHERE ItemID = @ItemID", sqlConn3);
                    getUserInfo.Parameters.AddWithValue("@ItemID", Request.QueryString["ItemID"]);
                    sqlConn3.Open();

                    SqlDataReader reader = getUserInfo.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            edit_itemDesc.Text = reader[0].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }

            SqlConnection sqlConn4 = new SqlConnection(Shared.SqlConnString);
            using (sqlConn4)
            {
                try
                {
                    SqlCommand getUserInfo = new SqlCommand("SELECT Quantity FROM dbo.[ItemSale] WHERE ItemID = @ItemID", sqlConn4);
                    getUserInfo.Parameters.AddWithValue("@ItemID", Request.QueryString["ItemID"]);
                    sqlConn4.Open();

                    SqlDataReader reader = getUserInfo.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            edit_itemQty.Text = reader[0].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }

            SqlConnection sqlConn5 = new SqlConnection(Shared.SqlConnString);
            using (sqlConn5)
            {
                try
                {
                    SqlCommand getUserInfo = new SqlCommand("SELECT Price FROM dbo.[ItemSale] WHERE ItemID = @ItemID", sqlConn5);
                    getUserInfo.Parameters.AddWithValue("@ItemID", Request.QueryString["ItemID"]);
                    sqlConn5.Open();

                    SqlDataReader reader = getUserInfo.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            edit_itemPrice.Text = reader[0].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }

            int status = 0;
            DateTime end = DateTime.Now;
            SqlConnection sqlConn6 = new SqlConnection(Shared.SqlConnString);
            using (sqlConn6)
            {
                try
                {
                    SqlCommand getUserInfo = new SqlCommand("SELECT Status FROM dbo.[ItemSale] WHERE ItemID = @ItemID", sqlConn6);
                    getUserInfo.Parameters.AddWithValue("@ItemID", Request.QueryString["ItemID"]);
                    sqlConn6.Open();

                    SqlDataReader reader = getUserInfo.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            status = Convert.ToInt32(reader[0].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }

            SqlConnection sqlConn7 = new SqlConnection(Shared.SqlConnString);
            using (sqlConn7)
            {
                try
                {
                    SqlCommand getUserInfo = new SqlCommand("SELECT TimeEnd FROM dbo.[ItemSale] WHERE ItemID = @ItemID", sqlConn7);
                    getUserInfo.Parameters.AddWithValue("@ItemID", Request.QueryString["ItemID"]);
                    sqlConn7.Open();

                    SqlDataReader reader = getUserInfo.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            end = Convert.ToDateTime(reader[0].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }

            if (status == 1)
            {
                edit_itemStatus.SelectedValue = "Global";
            }
            else
            {
                edit_itemStatus.SelectedValue = "Friends Only";
            }

            double duration = (end - DateTime.Now).TotalDays;

            if (duration < 0)
            {
                edit_itemDuration.Text = "0";
            }
            else
            {
                Math.Round(duration, 2);
                edit_itemDuration.Text = duration.ToString("#.##");
            }

        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            double parseValue = 0;
            bool parsed = Double.TryParse(edit_itemPrice.Text, out parseValue);

            int parseValue2 = 0;
            bool parsed2 = Int32.TryParse(edit_itemQty.Text, out parseValue2);

            double parseValue3 = 0;
            bool parsed3 = Double.TryParse(edit_itemDuration.Text, out parseValue3);

            if (edit_itemDesc.Text == "" || edit_itemName.Text == "")
            {
                lblText.Text = "Please enter a name and description for the item.";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if (edit_itemPrice.Text == "" || edit_itemQty.Text == "")
            {
                lblText.Text = "Please enter a price and quantity for the item.";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if (edit_itemDuration.Text == "")
            {
                lblText.Text = "Please enter a valid duration for the item.";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if (!parsed)
            {
                lblText.Text = "Please enter a valid input for the price (numbers only).";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if (!parsed2)
            {
                lblText.Text = "Please enter a valid input for the quantity (numbers only).";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if (!parsed3)
            {
                lblText.Text = "Please enter a valid input for the duration (numbers only).";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if (Convert.ToDouble(edit_itemDuration.Text) <= 0)
            {
                lblText.Text = "Please enter a positive value for the duration (no value less than 0).";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                int status = 0;
                
                if (edit_itemStatus.SelectedValue == "Global")
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }
                SqlConnection conn = new SqlConnection(Shared.SqlConnString);
                SqlCommand cmd = new SqlCommand("UPDATE dbo.[ItemSale] SET ItemName=@ItemName, ItemDescription=@ItemDescription, UserName=@UserName, Quantity=@Quantity, Price=@Price, Time=@Time, TimeEnd=@TimeEnd, Status=@Status WHERE ItemID=@ItemID", conn);
                cmd.Parameters.AddWithValue("@ItemName", edit_itemName.Text);
                cmd.Parameters.AddWithValue("@ItemDescription", edit_itemDesc.Text);
                cmd.Parameters.AddWithValue("@UserName", Session["username"].ToString());
                cmd.Parameters.AddWithValue("@Quantity", edit_itemQty.Text);
                cmd.Parameters.AddWithValue("@Price", Math.Round(parseValue, 2));
                cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt"));
                cmd.Parameters.AddWithValue("@TimeEnd", DateTime.Now.AddDays(+Convert.ToDouble(edit_itemDuration.Text)).ToString("yyyy-MM-dd HH:mm:ss tt"));
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@ItemID", Request.QueryString["ItemID"].ToString());

                using (conn)
                {
                    try
                    {         
                        if (parsed && parsed2 && parsed3)
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            lblText.Text = "Item Successfully updated.";
                        }
                        else
                        {
                            lblText.Text = "An unexpected error has occured, please contact the administrator for more info.";
                            lblText.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                }
            }
        }
    }
}