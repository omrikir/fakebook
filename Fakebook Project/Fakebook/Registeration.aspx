<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Registeration.aspx.cs" Inherits="Registeration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style23
        {
            width: 100%;
        }
        .style25
        {
            height: 82px;
        }
        .style27
    {
        }
        .style28
        {
            width: 384px;
            height: 20px;
        }
        .style30
        {
            height: 20px;
        }
        .style34
        {
            width: 384px;
        }
        .style35
        {
            width: 384px;
            height: 25px;
        }
        .style37
        {
            height: 25px;
        }
        .style38
        {
            width: 384px;
            height: 26px;
        }
        .style40
        {
        }
        .style41
        {
            width: 324px;
        }
        .style42
        {
            width: 324px;
            height: 25px;
        }
        .style43
        {
            width: 324px;
            height: 26px;
        }
        .style44
        {
            width: 324px;
            height: 20px;
        }
        .style45
        {
            height: 26px;
        }
        .style46
        {
            width: 384px;
            height: 36px;
        }
        .style47
        {
            width: 324px;
            height: 36px;
        }
        .style48
        {
            height: 36px;
        }
        .hidden
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style23">
        <tr>
            <td align="center" class="style25" colspan="4">
                <div style="margin-bottom: 5px; font-size: 40px; font-weight: normal; color: rgb(29, 33, 41); font-family: &quot;Freight Sans Bold&quot;, Helvetica, Arial, sans-serif; white-space: nowrap; letter-spacing: normal; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; orphans: 2;">
                    Create a New Account</div>
                <div style="font-size: 22px; font-weight: normal; color: rgb(75, 79, 86); font-family: &quot;Freight Sans&quot;, Helvetica, Arial, sans-serif; line-height: 28px; letter-spacing: normal; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; orphans: 2;">
                    It’s free and always will be.</div>
            </td>
        </tr>
        <tr>
                                <td class="style34" align="center">
                                    First Name</td>
            <td class="style41" align="center">
                        <asp:TextBox ID="txtFirstName" runat="server" Width="319px"></asp:TextBox>
                                </td>
            <td colspan="2">
                <asp:RequiredFieldValidator ID="requiredFirstName" runat="server" 
                    ControlToValidate="txtFirstName" ErrorMessage="*" ForeColor="Red" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtFirstName" 
                    ErrorMessage="1-40 characters, no spaces, allows '" ForeColor="Red" 
                    SetFocusOnError="True" ValidationExpression="^[a-zA-Z']{1,40}$"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtPassConfirm" ControlToValidate="txtPassReg" 
                    ErrorMessage="Passwords must match" ForeColor="Red"></asp:CompareValidator>
                                </td>
        </tr>
        <tr>
                                <td class="style38" align="center">
                                    Last Name</td>
            <td class="style43" align="center">
                        <asp:TextBox ID="txtLastName" runat="server" Width="319px"></asp:TextBox>
                                </td>
            <td class="style45" colspan="2">
                <asp:RequiredFieldValidator ID="requiredLastName" runat="server" 
                    ControlToValidate="txtLastName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtLastName" ErrorMessage="1-40 characters, no spaces, allows '" 
                    ForeColor="Red" SetFocusOnError="True" 
                    ValidationExpression="^[a-zA-Z']{1,40}$"></asp:RegularExpressionValidator>
                                </td>
        </tr>
        <tr>
                                <td class="style35" align="center">
                                    Email</td>
            <td class="style42" align="center">
                        <asp:TextBox ID="txtEmailReg" runat="server" Width="319px"></asp:TextBox>
                                </td>
            <td class="style37" colspan="2">
                                <asp:RequiredFieldValidator ID="requiredEmail" runat="server" 
                                    ControlToValidate="txtEmailReg" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                    ControlToValidate="txtEmailReg" ErrorMessage="Invalid email" 
                                    ForeColor="Red" 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </td>
        </tr>
        <tr>
                                <td class="style38" align="center">
                                    Password</td>
            <td class="style43" align="center">
                        <asp:TextBox ID="txtPassReg" runat="server" Width="319px" 
                    TextMode="Password"></asp:TextBox>
                                </td>
            <td class="style45">
                                <asp:RequiredFieldValidator ID="requiredPassword" runat="server" 
                                    ControlToValidate="txtPassReg" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                    ControlToValidate="txtPassReg" 
                                    ErrorMessage="4 to 12 characters. At least one alphabet character and one number." 
                                    ForeColor="Red" 
                                    ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{4,12})$"></asp:RegularExpressionValidator>
                                </td>
            <td class="style40" rowspan="2">
                                &nbsp;</td>
        </tr>
        <tr>
                                <td class="style46" align="center">
                                    Confirm 
                                    <br />
                                   Password</td>
            <td class="style47" align="center">
                        <asp:TextBox ID="txtPassConfirm" runat="server" Width="319px" 
                            TextMode="Password"></asp:TextBox>
                                </td>
            <td class="style48">
                &nbsp;</td>
        </tr>
        <tr>
                                <td class="style34" align="center">
                                    Birthday</td>
            <td class="style41" align="center">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="dropListDay" runat="server" ValidationGroup="Birthday" 
                           CssClass="hidden">
                        <asp:ListItem Selected="True" Value="0">Day</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                        <asp:ListItem Value="13">13</asp:ListItem>
                        <asp:ListItem Value="14">14</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <asp:ListItem Value="16">16</asp:ListItem>
                        <asp:ListItem Value="17">17</asp:ListItem>
                        <asp:ListItem Value="18">18</asp:ListItem>
                        <asp:ListItem Value="19">19</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="21">21</asp:ListItem>
                        <asp:ListItem Value="22">22</asp:ListItem>
                        <asp:ListItem Value="23">23</asp:ListItem>
                        <asp:ListItem Value="24">24</asp:ListItem>
                        <asp:ListItem Value="25">25</asp:ListItem>
                        <asp:ListItem Value="26">26</asp:ListItem>
                        <asp:ListItem Value="27">27</asp:ListItem>
                        <asp:ListItem Value="28">28</asp:ListItem>
                        <asp:ListItem Value="29">29</asp:ListItem>
                        <asp:ListItem Value="30">30</asp:ListItem>
                        <asp:ListItem Value="31">31</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="dropListMonth" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="dropListMonth_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">Month</asp:ListItem>
                        <asp:ListItem Value="1">Jan</asp:ListItem>
                        <asp:ListItem Value="2">Feb</asp:ListItem>
                        <asp:ListItem Value="3">Mar</asp:ListItem>
                        <asp:ListItem Value="4">Apr</asp:ListItem>
                        <asp:ListItem Value="5">May</asp:ListItem>
                        <asp:ListItem Value="6">Jun</asp:ListItem>
                        <asp:ListItem Value="7">Jul</asp:ListItem>
                        <asp:ListItem Value="8">Aug</asp:ListItem>
                        <asp:ListItem Value="9">Sep</asp:ListItem>
                        <asp:ListItem Value="10">Oct</asp:ListItem>
                        <asp:ListItem Value="11">Nov</asp:ListItem>
                        <asp:ListItem Value="12">Dec</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="dropListYear" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="dropListYear_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">Year</asp:ListItem>
                        <asp:ListItem Value="2017">2017</asp:ListItem>
                        <asp:ListItem Value="2016">2016</asp:ListItem>
                        <asp:ListItem Value="2015">2015</asp:ListItem>
                        <asp:ListItem Value="2014">2014</asp:ListItem>
                        <asp:ListItem Value="2013">2013</asp:ListItem>
                        <asp:ListItem Value="2012">2012</asp:ListItem>
                        <asp:ListItem Value="2011">2011</asp:ListItem>
                        <asp:ListItem Value="2010">2010</asp:ListItem>
                        <asp:ListItem Value="2009">2009</asp:ListItem>
                        <asp:ListItem Value="2008">2008</asp:ListItem>
                        <asp:ListItem Value="2007">2007</asp:ListItem>
                        <asp:ListItem Value="2006">2006</asp:ListItem>
                        <asp:ListItem Value="2005">2005</asp:ListItem>
                        <asp:ListItem Value="2004">2004</asp:ListItem>
                        <asp:ListItem Value="2003">2003</asp:ListItem>
                        <asp:ListItem Value="2002">2002</asp:ListItem>
                        <asp:ListItem Value="2001">2001</asp:ListItem>
                        <asp:ListItem Value="2000">2000</asp:ListItem>
                        <asp:ListItem Value="1999">1999</asp:ListItem>
                        <asp:ListItem Value="1998">1998</asp:ListItem>
                        <asp:ListItem Value="1997">1997</asp:ListItem>
                        <asp:ListItem Value="1996">1996</asp:ListItem>
                        <asp:ListItem Value="1995">1995</asp:ListItem>
                        <asp:ListItem Value="1994">1994</asp:ListItem>
                        <asp:ListItem Value="1993">1993</asp:ListItem>
                        <asp:ListItem Value="1992">1992</asp:ListItem>
                        <asp:ListItem Value="1991">1991</asp:ListItem>
                        <asp:ListItem Value="1990">1990</asp:ListItem>
                        <asp:ListItem Value="1989">1989</asp:ListItem>
                        <asp:ListItem Value="1988">1988</asp:ListItem>
                        <asp:ListItem Value="1987">1987</asp:ListItem>
                        <asp:ListItem Value="1986">1986</asp:ListItem>
                        <asp:ListItem Value="1985">1985</asp:ListItem>
                        <asp:ListItem Value="1984">1984</asp:ListItem>
                        <asp:ListItem Value="1983">1983</asp:ListItem>
                        <asp:ListItem Value="1982">1982</asp:ListItem>
                        <asp:ListItem Value="1981">1981</asp:ListItem>
                        <asp:ListItem Value="1980">1980</asp:ListItem>
                        <asp:ListItem Value="1979">1979</asp:ListItem>
                        <asp:ListItem Value="1978">1978</asp:ListItem>
                        <asp:ListItem Value="1977">1977</asp:ListItem>
                        <asp:ListItem Value="1976">1976</asp:ListItem>
                        <asp:ListItem Value="1975">1975</asp:ListItem>
                        <asp:ListItem Value="1974">1974</asp:ListItem>
                        <asp:ListItem Value="1973">1973</asp:ListItem>
                        <asp:ListItem Value="1972">1972</asp:ListItem>
                        <asp:ListItem Value="1971">1971</asp:ListItem>
                        <asp:ListItem Value="1970">1970</asp:ListItem>
                        <asp:ListItem Value="1969">1969</asp:ListItem>
                        <asp:ListItem Value="1968">1968</asp:ListItem>
                        <asp:ListItem Value="1967">1967</asp:ListItem>
                        <asp:ListItem Value="1966">1966</asp:ListItem>
                        <asp:ListItem Value="1965">1965</asp:ListItem>
                        <asp:ListItem Value="1964">1964</asp:ListItem>
                        <asp:ListItem Value="1963">1963</asp:ListItem>
                        <asp:ListItem Value="1962">1962</asp:ListItem>
                        <asp:ListItem Value="1961">1961</asp:ListItem>
                        <asp:ListItem Value="1960">1960</asp:ListItem>
                        <asp:ListItem Value="1959">1959</asp:ListItem>
                        <asp:ListItem Value="1958">1958</asp:ListItem>
                        <asp:ListItem Value="1957">1957</asp:ListItem>
                        <asp:ListItem Value="1956">1956</asp:ListItem>
                        <asp:ListItem Value="1955">1955</asp:ListItem>
                        <asp:ListItem Value="1954">1954</asp:ListItem>
                        <asp:ListItem Value="1953">1953</asp:ListItem>
                        <asp:ListItem Value="1952">1952</asp:ListItem>
                        <asp:ListItem Value="1951">1951</asp:ListItem>
                        <asp:ListItem Value="1950">1950</asp:ListItem>
                        <asp:ListItem Value="1949">1949</asp:ListItem>
                        <asp:ListItem Value="1948">1948</asp:ListItem>
                        <asp:ListItem Value="1947">1947</asp:ListItem>
                        <asp:ListItem Value="1946">1946</asp:ListItem>
                        <asp:ListItem Value="1945">1945</asp:ListItem>
                        <asp:ListItem Value="1944">1944</asp:ListItem>
                        <asp:ListItem Value="1943">1943</asp:ListItem>
                        <asp:ListItem Value="1942">1942</asp:ListItem>
                        <asp:ListItem Value="1941">1941</asp:ListItem>
                        <asp:ListItem Value="1940">1940</asp:ListItem>
                        <asp:ListItem Value="1939">1939</asp:ListItem>
                        <asp:ListItem Value="1938">1938</asp:ListItem>
                        <asp:ListItem Value="1937">1937</asp:ListItem>
                        <asp:ListItem Value="1936">1936</asp:ListItem>
                        <asp:ListItem Value="1935">1935</asp:ListItem>
                        <asp:ListItem Value="1934">1934</asp:ListItem>
                        <asp:ListItem Value="1933">1933</asp:ListItem>
                        <asp:ListItem Value="1932">1932</asp:ListItem>
                        <asp:ListItem Value="1931">1931</asp:ListItem>
                        <asp:ListItem Value="1930">1930</asp:ListItem>
                        <asp:ListItem Value="1929">1929</asp:ListItem>
                        <asp:ListItem Value="1928">1928</asp:ListItem>
                        <asp:ListItem Value="1927">1927</asp:ListItem>
                        <asp:ListItem Value="1926">1926</asp:ListItem>
                        <asp:ListItem Value="1925">1925</asp:ListItem>
                        <asp:ListItem Value="1924">1924</asp:ListItem>
                        <asp:ListItem Value="1923">1923</asp:ListItem>
                        <asp:ListItem Value="1922">1922</asp:ListItem>
                        <asp:ListItem Value="1921">1921</asp:ListItem>
                        <asp:ListItem Value="1920">1920</asp:ListItem>
                        <asp:ListItem Value="1919">1919</asp:ListItem>
                        <asp:ListItem Value="1918">1918</asp:ListItem>
                        <asp:ListItem Value="1917">1917</asp:ListItem>
                        <asp:ListItem Value="1916">1916</asp:ListItem>
                        <asp:ListItem Value="1915">1915</asp:ListItem>
                        <asp:ListItem Value="1914">1914</asp:ListItem>
                        <asp:ListItem Value="1913">1913</asp:ListItem>
                        <asp:ListItem Value="1912">1912</asp:ListItem>
                        <asp:ListItem Value="1911">1911</asp:ListItem>
                        <asp:ListItem Value="1910">1910</asp:ListItem>
                        <asp:ListItem Value="1909">1909</asp:ListItem>
                        <asp:ListItem Value="1908">1908</asp:ListItem>
                        <asp:ListItem Value="1907">1907</asp:ListItem>
                        <asp:ListItem Value="1906">1906</asp:ListItem>
                        <asp:ListItem Value="1905">1905</asp:ListItem>
                    </asp:DropDownList>
                </ContentTemplate>
                        </asp:UpdatePanel>
                                </td>
            <td colspan="2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate="dropListDay" 
                    ErrorMessage="Must enter birthday" InitialValue="0" ForeColor="Red">*</asp:RequiredFieldValidator>
                                
                                </td>
        </tr>
        <tr>
                                <td class="style28" align="center">
                                    Gender</td>
            <td class="style44" align="center">
                                    <asp:RadioButtonList ID="radioGender" runat="server" RepeatColumns="2">
                                        <asp:ListItem Value="Male">Male</asp:ListItem>
                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
            <td class="style30" colspan="2">
                                <asp:RequiredFieldValidator ID="requiredGender" runat="server" 
                                    ControlToValidate="radioGender" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
        </tr>
        <tr>
            <td class="style27" align="center" colspan="4">
                                    <asp:Button ID="btnRegister" runat="server" Text="Create Account" 
                                        onclick="btnRegister_Click" />
                                    <asp:Label ID="lblError" runat="server"></asp:Label>
                                </td>
        </tr>
        </table>
</asp:Content>

