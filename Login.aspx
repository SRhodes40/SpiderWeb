<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <link rel="stylesheet" type="text/css" href="Style.css"/>
    <title>Project SpiderWeb Login</title>
</head>
<body>
    <h2>Project SpiderWeb Login Page</h2>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="UserNamelbl" runat="server" Text="User Name: "></asp:Label>
      &nbsp;&nbsp;
        <asp:TextBox ID="UserNametxt" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Passwordlbl" runat="server" Text="Password:"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="Passwordtxt" runat="server"></asp:TextBox>
        </p>
    </form>
</body>
    <a href="Search.aspx">Other Navigation Pages, Admin View Only</a>
</html>
