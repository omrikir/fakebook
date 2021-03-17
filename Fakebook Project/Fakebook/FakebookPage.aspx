<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FakebookPage.aspx.cs" Inherits="FakebookPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style13
        {
            width: 1258px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style10" align="center" colspan="2">
                        <asp:Label ID="lblHeader" runat="server" Font-Size="XX-Large" 
                            Text="Fakebook Page - 5 points Project"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td class="style13" align="center">
                        <asp:Image ID="Image1" runat="server" ImageUrl="images\Temporaily_Image.jpg" 
                            Width="1241px" />
                        </td>
            <td align="center" valign="top">
                <asp:UpdatePanel BackColor="Gray" ID="PanelAd" runat="server" Visible="False">
                <ContentTemplate>
                    <asp:ScriptManager runat="server">
                    </asp:ScriptManager>
                    <asp:Timer ID="adChange" runat="server" Interval="10000" ontick="adChange_Tick">
                    </asp:Timer>
                    <asp:Panel BackColor ="Gray" Height="430px" Width="200px" runat="server">
                            <asp:Label ID="lblAdHeader" runat="server" Font-Size="X-Large" 
                                Text="Advertisements"></asp:Label>
                            <br />
                            <asp:HyperLink ID="adLink" runat="server" Height="170px" Width="170px"><asp:Image ID="ImageAd" runat="server" Height="170px" Width="170px" /></asp:HyperLink>
                            <br />
                            <asp:Label ID="lblAdvertiserName" runat="server"></asp:Label>
                            <br />
                            ----------------------------<br />
                            <asp:HyperLink ID="adLink1" runat="server" Height="170px" Width="170px"><asp:Image ID="ImageAd1" runat="server" Height="170px" Width="170px" /></asp:HyperLink>
                            <br />
                            <asp:Label ID="lblAdvertiserName1" runat="server"></asp:Label>
                            </asp:Panel>
                            </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
        </tr>
    </table>
</asp:Content>

