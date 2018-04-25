<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <link rel="stylesheet" type="text/css" href="Style.css"/>
    <link rel="shortcut icon" type="image/png" href="Favicon/spider.png"/>
    <title>Project SpiderWeb Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <h2 style="background-color: #6699FF; border-style: ridge">Project SpiderWeb Login</h2>
    
        </div>
        <asp:Label ID="UserNamelbl" runat="server" Text="User Name: "></asp:Label>
      &nbsp;&nbsp;
        <asp:TextBox ID="UserNametxt" runat="server" BorderStyle="Double"></asp:TextBox>
        <p>
            <asp:Label ID="Passwordlbl" runat="server" Text="Password:"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="Passwordtxt" runat="server" TextMode="Password" BorderStyle="Double"></asp:TextBox>
        </p>
        <asp:Button ID="Loginbtn" runat="server" OnClick="Button1_Click" Text="Login" BorderStyle="Double" />
        <asp:Label ID="Loginlbl" runat="server" Text=""></asp:Label>
    </form>
    <br />
</body>
 
</html>
