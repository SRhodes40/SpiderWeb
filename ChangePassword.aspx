<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project SpiderWeb Change Password</title>
    <link rel="stylesheet" type="text/css" href="Style.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <h2>Project SpiderWeb Change Password<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </h2>
        <div>
            <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapSDS" Orientation="Horizontal" RenderingMode="Table" StaticDisplayLevels="2">
            </asp:Menu>
            <asp:SiteMapDataSource ID="SiteMapSDS" runat="server" />
            &nbsp;&nbsp;
            &nbsp;&nbsp;
            &nbsp;&nbsp;
            &nbsp;&nbsp;
            &nbsp;&nbsp;
        </div>
        <asp:Label ID="OldPasswordlbl" runat="server" Text="Old Password:"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="NewPasswordlbl" runat="server" Text="New Password:"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="ConfirmPasswordlbl" runat="server" Text="Confirm Password:"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </form>
</body>
</html>
