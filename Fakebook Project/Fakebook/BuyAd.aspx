<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BuyAd.aspx.cs" Inherits="BuyAd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style9
        {
            height: 20px;
        }
        .style1000
        {
            height: 30px;
        }
        .style999
        {
            position:relative;
            float:right;
            top: 0px;
        }
        .style1002
        {
            width: 265px;
        }
        .hidden
        {
            display: none;
        }
    .style1003
    {
    }
    .style1004
    {
        width: 501px;
        height: 26px;
    }
    .style1005
    {
        width: 265px;
        height: 26px;
    }
    .style1006
    {
        height: 26px;
    }
        .style1007
        {
            height: 30px;
            width: 477px;
        }
        .style1008
        {
            height: 20px;
            width: 477px;
        }
        .style1009
        {
            width: 477px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td align="center">
                <asp:Label ID="lblBuyAds" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                    Font-Strikeout="False" Font-Underline="True" Text="Advertise Ad"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="style9">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                <asp:Panel ID="panelChoose" runat="server">
                    <table class="style1">
                        <tr>
                            <td>
                                <asp:Label ID="lblLowPlan" runat="server" 
                Text="Low Plan"></asp:Label>
                            </td>
                            <td class="style1007">
                                <asp:Label ID="lblNormalPlan" runat="server" 
                Text="Normal Plan"></asp:Label>
                            </td>
                            <td class="style1000">
                                <asp:Label ID="lblHighPlan" runat="server" 
                Text="High Plan"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                <asp:TextBox ID="TextBox1" runat="server" 
                Enabled="False" Height="58px" TextMode="MultiLine" Width="309px">* Lowest amount of shows per month
* Cheapest plan 10$ per month</asp:TextBox>
                            </td>
                            <td class="style1008">
                                <asp:TextBox ID="TextBox2" runat="server" 
                Enabled="False" Height="73px" TextMode="MultiLine" Width="309px">* Middle amount of shows per month
* Good price/shows ratio
* 20$ per month</asp:TextBox>
                            </td>
                            <td class="style9">
                                <asp:TextBox ID="TextBox3" runat="server" 
                Enabled="False" Height="58px" TextMode="MultiLine" Width="309px">* Best shows per month
* High cost, 30$ per month</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnChooseLow" runat="server" 
                Text="Choose" onclick="btnChooseLow_Click" />
                            </td>
                            <td class="style1009">
                                <asp:Button ID="btnChooseNormal" runat="server" 
                Text="Choose" onclick="btnChooseNormal_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnChooseHigh" runat="server" 
                Text="Choose" onclick="btnChooseHigh_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" class="style9">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="panelBuy" runat="server" BackColor="#CCCCCC" Visible="False">
                    <table class="style1">
                        <tr>
                            <td class="style9" colspan="2" align="center">
                                <asp:Button ID="btnOut" runat="server" Text="X" CssClass="style999" 
                                    onclick="btnOut_Click" />
                                <asp:Label ID="lblHeader" runat="server" Font-Size="X-Large"></asp:Label>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblTime" runat="server" Text="Amount of time for advertising"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="timeDropList" runat="server">
                                    <asp:ListItem Value="0">Choose Amount of Months</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="timeDropList" ErrorMessage="Must Choose Amount" 
                                    ForeColor="Red" InitialValue="0" ValidationGroup="Buy">*</asp:RequiredFieldValidator>
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
                                    ForeColor="Red" ValidationGroup="Buy">*</asp:RequiredFieldValidator>
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
                                    ValidationGroup="Buy">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegExValFileUploadFileType1" runat="server" 
                                    ControlToValidate="txtURL" ErrorMessage="Enter Correct URL" Font-Bold="True" 
                                    Font-Size="Medium" ForeColor="Red" 
                                    ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" 
                                    ValidationGroup="Buy"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblAdImage" runat="server" Text="Advertisement Image"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:FileUpload ID="FileUpload1" runat="server" accept="image/*" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="FileUpload1" ErrorMessage="Must Choose Ad Image" 
                                    ForeColor="Red" ValidationGroup="Buy">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegExValFileUploadFileType0" runat="server" 
                                    ControlToValidate="FileUpload1" 
                                    ErrorMessage="Only .jpg,.png,.jpeg,.gif Files are allowed" Font-Bold="True" 
                                    Font-Size="Medium" ForeColor="Red" 
                                    ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" 
                                    ValidationGroup="Buy"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnBuy" runat="server" onclick="btnBuy_Click" 
                                    Text="Proceed to check out" UseSubmitBehavior="False" ValidationGroup="Buy" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="panelCC" runat="server" BackColor="#CCCCCC" Visible="False">
                    <table class="style1">
                        <tr>
                            <td align="center" class="style1003" colspan="3">
                                <asp:Button ID="btnBack" runat="server" CssClass="style999" 
                                    onclick="btnBack_Click" Text="X" />
                                <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="Payment"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1003">
                                <asp:Label ID="lblCCType" runat="server" Text="Credit Card Type"></asp:Label>
                            </td>
                            <td class="style1002">
                                <asp:DropDownList ID="dropListType" runat="server">
                                    <asp:ListItem Value="0">Credit Card</asp:ListItem>
                                    <asp:ListItem>Visa</asp:ListItem>
                                    <asp:ListItem>MasterCard</asp:ListItem>
                                    <asp:ListItem>Chase</asp:ListItem>
                                    <asp:ListItem>American Express</asp:ListItem>
                                    <asp:ListItem>Citibank</asp:ListItem>
                                    <asp:ListItem>Capital One</asp:ListItem>
                                    <asp:ListItem>Bank of America</asp:ListItem>
                                    <asp:ListItem>Wells Fargo</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ControlToValidate="dropListType" ErrorMessage="Must Insert Type" 
                                    ForeColor="Red" InitialValue="0" ValidationGroup="Checkout">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1004">
                                <asp:Label ID="lblOwnerID0" runat="server" Text="Enter your ID"></asp:Label>
                            </td>
                            <td class="style1005">
                                <asp:TextBox ID="txtOwnerID" runat="server" Width="227px"></asp:TextBox>
                            </td>
                            <td align="left" class="style1006">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ErrorMessage="Must Insert ID" ForeColor="Red" 
                                    ControlToValidate="txtOwnerID" ValidationGroup="Checkout">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1003">
                                <asp:Label ID="lblCCNumber0" runat="server" Text="Credit Card Number"></asp:Label>
                            </td>
                            <td class="style1002">
                                <asp:TextBox ID="txtCardNumber" runat="server" Width="227px"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                    ErrorMessage="Muse Insert Card Number" ForeColor="Red" 
                                    ControlToValidate="txtCardNumber" ValidationGroup="Checkout">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1003">
                                <asp:Label ID="lblCCcvv" runat="server" Text="Credit Card Cvv"></asp:Label>
                            </td>
                            <td class="style1002">
                                <asp:TextBox ID="txtCvv" runat="server" Width="227px"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                    ErrorMessage="Must Insert Cvv" ForeColor="Red" 
                                    ControlToValidate="txtCardNumber" ValidationGroup="Checkout">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1003">
                                <asp:Label ID="lblCCExpiration1" runat="server" Text="Expiration Date"></asp:Label>
                            </td>
                            <td class="style1002">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="dropListMonth" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="dropListMonth_SelectedIndexChanged">
                                            <asp:ListItem Value="0">Month</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="dropListYear" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="dropListYear_SelectedIndexChanged">
                                            <asp:ListItem Value="0">Year</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtExpirationDate" Text="0" runat="server" CssClass="hidden"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                    ErrorMessage="Must insert Expiration date" 
                                    ControlToValidate="txtExpirationDate" ForeColor="Red" InitialValue="0" 
                                    ValidationGroup="Checkout">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style1003" colspan="3">
                                <asp:Button ID="btnCheckout" runat="server" Text="Check Out" 
                                    ValidationGroup="Checkout" onclick="btnCheckout_Click" />
                                <asp:Label ID="lblResult" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

