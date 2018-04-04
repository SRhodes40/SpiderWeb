<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project SpiderWeb Change Password</title>
    <link rel="stylesheet" type="text/css" href="Style.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <h2>Project SpiderWeb Change Password</h2>
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
        <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
        <p>
            <asp:Label ID="NewPasswordlbl" runat="server" Text="New Password:"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <asp:Label ID="ConfirmPasswordlbl" runat="server" Text="Confirm Password:"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
        <p>
            <asp:Button ID="btnChangePassword" runat="server" OnClick="btnChangePassword_Click" Text="Change Password" />
            <asp:Label ID="lblPasswordChanged" runat="server" EnableViewState="False"></asp:Label>
        </p>
    </form>
</body>
</html>
