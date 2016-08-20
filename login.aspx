<%@ Page Title="AutoPrice | Login" Language="C#" MasterPageFile="~/PreLoginTemplate.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AutoPriceMobile.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Assets/Stylesheets/login.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br /> 
    <div id="login-container">
        <div class="box_login">
        <h2>LOG IN</h2>

            <fieldset>
                <table style="text-align:center;margin:auto;width:75%">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtbox_email" CssClass="txtbox" runat="server" Font-Size="Medium" placeholder="Email"></asp:TextBox> 
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="p_validation">
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Email is required" Font-Size="Smaller" ControlToValidate="txtbox_email" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="A valid email is required" Font-Size="Smaller" ControlToValidate="txtbox_email" Display="Dynamic" ValidateRequestMode="Inherit" SetFocusOnError="False" EnableViewState="True" ViewStateMode="Inherit" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:TextBox ID="txtbox_passw" CssClass="txtbox" runat="server" Font-Size="Medium" TextMode="Password" placeholder="Password"></asp:TextBox>  
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password is required" Font-Size="Smaller" ControlToValidate="txtbox_passw" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="text-align:center">

                            <asp:Label ID="lblLoginStatusMsg" runat="server"></asp:Label>
                            <br /><br />
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <strong>Not a Member?</strong>
                            <br />
                            <a href="signup.aspx">REGISTER HERE!</a>
                            <br />
                            <br />                        
                        </td>
                    </tr>
                    <!--tr>
                        <td class="forgot_passw_msg">
                            <strong>Forgot your password?</strong>
                            Click <a href="forgotpass.aspx">here</a>.
                            <br /><br />
                        </td>
                    </tr-->

                    <tr>
                        <td>
                            <asp:Button ID="login_button" CssClass="buttons" runat="server" Text="Log In" OnClick="login_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </fieldset>       
        </div>
    </div>
</asp:Content>
