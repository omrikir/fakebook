<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FriendsRequest.aspx.cs" Inherits="FriendsRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style10
        {
            height: 20px;
        }
        .style11
        {
            height: 20px;
            width: 130px;
        }
        .style12
        {
            width: 750px;
        }
        .style13
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td align="center" class="style13">
                <asp:Label ID="lblResponse" runat="server" Font-Size="XX-Large"></asp:Label>
                <br />
                <asp:HyperLink ID="SentRequests" runat="server" 
                    NavigateUrl="~/FriendRequestSent.aspx">View Sent Requests</asp:HyperLink>
                <asp:DataList ID="DataList1" runat="server" style="margin-left: 0px" 
                    Width="434px" onitemcommand="DataList1_ItemCommand1">
                    <HeaderTemplate>
                        <asp:Label ID="lblRequestsHeader" runat="server" Font-Size="XX-Large" 
                            Text="Friends Requests:"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table class="style1">
                            <tr>
                                <td class="style10">
                                    <asp:Image ID="profileImage" runat="server" Height="75px" 
                                        ImageUrl='<%# Users.GetUser(int.Parse(Eval("UserID").ToString())).ProfileImage %>'
                                        AlternateText='<%# int.Parse(Eval("UserID").ToString()) %>'
                                        style="margin-right: 0px" Width="75px" />
                                </td>
                                <td class="style11">
                                    <asp:HyperLink ID="friendLink" runat="server" 
                                        
                                        Text='<%# Users.GetUser(int.Parse(Eval("UserID").ToString())).FirstName + " " + Users.GetUser(int.Parse(Eval("UserID").ToString())).LastName %>' 
                                        NavigateUrl='<%# "~/Profiles.aspx?id=" + Eval("UserID") %>'></asp:HyperLink>
                                </td>
                                <td class="style10">
                                    <asp:Button ID="btnConfirm" runat="server" 
                                        Text="Confirm" CommandName="ConfirmClick" />
                                    <asp:Button ID="btnDelete" runat="server" 
                                        Text="Delete Request" CommandName="DeleteClick" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        </table>
</asp:Content>

