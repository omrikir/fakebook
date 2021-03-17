<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UsersManager.aspx.cs" Inherits="UsersManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        onpageindexchanging="GridView1_PageIndexChanging" 
        onrowcancelingedit="GridView1_RowCancelingEdit" 
        onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
        onrowupdating="GridView1_RowUpdating">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="Password" HeaderText="Password" />
            <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" ReadOnly="True" />
            <asp:BoundField DataField="Birthday" HeaderText="Birthday" ReadOnly="True" />
            <asp:BoundField DataField="UserID" HeaderText="User ID" ReadOnly="True" />
            <asp:ImageField DataImageUrlField="ProfileImage" HeaderText="Profile Image" 
                ReadOnly="True">
                <ControlStyle Height="90px" Width="90px" />
            </asp:ImageField>
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <br />

</asp:Content>

