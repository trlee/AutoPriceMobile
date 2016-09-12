<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="searchResults.aspx.cs" Inherits="AutoPriceMobile.src.main.searchResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../Assets/Stylesheets/masterStyle.css" />
    <link rel="stylesheet" href="../../Assets/Stylesheets/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="this_box">
        <h2>
            Users
        </h2>
        <fieldset>
            <asp:GridView ID="UserResults" runat="server" DataKeyNames="UserID" OnRowDataBound="UserResults_RowDataBound" OnRowDeleting="UserResults_RowDeleting" AutoGenerateColumns="false" EmptyDataText="No users found..." RowStyle-HorizontalAlign="Center" GridLines="None" Width="800px">
                <AlternatingRowStyle BackColor="White" Height="50px" />
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" ItemStyle-Width="100px" Visible="false" />
                    <asp:HyperLinkField DataTextField="UserName" DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="~/src/main/profileView.aspx?ID={0}" HeaderText="User Name" ItemStyle-Width="300px"/>
                    <asp:TemplateField HeaderText="User Avatar">
                        <ItemTemplate>
                            
                            <asp:Image ID="Image1" runat="server" Height="300px" Width="300px" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("Avatar")) %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>

    <div class="this_box">
        <h2>
            Items Results
        </h2>
        <fieldset>
            <asp:GridView ID="ItemResults" runat="server" DataKeyNames="ItemID" OnRowDataBound="ItemResults_RowDataBound" OnRowDeleting="ItemResults_RowDeleting" AutoGenerateColumns="false" EmptyDataText="No items found..." RowStyle-HorizontalAlign="Center" GridLines="None" Width="1300px">
                <AlternatingRowStyle BackColor="White" Height="50px"/>
                <Columns>
                    <asp:BoundField DataField="ItemName" HeaderText="Item Name" SortExpression="ItemName" ItemStyle-Width="100px" />
                    <asp:TemplateField HeaderText="Item Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="300px" Width="300px" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ItemImage")) %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ItemDescription" HeaderText="Item Description" SortExpression="ItemDescription" ItemStyle-Width="300px" />
                    <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" ItemStyle-Width="100px" Visible="false"/>
                    <asp:HyperLinkField DataTextField="UserName" DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="~/src/main/profileView.aspx?ID={0}" HeaderText="User Name" ItemStyle-Width="300px"/>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" ItemStyle-Width="100px" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" ItemStyle-Width="100px" />
                    <asp:BoundField DataField="Time" HeaderText="Start Time" SortExpression="Time" ItemStyle-Width="100px" />
                    <asp:BoundField DataField="Status" ItemStyle-Width="200px" Visible="false"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>
    

</asp:Content>
