<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MessageFriends.aspx.cs" Inherits="MessageFriends" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
    rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id$=txtFriend]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/MessageFriends.aspx/GetFriends") %>',
                        data: "{ 'prefix': '" + request.term + "', 'id':'" + <%=((Users)Session["User"]).UserID %> + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            var count = 0;
                            response($.map(data.d, function (item) {
                                count++;
                                if (count <= 5)
                                    return {
                                        label: item.split('-')[0],
                                        val: item.split('-')[1],
                                        image: item.split('-')[2]
                                    };
                                else
                                    return false;
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    location.href = "ChatMessages.aspx?id=" + i.item.val;
                },
                minLength: 1
            }).data("ui-autocomplete")._renderItem = function (ul, item) {
                if (item.val != undefined) {
                    var inner_html = '<a style="text-decoration:none;" href="ChatMessages.aspx?id=' + item.val + '"><div><p style="float: left;"><img height="25px" width="25px" src="' + item.image + '"></p><p>' + item.label + '</p></div></a><hr/>';
                    return $("<li></li>")
                    .data("ui-autocomplete-item", item)
                    .append(inner_html)
                    .appendTo(ul);
                }
                else
                    return false;
            };
        });
    </script>
    <style type="text/css">
        .style9
        {
            width: 631px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr>
        <td align="center" class="style9" valign="top">
            <asp:Label ID="lblSearchFriend" runat="server" Font-Size="XX-Large" 
                Text="Search Friend To Converse With"></asp:Label>
            <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
            <br />
                <asp:TextBox ID="txtFriend" runat="server" Width="168px"></asp:TextBox> 
                </td>
        <td align="center">
            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" 
                Text="Private Message One Of Your Friends"></asp:Label>
            <br />
            <asp:GridView ID="friendsView" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="FriendID" 
                        DataNavigateUrlFormatString="ChatMessages.aspx?id={0}" 
                        Text="Enter A Conversation" />
                    <asp:HyperLinkField DataNavigateUrlFields="FriendID" 
                        DataNavigateUrlFormatString="Profiles.aspx?id={0}" DataTextField="FriendName" 
                        HeaderText="Friend" />
                    <asp:BoundField DataField="Date" HeaderText="Friends Since" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
</asp:Content>

