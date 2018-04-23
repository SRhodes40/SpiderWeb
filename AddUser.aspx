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
             <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1" Orientation="Horizontal" RenderingMode="Table" StaticDisplayLevels="2" >
                 <StaticHoverStyle BackColor="#6699FF" />
                 <StaticMenuStyle BackColor="White" />
            </asp:Menu>
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        <br />
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
    </form>
    <br />
</body>
</html>