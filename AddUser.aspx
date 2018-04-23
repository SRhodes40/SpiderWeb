<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <link rel="stylesheet" type="text/css" href="Style.css"/>
    <title>Project SpiderWeb User Creation</title>
</head>
<body>
    <h2>Project SpiderWeb Add User Page</h2>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="UserNamelbl" runat="server" Text="User Name: "></asp:Label>
      &nbsp;&nbsp;
        <asp:TextBox ID="UserNametxt" runat="server" BorderStyle="Double"></asp:TextBox>
        <p>
            <asp:Label ID="Passwordlbl" runat="server" Text="Password:"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="Passwordtxt" runat="server" TextMode="Password" BorderStyle="Double"></asp:TextBox>
        </p>
        <asp:Button ID="Loginbtn" runat="server" OnClick="Button1_Click" Text="Create New User" BorderStyle="Double" />
        <asp:Label ID="Loginlbl" runat="server" Text=""></asp:Label>
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Delete User" BorderStyle="Double" />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </p>
    </form>
    <br />
</body>
</html>