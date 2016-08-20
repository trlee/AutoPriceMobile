<%@ Page Title="AutoPrice | Sign Up" Language="C#" MasterPageFile="~/PreLoginTemplate.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="AutoPriceMobile.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Assets/Stylesheets/signup.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br /> 
    <div id="signup-container">
        <div class="box_signup">
        <h2>SIGN UP</h2>
            
            
            <fieldset>
                <div style="text-align:center">
                    <asp:Label ID="signup_status" runat="server" ForeColor="Red"></asp:Label>
                </div>
                <table style="text-align:center;margin:auto;width:75%">
                    <tr>
                        <td>
                            Username:
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvUser" runat="server" ErrorMessage="Usernames required" Font-Size="Smaller" ControlToValidate="txtbox_username" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtbox_username" CssClass="txtbox" runat="server" Font-Size="Medium"></asp:TextBox> 
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            Email:
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Email is required" Font-Size="Smaller" ControlToValidate="txtbox_email" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtbox_email" CssClass="txtbox" runat="server" Font-Size="Medium"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="A valid email is required" Font-Size="Smaller" ControlToValidate="txtbox_email" Display="Dynamic" ValidateRequestMode="Inherit" SetFocusOnError="False" EnableViewState="True" ViewStateMode="Inherit" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            Password:
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password is required" Font-Size="Smaller" ControlToValidate="txtbox_passw" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtbox_passw" CssClass="txtbox" runat="server" Font-Size="Medium" TextMode="Password"></asp:TextBox>  
                        </td>
                    </tr>
                                            

                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:Button ID="signupbtn" CssClass="buttons" runat="server" OnClick="signup_Click" Text="Sign Up"></asp:Button>
                            <br />
                        </td>
                    </tr>
                </table>
            </fieldset>       
        </div>
    </div>
</asp:Content>
