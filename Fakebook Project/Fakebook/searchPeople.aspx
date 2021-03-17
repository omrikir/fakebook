<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="searchPeople.aspx.cs" Inherits="Search_people" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
 .style1
 {
     left: 0;
     position: fixed;
     top: 0px;
     width: 100%;
     z-index: 199;
     border: 1px solid;
     border-color: #e5e6e9 #dfe0e4 #d0d1d5;
     border-radius: 3px;
     background-color: #fff;
     font-family: Helvetica, Arial, sans-serif;
     /*font-size: 12px;*/
     position:relative;
 }
    .style10
    {
        width: 100%;
    }
        .style11
        {
            width: 86%;
        }
        .style12
        {
            width: 30%;
        }
        .style13
        {
            height: 40px;
        }
        .style14
        {
            width: 247px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table class="style10">
    <tr>
        <td align="center" class="style13">
            <asp:Label ID="lblSearch" runat="server" Font-Size="XX-Large" 
                Text="Search People"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Label ID="lblNonFound" runat="server" Font-Bold="True" 
                Font-Size="XX-Large" Font-Underline="True" Text="No Results Found" 
                Visible="False"></asp:Label>
            <asp:DataList ID="searchPeopleList" runat="server" 
                onitemcommand="searchPeopleList_ItemCommand" Width="500px">
                <FooterTemplate>
                    <table class="style10">
                        <tr>
                            <td align="left" class="style14">
                                <asp:Button ID="btnPrevPage" runat="server" CommandName="PrevPage" 
                                    Text="Previous Page" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnNextPage" runat="server" CommandName="NextPage" 
                                    Text="Next Page" />
                            </td>
                        </tr>
                    </table>
                </FooterTemplate>
                <ItemTemplate>
                    <table class="style1">
                        <tr>
                            <td class="style12">
                                <asp:Image ID="profileImage" runat="server" Height="75px" 
                                        ImageUrl='<%# Users.GetUser(int.Parse(Eval("UserID").ToString())).ProfileImage %>'
                                        AlternateText='<%# int.Parse(Eval("UserID").ToString()) %>'
                                        style="margin-right: 0px" Width="75px" />
                            </td>
                            <td class="style11" align="center">
                                <asp:HyperLink ID="PersonLink" runat="server" 
                                        
                                        
                                    
                                    Text='<%# Users.GetUser(int.Parse(Eval("UserID").ToString())).FirstName + " " + Users.GetUser(int.Parse(Eval("UserID").ToString())).LastName %>' 
                                    NavigateUrl='<%# "~/Profiles.aspx?id=" + Eval("UserID") %>'></asp:HyperLink>
                            </td>
                            <td class="style10">
                                <asp:Button ID="btnAddFriend" runat="server" 
                                        Text="Add as Friend" CommandName="AddClick" 
                                    Visible='<%# ((!Friendships.ExistFriendship(((Users)Session["User"]).UserID, int.Parse(Eval("UserID").ToString())) && !FriendRequest.ExistFriendRequest(((Users)Session["User"]).UserID, int.Parse(Eval("UserID").ToString())))&& int.Parse(Eval("UserID").ToString())!=((Users)Session["User"]).UserID) %>' />
                                <asp:Button ID="btnDelete" runat="server" CommandName="DeleteClick" 
                                    Text="Delete Friend" 
                                    Visible='<%# (!((!Friendships.ExistFriendship(((Users)Session["User"]).UserID, int.Parse(Eval("UserID").ToString())) && !FriendRequest.ExistFriendRequest(((Users)Session["User"]).UserID, int.Parse(Eval("UserID").ToString()))))&& int.Parse(Eval("UserID").ToString())!=((Users)Session["User"]).UserID) %>' />
                                <asp:Button ID="btnMyProfile" runat="server" CommandName="GoToProfile" 
                                    Text="Go To My Profile" 
                                    Visible='<%# int.Parse(Eval("UserID").ToString())==((Users)Session["User"]).UserID %>' />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
</table>

</asp:Content>

