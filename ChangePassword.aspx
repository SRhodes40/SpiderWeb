<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project SpiderWeb Change Password</title>
    <link rel="stylesheet" type="text/css" href="Style.css"/>
</head>
<body>
    <form id="form1" runat="server">
   
        <div>
    <h2 style="background-color: #6699FF; border-style: ridge">&nbsp;Project SpiderWeb Change Password</h2>
             <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1" Orientation="Horizontal" RenderingMode="Table" StaticDisplayLevels="2" OnMenuItemClick="Menu1_MenuItemClick">
                 <StaticHoverStyle BackColor="#6699FF" />
                 <StaticMenuStyle BackColor="White" BorderColor="#000066" BorderStyle="Double" />
            </asp:Menu>
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
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
