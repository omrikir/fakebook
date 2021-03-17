<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyAdsControl.aspx.cs" Inherits="MyAdsControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style9
        {
            height: 20px;
        }
        .style999
        {
            position:relative;
            float:right;
            top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td align="center">
                <asp:Label ID="lblHeader" runat="server" Font-Size="XX-Large" 
                    Font-Underline="True" Text="My Published Ads"></asp:Label>
                <br />
                <asp:HyperLink ID="LinkBuyAd" runat="server" Font-Size="X-Large" 
                    NavigateUrl="~/BuyAd.aspx">Go to advertise an ad</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="panelAds" runat="server">
                    <asp:GridView ID="AdsView" runat="server" AutoGenerateColumns="False" 
                        onselectedindexchanging="AdsView_SelectedIndexChanging" 
                        DataKeyNames="AdID" >
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="Edit this ad" />
                            <asp:BoundField DataField="LastDate" DataFormatString="{0:dd/MM/yyyy}" 
                                HeaderText="Advertising Until">
                                     <ItemStyle HorizontalAlign="Center" />
                                     </asp:BoundField>
                            <asp:BoundField DataField="AdvertiserName" HeaderText="Advertiser Name">
                                 <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="Website" DataTextField="Website" 
                                HeaderText="Website URL" />
                            <asp:ImageField DataImageUrlField="AdImage" HeaderText="Ad Image">
                                <ControlStyle Height="180px" Width="180px" />
                            </asp:ImageField>
                            <asp:BoundField DataField="PlanLevel" HeaderText="Plan Level">
                                 <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblNoAds" runat="server" Font-Size="X-Large" 
                        Text="You have no published ads yet" Visible="False"></asp:Label>
                    <br />
                </asp:Panel>
                <asp:Panel ID="panelSelectedAd" runat="server" BackColor="#CCCCCC" 
                    Visible="False">
                    <table class="style1">
                        <tr>
                            <td class="style9" colspan="2" align="center">
                                <asp:Button ID="btnOut" runat="server" Text="X" CssClass="style999" 
                                    onclick="btnOut_Click" />
                                <asp:Label ID="lblHeader0" runat="server" Font-Size="X-Large"></asp:Label>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblAdvertiserName" runat="server" Text="Advertiser Name"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAdvertiserName" runat="server" Width="219px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtAdvertiserName" ErrorMessage="Must Choose Name" 
                                    ForeColor="Red" ValidationGroup="Update">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblUrl" runat="server" Text="Advertised Website URL"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtURL" runat="server" Width="232px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="txtURL" ErrorMessage="Must Enter URL" ForeColor="Red" 
                                    ValidationGroup="Update">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegExValFileUploadFileType1" runat="server" 
                                    ControlToValidate="txtURL" ErrorMessage="Enter Correct URL" Font-Bold="True" 
                                    Font-Size="Medium" ForeColor="Red" 
                                    ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" 
                                    ValidationGroup="Update"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblAdImage" runat="server" Text="Advertisement Image"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Image ID="imageSelectedAd" runat="server" Height="180px" Width="180px" />
                                <asp:FileUpload ID="FileUpload1" runat="server" accept="image/*" />
                                <asp:RegularExpressionValidator ID="RegExValFileUploadFileType0" runat="server" 
                                    ControlToValidate="FileUpload1" 
                                    ErrorMessage="Only .jpg,.png,.jpeg,.gif Files are allowed" Font-Bold="True" 
                                    Font-Size="Medium" ForeColor="Red" 
                                    ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" 
                                    ValidationGroup="Update"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnCancelAdChanging" runat="server" 
                                    onclick="btnCancelAdChanging_Click" Text="Cancel the image changing" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="Update" 
                                    onclick="btnUpdate_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

