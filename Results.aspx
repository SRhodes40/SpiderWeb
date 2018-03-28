<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Results.aspx.cs" Inherits="Results" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project SpiderWeb Results</title>
</head>
<body>
    <h2>Project SpiderWeb Results</h2>
    <form id="form1" runat="server">
        <div>
            <asp:Menu ID="Menu2" runat="server" DataSourceID="SiteMapSDS2" Orientation="Horizontal" RenderingMode="Table" StaticDisplayLevels="2">
            </asp:Menu>
            <asp:SiteMapDataSource ID="SiteMapSDS2" runat="server" />
        </div>
    </form>
</body>
</html>
