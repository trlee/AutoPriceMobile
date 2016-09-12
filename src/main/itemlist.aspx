<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="itemlist.aspx.cs" Inherits="AutoPriceMobile.src.main.itemlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../Assets/Stylesheets/masterStyle.css" />
    <link rel="stylesheet" href="../../Assets/Stylesheets/itemlist.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="this_box">
    <h2>
        My Pending Items
    </h2>
    <fieldset>
        <asp:GridView ID="ItemList" runat="server" DataKeyNames="UserID" OnRowDeleting="ItemList_RowDeleting" AutoGenerateColumns="false" EmptyDataText="There are no items to display. Please check back later!" RowStyle-HorizontalAlign="Center" GridLines="None" Width="1300px">
            <AlternatingRowStyle BackColor="White" Height="50px"/>
            <Columns>
                <asp:BoundField DataField="ItemName" HeaderText="Item Name" SortExpression="ItemName" ItemStyle-Width="100px" />
                <asp:TemplateField HeaderText="Item Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="300px" Width="300px" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ItemImage")) %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ItemDescription" HeaderText="Item Description" SortExpression="ItemDescription" ItemStyle-Width="300px" />
                <asp:BoundField DataField="UserID" ItemStyle-Width="200px" Visible="false"></asp:BoundField>
                <asp:BoundField DataField="UserName" HeaderText="User" SortExpression="UserName" ItemStyle-Width="100px" Visible="false"/>
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" ItemStyle-Width="100px" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" ItemStyle-Width="100px" />
                <asp:BoundField DataField="Time" HeaderText="Start Time" SortExpression="Time" ItemStyle-Width="100px" />
                <asp:BoundField DataField="TimeEnd" HeaderText="End Time" SortExpression="TimeEnd" ItemStyle-Width="100px" />
                <asp:BoundField DataField="Status" ItemStyle-Width="200px" Visible="false"></asp:BoundField>
                <asp:BoundField DataField="PriceDiff" HeaderText="Price Difference" SortExpression="PriceDiff" ItemStyle-Width="100px" Visible="true"/>
                <asp:BoundField DataField="SoldCount" HeaderText="Quantity Sold" SortExpression="SoldCount" ItemStyle-Width="100px" Visible="true" />
                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="ItemID" DataNavigateUrlFormatString="~/src/main/itemedit.aspx?ItemID={0}" ItemStyle-Width="100px"/>
                <asp:TemplateField>
			            <ItemTemplate >
				            <asp:LinkButton ID="Delete" runat="server" CommandName="Delete"
				            OnClientClick="return confirm('Are you sure you want to delete this item?');">Delete
				            </asp:LinkButton>
			            </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#FFFFFF" Font-Bold="True" ForeColor="#6BB9F0" height="30px"/>
            <RowStyle BackColor="#E3EAEB" height="300px"/>
        </asp:GridView>
    </fieldset>

        <div style="align-content:center" align="center">
            <asp:Button ID="addItem" runat="server" OnClick="addItem_Click" CssClass="buttons" Text="Add Item"/>
        </div>

            
    
</div>
<div id="popup2" class="overlay">
	<div class="popup">
        <a class="close" href="#">×</a>
        <br />
		<h2 >Delete Item</h2>
		
		<div class="content">
            <center>
<p>
    Are you sure you want to delete this item?
</p>
			
			<p>
                <div class="div_button">
                <asp:Button ID="Button3" runat="server" Text="Yes"  CssClass="action-button hvr-radial-out"/>
            &nbsp;&nbsp;
                <asp:Button ID="Button4" runat="server" Text="No" CssClass="cancel_button" PostBackUrl="~/src/main/itemlist.aspx"/>
            </div>
			</p>

            
            </center>
		</div>
	</div>
</div>
</asp:Content>
