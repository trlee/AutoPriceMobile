<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="itemupload.aspx.cs" Inherits="AutoPriceMobile.src.main.itemupload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../Assets/Stylesheets/masterStyle.css" />
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="this_box" style="align-content:center; align-items:center; align-self:center; text-align:center">
		        <h2 >Add an Item</h2>
        <div style="text-align:center">
            <br />
            <asp:Label ID="lblText" Text="" runat="server" ForeColor="Green"></asp:Label> <br />
        </div>
        <asp:Table CssClass="this_table" runat="server" HorizontalAlign="Center">
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell>
                    <h3>
                        Item Name
                    </h3>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="add_itemName" ToolTip="Name" runat="server" placeholder="Name" CssClass="txtbox"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell>
                    <h3>
                        Item Description
                    </h3>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="add_itemDesc" runat="server" TextMode="MultiLine" placeholder="Description" CssClass="txtbox"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell>
                    <h3>
                        Item Image
                    </h3>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:FileUpload ID="add_itemImg" runat="server" AllowMultiple="false" Enabled="true"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell>
                    <h3>
                        Item Price
                    </h3>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="add_itemPrice" runat="server" placeholder="Price" CssClass="txtbox"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell>
                    <h3>
                        End Price
                    </h3>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="add_minPrice" runat="server" placeholder="Enter the final price you wish your price to move towards" CssClass="txtbox"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell>
                    <h3>
                        Price Difference
                    </h3>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="add_priceDiff" runat="server" placeholder="Enter to control your item price over time (max 20%)" CssClass="txtbox"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell>
                    <h3>
                        Item Quantity
                    </h3>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="add_itemQty" runat="server" placeholder="Quantity" CssClass="txtbox"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell>
                    <h3>
                        Item Duration (Days)
                    </h3>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Calendar ID="add_Time" runat="server" SelectedDate='<%#DateTime.Today%>' VisibleDate='<%#DateTime.Today%>'></asp:Calendar>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell>
                    <h3>
                        Post Status
                    </h3>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="add_itemStatus" runat="server">
                        <asp:ListItem Selected="True" Text="Global" Value="Global">
                            Global
                        </asp:ListItem>
                        <asp:ListItem Text="Friends Only" Value="Friends Only">
                            Friends Only
                        </asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableFooterRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <asp:Button ID="submitbtn" runat="server" OnClick="submitbtn_Click" Text="Submit" CssClass="buttons"/>
                </asp:TableCell>
            </asp:TableFooterRow>
        </asp:Table>
    </div>

</asp:Content>
