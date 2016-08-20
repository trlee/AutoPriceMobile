<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="editProfile.aspx.cs" Inherits="AutoPriceMobile.src.main.editProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="../../Assets/Stylesheets/masterStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="this_box">

        <h2>Edit Profile</h2>
        <div style="text-align:center">
            <br />
            <asp:Label ID="edit_error" runat="server" ForeColor="Red"></asp:Label>
            <br />
        </div>
        
        <asp:Table CssClass="this_table" runat="server" HorizontalAlign="Center">
            
            <asp:TableRow>
                <asp:TableCell>
                    <h3> Name </h3>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="edit_name" runat="server" placeholder="Name" CssClass="txtbox"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>    
            <asp:TableRow>
                <asp:TableCell>
                    <h3> Profile Picture </h3>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:FileUpload ID="edit_avatar" runat="server" AllowMultiple="false" Enabled="true"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <h3> Email </h3>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="edit_email" runat="server" placeholder="Email" CssClass="txtbox"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <h3> Old Password </h3>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="edit_pass1" runat="server" placeholder="Old Password" CssClass="txtbox" TextMode="Password"/>                       
                </asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <h3> New Password </h3>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                     <asp:TextBox ID="edit_pass2" runat="server" placeholder="New Password" CssClass="txtbox" TextMode="Password"></asp:TextBox>
                </asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <h3> Confirm Password </h3>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="edit_pass3" runat="server" placeholder="Confirm New Password" CssClass="txtbox" TextMode="Password"></asp:TextBox> 
                </asp:TableCell></asp:TableRow>
            <asp:TableFooterRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <br />
                    <br />
                    <asp:Button ID="submitbtn" runat="server" OnClick="submitbtn_ServerClick" CssClass="buttons" Text="Submit"/>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="cancel" runat="server" OnClick="cancel_ServerClick" CssClass="buttons" Text="Cancel" />
                    <br />
                    <br />
                </asp:TableCell></asp:TableFooterRow></asp:Table>

    </div></asp:Content>