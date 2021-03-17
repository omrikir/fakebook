<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChatMessages.aspx.cs" Inherits="ChatMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style9
        {
            width: 1089px;
        }
        .style11
        {
            width: 502px;
        }
        .style14
        {
            width: 1650px;
        }
        .style15
        {
            width: 75px;
        }
        .style16
        {
            width: 303px;
        }
        .style17
        {
            width: 362px;
        }
        .style18
        {
            width: 80%;
            direction: ltr;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblHeader" runat="server" Font-Size="XX-Large" Text="Chat With:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="style11" valign="top">

                <asp:Panel ID="panelNewMessage" runat="server" Height="154px" 
                    Width="499px">
                    <asp:Label ID="lblNewMessage" runat="server" Text="Write a new message"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtMessage" runat="server" Height="88px" TextMode="MultiLine" 
                    Width="303px"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnSubmitMessage" runat="server"
                    Text="Send" onclick="btnSubmitMessage_Click" />
                </asp:Panel>
                <asp:Button ID="btnRefresh" runat="server" onclick="btnRefresh_Click" 
                    Text="Refresh Messages" />
                <br />
                </td>
            <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:DataList ID="MessageList" runat="server" CssClass="style18" 
                    GridLines="Both" onitemcommand="MessageList_ItemCommand">
                    <FooterTemplate>
                        <table class="style1">
                            <tr>
                                <td style="text-align: center">
                                    <asp:Button ID="btnLoadMore" runat="server" CommandName="LoadMore" 
                                        Text="Load More" />
                                </td>
                            </tr>
                        </table>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Panel ID="panelMyComment" runat="server" BackColor="#3399FF" 
                            
                            
                            Visible='<%# int.Parse(Eval("SenderUserID").ToString())==((Users)Session["User"]).UserID %>'>
                            <table class="style1">
                                <tr>
                                    <td class="style14" align="center">
                                        <asp:Label ID="lblShowContent" runat="server" 
                                            Text='<%# FormatText(Eval("Contents") as string) %>'></asp:Label>
                                    </td>
                                    <td dir="rtl" class="style17">
                                        <asp:TextBox ID="sentDate" runat="server" Enabled="False" Height="25px" 
                                            Text='<%# Eval("Date") %>' Width="122px"></asp:TextBox>
                                    </td>
                                    <td class="style17" dir="rtl">
                                        <asp:Label ID="lblYou" runat="server" Text="You"></asp:Label>
                                    </td>
                                    <td dir="rtl">
                                        <asp:Image ID="profileImage" runat="server" 
                                            AlternateText='<%# int.Parse(Eval("SenderUserID").ToString()) %>' Height="75px" 
                                            ImageUrl='<%# Users.GetUser(int.Parse(Eval("SenderUserID").ToString())).ProfileImage %>' 
                                            style="margin-right: 0px" Width="76px" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="panelOtherComment" runat="server" 
                            
                            Visible='<%# int.Parse(Eval("SenderUserID").ToString())!=((Users)Session["User"]).UserID %>' 
                            BackColor="#CCCCCC">
                            <table class="style1">
                                <tr>
                                    <td class="style15">
                                        <asp:Image ID="profileImage0" runat="server" 
                                            AlternateText='<%# int.Parse(Eval("SenderUserID").ToString()) %>' Height="75px" 
                                            ImageUrl='<%# Users.GetUser(int.Parse(Eval("SenderUserID").ToString())).ProfileImage %>' 
                                            style="margin-right: 0px" Width="75px" />
                                    </td>
                                    <td class="style16">
                                        <asp:HyperLink ID="PersonLink" runat="server" 
                                            NavigateUrl='<%# "~/Profiles.aspx?id=" + Eval("SenderUserID") %>' 
                                            Text='<%# Users.GetUser(int.Parse(Eval("SenderUserID").ToString())).FirstName + " " + Users.GetUser(int.Parse(Eval("SenderUserID").ToString())).LastName %>'></asp:HyperLink>
                                    </td>
                                    <td class="style16">
                                        <asp:TextBox ID="sentDate0" runat="server" Enabled="False" Height="28px" 
                                            Text='<%# Eval("Date") %>' Width="127px"></asp:TextBox>
                                    </td>
                                    <td class="style9" align="center">
                                        <asp:Label ID="lblShowContent0" runat="server" 
                                            Text='<%# FormatText(Eval("Contents") as string) %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ItemTemplate>
                </asp:DataList>
            </td>
                            </ContentTemplate>
                        </asp:UpdatePanel>
        </tr>
    </table>
</asp:Content>

