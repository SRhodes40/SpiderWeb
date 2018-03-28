<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project SpiderWeb Search</title>
    <link rel="stylesheet" type="text/css" href="Style.css"/>
</head>
<body>
    <h2>Project SpiderWeb Search Page</h2>
    <form id="form1" runat="server">
        <div>
            <asp:Menu ID="Menu2" runat="server" DataSourceID="SiteMapDataSDS3" Orientation="Horizontal" RenderingMode="Table" StaticDisplayLevels="2">
            </asp:Menu>
            <asp:SiteMapDataSource ID="SiteMapDataSDS3" runat="server" />
        </div>
    </form>
</body>
</html>
