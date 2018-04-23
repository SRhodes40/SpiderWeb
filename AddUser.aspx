<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <link rel="stylesheet" type="text/css" href="Style.css"/>
    <title>Project SpiderWeb User Creation</title>
</head>
<body>
   <h2 style="background-color: #6699FF; border-style: ridge">Project SpiderWeb Add New User</h2>
    <form id="form1" runat="server">
             <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource2" Orientation="Horizontal" RenderingMode="Table" StaticDisplayLevels="2" >
                 <StaticHoverStyle BackColor="#6699FF" />
                 <StaticMenuStyle BackColor="White" BorderColor="#000066" BorderStyle="Double" />
            </asp:Menu>
             <asp:SiteMapDataSource ID="SiteMapDataSource2" runat="server" />
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
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Delete User" BorderStyle="Double" />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </p>
    </form>
    <br />
</body>
</html>