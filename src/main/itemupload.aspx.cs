using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Configuration;
using System.Text;

namespace AutoPriceMobile.src.main
{
    public partial class itemupload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["userID"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            double itemPrice = 0;
            bool parsed = Double.TryParse(add_itemPrice.Text, out itemPrice);

            int quantity = 0;
            bool parsed2 = Int32.TryParse(add_itemQty.Text, out quantity);

            int timespan = 0;
            bool parsed3 = Int32.TryParse(add_itemDuration.Text, out timespan);

            double minPrice = 0;
            bool parsed4 = Double.TryParse(add_minPrice.Text, out minPrice);

            double priceDiff = 0;
            bool parsed5 = Double.TryParse(add_priceDiff.Text, out priceDiff);

            if(!add_itemImg.HasFile)
            {
                lblText.Text = "Please add a photo of the item.";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if(add_itemDesc.Text == "" || add_itemName.Text == "")
            {
                lblText.Text = "Please add a name and description for the item.";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if(add_itemPrice.Text == "" || add_itemQty.Text == "")
            {
                lblText.Text = "Please add a price and quantity for the item.";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if(add_priceDiff.Text == "" || add_minPrice.Text == "")
            {
                lblText.Text = "Please provide your price difference and end price for the item.";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if(add_itemDuration.Text == "")
            {
                lblText.Text = "Please add a valid duration for the item.";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if(!parsed)
            {
                lblText.Text = "Please enter a valid input for the price (numbers only).";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if(!parsed2)
            {
                lblText.Text = "Please enter a valid input for the quantity (numbers only).";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if (!parsed3)
            {
                lblText.Text = "Please enter a valid input for the duration (numbers only).";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if (!parsed4)
            {
                lblText.Text = "Please enter a valid input for the end price (numbers only).";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if (!parsed5)
            {
                lblText.Text = "Please enter a valid input for the price difference (numbers only).";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if(timespan <= 0)
            {
                lblText.Text = "Please enter a positive value for the duration (no value less than 0).";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if(itemPrice <= 0)
            {
                lblText.Text = "Please enter a positive value for the item price (no value less than 0).";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if (minPrice <= 0)
            {
                lblText.Text = "Please enter a positive value for the end price (no value less than 0).";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else if (quantity <= 0)
            {
                lblText.Text = "Please enter a positive value for the quantity (no value less than 0).";
                lblText.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                int status = 0;
                bool check = true;

                HttpPostedFile postedFile = add_itemImg.PostedFile;
                string fileExtension = Path.GetExtension(postedFile.FileName);
                SqlConnection conn = new SqlConnection(Shared.SqlConnString);

                if (add_itemStatus.SelectedValue == "Global")
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }
                //if (priceDiff <= 0)
                //{
                //    priceDiff = priceDiff * -1;
                //    if ((priceDiff * 5) > itemPrice)
                //    {
                //        lblText.Text = "Your price difference cannot be more than 20% of your original price";
                //        lblText.ForeColor = System.Drawing.Color.Red;
                //        check = false;
                //    }
                //    if (minPrice > itemPrice)
                //    {
                //        lblText.Text = "If your price difference is 0 or less, your item price must be higher than your end price";
                //        lblText.ForeColor = System.Drawing.Color.Red;
                //        check = false;
                //    }
                //}
                //else
                //{
                //    if ((priceDiff * 5) > itemPrice)
                //    {
                //        lblText.Text = "Your price difference cannot be more than 20% of your original price";
                //        lblText.ForeColor = System.Drawing.Color.Red;
                //        check = false;
                //    }
                //    if (minPrice < itemPrice)
                //    {
                //        lblText.Text = "If your price difference is positive, your item price must be lower than your end price";
                //        lblText.ForeColor = System.Drawing.Color.Red;
                //        check = false;
                //    }
                //}

                if (check)
                {
                    using (conn)
                    {
                        try
                        {
                            conn.Open();
                            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png")
                            {
                                Stream stream = postedFile.InputStream;
                                BinaryReader reader = new BinaryReader(stream);
                                byte[] imgByte = reader.ReadBytes((int)stream.Length);
                                int duration = Convert.ToInt32(add_itemDuration.Text);

                                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.[ItemSale](ItemName, ItemImage, ItemDescription, UserID, UserName, Quantity, Price, Time, TimeEnd, Status, SoldCount, PriceDiff, MinPrice) VALUES (@ItemName, @ItemImage, @ItemDescription, @UserID, @UserName, @Quantity, @Price, @Time, @TimeEnd, @Status, 0, @PriceDiff, @MinPrice)", conn);
                                cmd.Parameters.AddWithValue("@ItemName", add_itemName.Text);
                                cmd.Parameters.Add("@ItemImage", SqlDbType.VarBinary).Value = imgByte;
                                cmd.Parameters.AddWithValue("@ItemDescription", add_itemDesc.Text);
                                cmd.Parameters.AddWithValue("@UserID", Session["userID"].ToString());
                                cmd.Parameters.AddWithValue("@UserName", Session["username"].ToString());
                                cmd.Parameters.AddWithValue("@Quantity", add_itemQty.Text);
                                cmd.Parameters.AddWithValue("@Price", add_itemPrice.Text);
                                cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt"));
                                cmd.Parameters.AddWithValue("@TimeEnd", DateTime.Now.AddDays(+duration).ToString("yyyy-MM-dd HH:mm:ss tt"));
                                cmd.Parameters.AddWithValue("@Status", status);
                                cmd.Parameters.AddWithValue("@PriceDiff", add_priceDiff.Text);
                                cmd.Parameters.AddWithValue("@MinPrice", add_minPrice.Text);
                                cmd.ExecuteNonQuery();
                                lblText.Text = "Item Successfully Added.";
                                lblText.ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                lblText.Text = "Incorrect Image File Type! Please make sure the image is in .jpg or .png format!";
                                lblText.ForeColor = System.Drawing.Color.Red;
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
                    //lblText.Text = "Your price difference cannot be more than 20% of your original price. Please enter a correct input for End Price";
                    lblText.Text = "An unexpected error has occurred.";
                    lblText.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

    }
}