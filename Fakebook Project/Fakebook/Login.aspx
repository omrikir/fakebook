<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .style23
        {
            width: 97%;
            height: 274px;
        }
        .style24
        {
            height: 26px;
        }
        .style25
        {
            height: 26px;
            width: 381px;
        }
        .style27
        {
            height: 26px;
            width: 740px;
        }
        .style29
        {
            height: 20px;
        }
        .style35
        {
            width: 381px;
            height: 20px;
        }
        .style36
        {
            width: 740px;
            height: 20px;
        }
        .style33
        {
            height: 25px;
        }
        .style31
        {
            width: 226px;
        }
        .style34
        {
            width: 89px;
        }
        .style37
        {
            height: 310px;
            width: 381px;
        }
        .style38
        {
            height: 310px;
            width: 740px;
        }
        .style39
        {
            height: 310px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style23">
        <tr>
            <td class="style25">
            </td>
            <td align="center" class="style27">
                &nbsp;</td>
            <td class="style24">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style35">
                &nbsp;</td>
            <td class="style36">
                <table class="style23">
                    <tr>
                        <td align="center" bgcolor="White" class="style33" colspan="3">
                            <span style="color: rgb(29, 33, 41); font-family: Helvetica, Arial, sans-serif; font-size: 18px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">
                            Log into Fakebook</span></td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="White" class="style32">
                            Email</td>
                        <td bgcolor="White" class="style31">
                        <asp:TextBox ID="txtEmailLogin" runat="server" Width="319px"></asp:TextBox>
                                </td>
                        <td bgcolor="White" class="style34">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtEmailLogin" ErrorMessage="Must enter Email" 
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="White" class="style32">
                            Password</td>
                        <td bgcolor="White" class="style31">
                        <asp:TextBox ID="txtPassLogin" runat="server" Width="319px" TextMode="Password"></asp:TextBox>
                                </td>
                        <td bgcolor="White" class="style34">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtPassLogin" ErrorMessage="Must enter password" 
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="White" class="style29" colspan="3">
                    <asp:Button ID="btnLogin" runat="server" BackColor="#4267B2" 
                        BorderColor="#29487C" BorderStyle="Solid" ForeColor="White" Text="Login" 
                                onclick="btnLogin_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="White" class="style29" colspan="3">
                            <asp:HyperLink ID="HyperLink6" runat="server">Forgot Account?</asp:HyperLink>
&nbsp;<asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Registeration.aspx">Sign Up for Fakebook</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="style29">
            </td>
        </tr>
        <tr>
            <td class="style37">
            </td>
            <td class="style38">
            </td>
            <td class="style39">
            </td>
        </tr>
    </table>
    </asp:Content>

