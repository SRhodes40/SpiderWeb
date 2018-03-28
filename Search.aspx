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
            <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSDS4" Orientation="Horizontal" RenderingMode="Table" StaticDisplayLevels="2">
            </asp:Menu>
            <asp:SiteMapDataSource ID="SiteMapDataSDS4" runat="server" />
            &nbsp
        &nbsp
        &nbsp
        &nbsp
        &nbsp
        </div>
     
        <asp:Label ID="studentsearchLbl" runat="server" Text="Enter Student Name:"></asp:Label>
        &nbsp
        <asp:TextBox ID="studentTxt" runat="server"></asp:TextBox>
        &nbsp
        &nbsp
        &nbsp
        &nbsp
        &nbsp
        <asp:Label ID="coursesearchLbl" runat="server" Text="Enter Course Code:"></asp:Label>
        &nbsp
        <asp:TextBox ID="courseTxt" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="coursesearchBtn" runat="server" Text="Search" OnClick="searchcourseBtn_Click" />
        </p>
        <asp:SqlDataSource ID="spiderwebDdb" runat="server" ConnectionString="<%$ ConnectionStrings:SpiderWebConnectionString %>" SelectCommand="SELECT DISTINCT FirstName, LastName,  MiddleInitial, Age, GPA, Student.StudentNumber ,ClassYear, Major.MajorCode, Minor.MinorCode FROM (((([Student] JOIN [StudentHasMajor] ON [Student].StudentNumber = [StudentHasMajor].StudentNumber) JOIN [Major] ON [StudentHasMajor].MajorCode = [Major].MajorCode)  JOIN [StudentHasMinor] ON [StudentHasMinor].StudentNumber=[Student].StudentNumber)  JOIN [Minor] ON [StudentHasMinor].MinorCode = [Minor].MinorCode)"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="StudentNumber,MajorCode,MinorCode" DataSourceID="spiderwebDdb">
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="MiddleInitial" HeaderText="MiddleInitial" SortExpression="MiddleInitial" />
                <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                <asp:BoundField DataField="GPA" HeaderText="GPA" SortExpression="GPA" />
                <asp:BoundField DataField="StudentNumber" HeaderText="StudentNumber" ReadOnly="True" SortExpression="StudentNumber" />
                <asp:BoundField DataField="ClassYear" HeaderText="ClassYear" SortExpression="ClassYear" />
                <asp:BoundField DataField="MajorCode" HeaderText="MajorCode" ReadOnly="True" SortExpression="MajorCode" />
                <asp:BoundField DataField="MinorCode" HeaderText="MinorCode" SortExpression="MinorCode" ReadOnly="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
