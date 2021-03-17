<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Profiles.aspx.cs" Inherits="Profiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style10
        {
            width: 711px;
        }
        .style11
        {
            height: 20px;
        }
        .style12
        {
        }
        .style13
        {
            width: 294px;
            height: 184px;
        }
        .style14
        {
            height: 184px;
        }
        .style15
        {
            height: 184px;
            width: 317px;
        }
        .style16
        {
            height: 17px;
        }
        .style17
        {
            height: 20px;
            width: 222px;
        }
        .style18
        {
            width: 222px;
        }
        .style19
        {
            width: 268px;
        }
        .style20
        {
            width: 268px;
            height: 46px;
        }
        .style21
        {
            height: 46px;
        }
        .style2
        {
            position:relative; 
            Z-INDEX: 101;
            top:1%;
            float:none;
        }
        .style22
        {
            height: 69px;
        }
        .style23
        {
            position:relative;
            top:0px;
            right:5px;
            float:right;
        }
        .style24
        {
            width: 13px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td colspan="2">
            <div style="position:relative; height:80%; width:80%; left:10%; top:60%; background-color:Black;">
                &nbsp;<table class="style1">
                    <tr>
                        <td class="style13">
                <asp:Image ID="imgProfile" runat="server" Height="160px" Width="160px" 
                    BorderColor="#E5E5E5" BorderWidth="10px" />
                        </td>
                        <td class="style15">
                    <asp:Label ID="lblProfileName" runat="server" Text="Label" Font-Bold="True" 
                    Font-Overline="False" Font-Size="20pt" ForeColor="White"></asp:Label>
                        </td>
                        <td class="style14">
                            <asp:Label ID="lblFriend" runat="server" ForeColor="White" 
                                Text="This person is in your friendlist"></asp:Label>
                            <br />
                            <asp:Button ID="btnAddFriend" runat="server" onclick="btnAddFriend_Click" 
                                Text="Add friend" />
                            <asp:Button ID="btnEditProfile" runat="server" Text="Edit Profile" 
                                onclick="btnEditProfile_Click" />
                            <asp:Button ID="btnDeleteFriend" runat="server" onclick="btnDeleteFriend_Click" 
                                Text="Delete Friend" />
                            <asp:Button ID="btnConfirm" runat="server" onclick="btnConfirm_Click" 
                                Text="Confirm Friendship request" Visible="False" />
                            <asp:Button ID="btnGoToChat" runat="server" onclick="btnGoToChat_Click" 
                                Text="Chat With Me" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="style12" colspan="3">
                            <asp:Button ID="btnTimeLine" runat="server" onclick="btnTimeLine_Click" 
                                Text="Timeline" />
                            <asp:Button ID="btnFriends" runat="server" onclick="btnFriends_Click" 
                                Text="Friends" />
                        </td>
                    </tr>
                </table>
                </div>
                <!-- 
                accept=".png,.jpg,.jpeg,.gif"
                -->
            </td>
        </tr>
        <tr>
            <td class="style10" align="center" valign="top">

                <br />
                <br />
                <asp:Panel ID="panelPostNew" runat="server" Visible="False" Height="154px" 
                    Width="719px">
                    <asp:Label ID="lblPostNew" runat="server" Text="Post On The Wall"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtPost" runat="server" Height="88px" TextMode="MultiLine" 
                    Width="303px"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnSubmitPost" runat="server" onclick="btnSubmitPost_Click" 
                    Text="Insert Post" />
                </asp:Panel>
                <br />
                <br />
            </td>
            <td>

                <asp:Panel ID="panelUpdate" runat="server" Visible="False">
                    <table class="style1">
                        <tr>
                            <td align="center" class="style20">
                                Update your profile image</td>
                            <td class="style21">
                                <asp:FileUpload ID="FileUpload1" runat="server" accept="image/*" />
                                <asp:Button ID="btnUploadImage" runat="server" onclick="btnUploadImage_Click" 
                                    Text="Upload Profile Image" />
                                <asp:RegularExpressionValidator ID="RegExValFileUploadFileType" runat="server" 
                                    ControlToValidate="FileUpload1" 
                                    ErrorMessage="Only .jpg,.png,.jpeg,.gif Files are allowed" Font-Bold="True" 
                                    Font-Size="Medium" ForeColor="Red" 
                                    ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style19">
                                Update your info</td>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    onrowcancelingedit="GridView1_RowCancelingEdit" 
                                    onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating">
                                    <Columns>
                                        <asp:CommandField ShowEditButton="True" />
                                        <asp:TemplateField HeaderText="First Name">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtFirstNameTbl" runat="server" 
                                                    Text='<%# Bind("FirstName") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="requiredFirstNameTbl" runat="server" 
                                                    ControlToValidate="txtFirstNameTbl" ErrorMessage="Insert first name" 
                                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Name">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtLastNameTbl" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="requiredLastNameTbl" runat="server" 
                                                    ControlToValidate="txtLastNameTbl" ErrorMessage="Insert first name" 
                                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Password">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPasswordTbl" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="requiredPasswordTbl" runat="server" 
                                                    ControlToValidate="txtPasswordTbl" ErrorMessage="Insert first name" 
                                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                                    ControlToValidate="txtPasswordTbl" 
                                                    ErrorMessage="4 to 12 characters. At least one alphabet character and one number." 
                                                    ForeColor="Red" 
                                                    ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{4,12})$"></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Password") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" />
                                        <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" />
                                        <asp:BoundField DataField="Birthday" DataFormatString="{0:dd/MM/yyyy}" 
                                            HeaderText="Birthday" ReadOnly="True" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            &nbsp;<br />
                <asp:Panel ID="panelShowLiked" runat="server" BackColor="#99CCFF" 
                    Visible="False" Width="40%">
                    <asp:Label ID="lblNoLikes" runat="server" Font-Size="XX-Large" 
                        Text="No Likes On The Post"></asp:Label>
                    <asp:Button ID="btnExit" runat="server" CssClass="style23" 
                        onclick="btnExit_Click" Text="X" />
                    <br />
                    <br />
                    <asp:Label ID="lblAmountLikes" runat="server" Font-Size="X-Large" 
                        Visible="False"></asp:Label>
                    <asp:DataList ID="LikesList" runat="server">
                        <ItemTemplate>
                            <table class="style1">
                                <tr>
                                    <td class="style24">
                                        <asp:Image ID="profileImage" runat="server" 
                                            AlternateText='<%# int.Parse(Eval("UserID").ToString()) %>' Height="75px" 
                                            ImageUrl='<%# Users.GetUser(int.Parse(Eval("UserID").ToString())).ProfileImage %>' 
                                            style="margin-right: 0px" Width="75px" />
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="PersonLink" runat="server" 
                                            NavigateUrl='<%# "~/Profiles.aspx?id=" + Eval("UserID") %>' 
                                            Text='<%# Users.GetUser(int.Parse(Eval("UserID").ToString())).FirstName + " " + Users.GetUser(int.Parse(Eval("UserID").ToString())).LastName %>'></asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </asp:Panel>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Panel 
                    ID="panelPostList" runat="server">
                    <asp:Label ID="lblNoPosts" runat="server" Font-Size="X-Large" 
                        Text="No Posts On The Wall Yet" Visible="False"></asp:Label>
                    <br />
                    <asp:DataList ID="postsList" runat="server" 
                        onitemcommand="postsList_ItemCommand" Width="658px">
                        <ItemTemplate>
                            <table align="center">
                                <tr>
                                    <td bgcolor="#CCCCCC" class="style17" dir="ltr">
                                        <asp:Image ID="Image1" runat="server" Height="40px" 
                                            ImageUrl='<%# Users.GetUser(int.Parse(Eval("PublisherID").ToString())).ProfileImage %>' 
                                            Width="40px" />
                                        <asp:Button ID="btnDelete" runat="server" CommandName="DeletePost" 
                                            CssClass="style23" Text="X" 
                                            Visible='<%# (int.Parse(Eval("PublisherID").ToString()) == ((Users)Session["User"]).UserID) || (currentID == ((Users)Session["User"]).UserID) %>' />
                                        <asp:HyperLink ID="linkToPublisher" runat="server" 
                                            NavigateUrl='<%# "~/Profiles.aspx?id=" + Eval("PublisherID") %>' 
                                            Text='<%# Users.GetUser(int.Parse(Eval("PublisherID").ToString())).FirstName + " " + Users.GetUser(int.Parse(Eval("PublisherID").ToString())).LastName %>'></asp:HyperLink>
                                        <asp:Label ID="lblPostID" runat="server" Text='<%# Eval("PostID") %>' 
                                            Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#CCCCCC" class="style17">
                                        <asp:Label ID="lblPostContent" runat="server" 
                                            Text='<%# FormatText(Eval("Contents") as string) %>'></asp:Label>
                                        <br />
                                        <asp:Button ID="btnLikeCount" runat="server" BackColor="#3366CC" 
                                            BorderColor="#3366CC" CommandName="ShowLiked" ForeColor="White" 
                                            Text='<%# "Like Count:" + Likes.LikesAmount(int.Parse(Eval("PostID").ToString())) %>' />
                                        <asp:Button ID="btnLike" runat="server" CommandName="LikePost" 
                                            Text='<%# (Likes.LikeExist(int.Parse(Eval("PostID").ToString()),((Users)Session["User"]).UserID)) ? "Unlike" : "Like" %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#CCCCCC" class="style18">
                                        <asp:DataList ID="commentList" runat="server" BackColor="#DEBA84" 
                                            BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                            CellSpacing="2" 
                                            DataSource='<%# Posts.GetAllPosts(-1,int.Parse(Eval("PostID").ToString())) %>' 
                                            GridLines="Both" onitemcommand="commentList_ItemCommand">
                                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                            <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                            <ItemTemplate>
                                                <table class="style1">
                                                    <tr>
                                                        <td class="style22">
                                                            <asp:Image ID="Image1" runat="server" Height="40px" 
                                                                ImageUrl='<%# Users.GetUser(int.Parse(Eval("PublisherID").ToString())).ProfileImage %>' 
                                                                Width="40px" />
                                                            <asp:Button ID="btnDelete" runat="server" CommandName="DeleteComment" 
                                                                CssClass="style23" Text="X" 
                                                                Visible='<%# (int.Parse(Eval("PublisherID").ToString()) == ((Users)Session["User"]).UserID) || (currentID == ((Users)Session["User"]).UserID) %>' />
                                                            <asp:HyperLink ID="linkToPublisher" runat="server" 
                                                                NavigateUrl='<%# "~/Profiles.aspx?id=" + Eval("PublisherID") %>' 
                                                                Text='<%# Users.GetUser(int.Parse(Eval("PublisherID").ToString())).FirstName + " " + Users.GetUser(int.Parse(Eval("PublisherID").ToString())).LastName %>'></asp:HyperLink>
                                                            <asp:Label ID="lblPostID" runat="server" Text='<%# Eval("PostID") %>' 
                                                                Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblCommentContent" runat="server" 
                                                                Text='<%# FormatText(Eval("Contents") as string) %>'></asp:Label>
                                                            <br />
                                                            <asp:Button ID="btnLikeCount" runat="server" BackColor="#3366CC" 
                                                                BorderColor="#3366CC" ForeColor="White" 
                                                                
                                                                Text='<%# "Like Count:" + Likes.LikesAmount(int.Parse(Eval("PostID").ToString())) %>' 
                                                                CommandName="ShowLiked" />
                                                            <asp:Button ID="btnLike" runat="server" CommandName="LikePost" 
                                                                Text='<%# (Likes.LikeExist(int.Parse(Eval("PostID").ToString()),((Users)Session["User"]).UserID)) ? "Unlike" : "Like" %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DataList ID="commentsOnComments" runat="server" 
                                                                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                                                                CellPadding="2" 
                                                                DataSource='<%# Posts.GetAllPosts(-1,int.Parse(Eval("PostID").ToString())) %>' 
                                                                ForeColor="Black" onitemcommand="commentsOnComments_ItemCommand">
                                                                <AlternatingItemStyle BackColor="PaleGoldenrod" />
                                                                <FooterStyle BackColor="Tan" />
                                                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                                                <ItemTemplate>
                                                                    <table class="style1">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblPostID" runat="server" Text='<%# Eval("PostID") %>' 
                                                                                    Visible="False"></asp:Label>
                                                                                <asp:Image ID="Image1" runat="server" Height="40px" 
                                                                                    ImageUrl='<%# Users.GetUser(int.Parse(Eval("PublisherID").ToString())).ProfileImage %>' 
                                                                                    Width="40px" />
                                                                                <asp:Button ID="btnDelete" runat="server" CommandName="DeleteComment" 
                                                                                    CssClass="style23" Text="X" 
                                                                                    Visible='<%# (int.Parse(Eval("PublisherID").ToString()) == ((Users)Session["User"]).UserID) || (currentID == ((Users)Session["User"]).UserID) %>' />
                                                                                <asp:HyperLink ID="linkToPublisher" runat="server" 
                                                                                    NavigateUrl='<%# "~/Profiles.aspx?id=" + Eval("PublisherID") %>' 
                                                                                    Text='<%# Users.GetUser(int.Parse(Eval("PublisherID").ToString())).FirstName + " " + Users.GetUser(int.Parse(Eval("PublisherID").ToString())).LastName %>'></asp:HyperLink>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblCommentContent" runat="server" 
                                                                                    Text='<%# FormatText(Eval("Contents") as string) %>'></asp:Label>
                                                                                <br />
                                                                                <asp:Button ID="btnLikeCount" runat="server" BackColor="#3366CC" 
                                                                                    BorderColor="#3366CC" ForeColor="White" 
                                                                                    
                                                                                    Text='<%# "Like Count:" + Likes.LikesAmount(int.Parse(Eval("PostID").ToString())) %>' 
                                                                                    CommandName="ShowLiked" />
                                                                                <asp:Button ID="btnLike" runat="server" CommandName="LikePost" 
                                                                                    Text='<%# (Likes.LikeExist(int.Parse(Eval("PostID").ToString()),((Users)Session["User"]).UserID)) ? "Unlike" : "Like" %>' />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style16">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                                <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                            </asp:DataList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            <br />
                                                            <asp:Button ID="btnPostComment" runat="server" CommandName="AddPostComment" 
                                                                Text="Add comment" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                        </asp:DataList>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#CCCCCC" class="style18">
                                        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        <br />
                                        <asp:Button ID="btnPostComment" runat="server" CommandName="AddPostComment" 
                                            Text="Add comment" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <br />
                        </SeparatorTemplate>
                    </asp:DataList>
                </asp:Panel>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                <asp:Panel ID="panelFriendList" runat="server" Visible="False">
                    <asp:Label ID="lblFriendList" runat="server" Font-Size="XX-Large" 
                        Text="Friend List"></asp:Label>
                    <br />
                    <asp:DataList ID="friendList" runat="server" 
                    onitemcommand="friendList_ItemCommand">
                        <FooterTemplate>
                            <table class="style1">
                                <tr>
                                    <td align="left">
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
                                    <td class="style11" dir="ltr" bgcolor="#CCCCCC">
                                        <asp:Image ID="Image1" runat="server" 
                                        
                                        
                                        ImageUrl='<%# Users.GetUser(int.Parse(Eval("FriendID").ToString())).ProfileImage %>' 
                                        Height="40px" Width="40px" />
                                        <asp:HyperLink ID="linkToFriend" runat="server" NavigateUrl='<%# "~/Profiles.aspx?id=" + Eval("FriendID") %>' 
                                        
                                        
                                        
                                            Text='<%# Users.GetUser(int.Parse(Eval("FriendID").ToString())).FirstName + " " + Users.GetUser(int.Parse(Eval("FriendID").ToString())).LastName %>'></asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#CCCCCC">
                                        <asp:Label ID="lblSince" runat="server" Text="Friends Since"></asp:Label>
                                        <asp:TextBox ID="TextBox1" runat="server" Enabled="False" 
                                        Text='<%# Eval("Date") %>'></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <br />
                        </SeparatorTemplate>
                    </asp:DataList>
                    <br />
                    <asp:Label ID="lblNoFriends" runat="server" Font-Size="X-Large" 
                        Text="No Friends Yet" Visible="False"></asp:Label>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
