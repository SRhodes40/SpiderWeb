<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Modify.aspx.cs" Inherits="Modify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Style.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <h2 style="background-color: #6699FF; border-style: ridge">Project SpiderWeb Modify Page</h2>
    
             <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1" Orientation="Horizontal" RenderingMode="Table" StaticDisplayLevels="2" OnMenuItemClick="Menu1_MenuItemClick">
            </asp:Menu>
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        </div>
        <asp:GridView ID="studentgv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="Studentddb" OnRowDeleted="studentgv_RowDeleted" OnRowDeleting="studentgv_RowDeleting" OnRowEditing="studentgv_RowEditing" OnRowUpdated="studentgv_RowUpdated">
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="StudentNumber" HeaderText="StudentNumber" SortExpression="StudentNumber" />
                <asp:BoundField DataField="CourseNumber" HeaderText="CourseNumber" SortExpression="CourseNumber" />
                <asp:BoundField DataField="InProgress" HeaderText="InProgress" SortExpression="InProgress" />
                <asp:BoundField DataField="Grade" HeaderText="Grade" SortExpression="Grade" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="Studentddb" runat="server" ConnectionString="<%$ ConnectionStrings:SpiderWebConnectionString %>" SelectCommand="SELECT Student.FirstName, Student.LastName, StudentHasCourse.StudentNumber, StudentHasCourse.CourseNumber, StudentHasCourse.InProgress, StudentHasCourse.Grade FROM StudentHasCourse INNER JOIN Student ON StudentHasCourse.StudentNumber = Student.StudentNumber ORDER BY StudentHasCourse.StudentNumber" UpdateCommand="UPDATE StudentHasCourse SET InProgress = InProgress, Grade = Grade" InsertCommand="INSERT INTO StudentHasCourse(InProgress, Grade, CourseNumber, StudentNumber) VALUES (,,,)">
        </asp:SqlDataSource>
        <p>
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
        </p>
        <asp:Label ID="stunumbLbl" runat="server" Text="Student Number:"></asp:Label>
        &nbsp;<asp:TextBox ID="stunumbTxt" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="coursenumbLbl" runat="server" Text="Course Number:"></asp:Label>
        &nbsp;<asp:TextBox ID="coursenumbTxt" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="progressLbl" runat="server" Text="In Progress? (Y/N)"></asp:Label>
        &nbsp;<asp:TextBox ID="progressTxt" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="gradeLbl" runat="server" Text="Grade:"></asp:Label>
        &nbsp;<asp:TextBox ID="gradeTxt" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="insertBtn" runat="server" Text="Insert" OnClick="insertBtn_Click" />
        &nbsp;
        <asp:Button ID="deleteBtn" runat="server" Text="Delete" OnClick="deleteBtn_Click" />
        &nbsp;
        <asp:Button ID="modifyBtn" runat="server" Text="Modify Student" OnClick="modifyBtn_Click" Visible="False" />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
