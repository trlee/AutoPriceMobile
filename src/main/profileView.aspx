<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="profileView.aspx.cs" Inherits="AutoPriceMobile.src.main.profileView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="../../Assets/Stylesheets/masterStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="this_box">
        <h2>
            User Profile
        </h2>
        <div style="text-align:center">
        <br />
        <asp:Label ID="followStatus" ForeColor="Green" runat="server"></asp:Label>
        <br />  
        </div>
        <div style="align-content:center; table-layout:auto; text-align:center">                       
        <asp:Table CssClass="this_table" runat="server" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:Image ID="avatar" runat="server" ImageAlign="Middle" Height="300px" Width="300px" ImageUrl="~/Assets/Images/Avatar AutoPrice/anon.jpg"/>
                    <br />
                    <br />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <h3> Name </h3>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Label ID="username_label" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>    
            <asp:TableRow>
                <asp:TableCell>
                    <h3> Status </h3>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Label ID="status_label" runat="server" Text="Active"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <h3> Email </h3>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Label ID="email_label" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <h3> Friends/Follower? </h3>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Label ID="friends_label" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <h3> Following? </h3>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Label ID="follow_label" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Middle">
                    <br />
                    <asp:HyperLink ID="Edit" NavigateUrl="editProfile.aspx" CssClass="comm_link" runat="server" Visible="true">Edit Profile</asp:HyperLink>
                    <br />
                    <br />
                    <asp:Button ID="followingstat" runat="server" OnClick="followingstat_ServerClick" CssClass="buttons"/>
                    <br />
                    <br />
                </asp:TableCell>
            </asp:TableRow>            
        </asp:Table>
        </div>    

        
    </div>
</asp:Content>
