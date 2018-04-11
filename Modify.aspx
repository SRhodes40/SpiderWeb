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
            <asp:Label ID="modifyLbl" runat="server" Text="Modify or Add Student"></asp:Label>
             <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1" Orientation="Horizontal" RenderingMode="Table" StaticDisplayLevels="2">
            </asp:Menu>
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="StudentNumber,MajorCode,MinorCode,CourseNumber" DataSourceID="Studentddb">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="MiddleInitial" HeaderText="MiddleInitial" SortExpression="MiddleInitial" />
                <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                <asp:BoundField DataField="GPA" HeaderText="GPA" SortExpression="GPA" />
                <asp:BoundField DataField="StudentNumber" HeaderText="StudentNumber" ReadOnly="True" SortExpression="StudentNumber" />
                <asp:BoundField DataField="ClassYear" HeaderText="ClassYear" SortExpression="ClassYear" />
                <asp:BoundField DataField="MajorCode" HeaderText="MajorCode" ReadOnly="True" SortExpression="MajorCode" />
                <asp:BoundField DataField="MinorCode" HeaderText="MinorCode" ReadOnly="True" SortExpression="MinorCode" />
                <asp:BoundField DataField="CourseNumber" HeaderText="CourseNumber" ReadOnly="True" SortExpression="CourseNumber" />
                <asp:BoundField DataField="NumberOfCredits" HeaderText="NumberOfCredits" SortExpression="NumberOfCredits" />
                <asp:BoundField DataField="Grade" HeaderText="Grade" SortExpression="Grade" />
                <asp:BoundField DataField="InProgress" HeaderText="InProgress" SortExpression="InProgress" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="Studentddb" runat="server" ConnectionString="<%$ ConnectionStrings:SpiderWebConnectionString %>" DeleteCommand="DELETE FROM Student" SelectCommand="SELECT DISTINCT Student.FirstName, Student.LastName, Student.MiddleInitial, Student.Age, Student.GPA, Student.StudentNumber, Student.ClassYear, Major.MajorCode, Minor.MinorCode, Course.CourseNumber, Course.NumberOfCredits, StudentHasCourse.Grade, StudentHasCourse.InProgress FROM Student INNER JOIN StudentHasMajor ON Student.StudentNumber = StudentHasMajor.StudentNumber INNER JOIN Major ON StudentHasMajor.MajorCode = Major.MajorCode INNER JOIN StudentHasMinor ON StudentHasMinor.StudentNumber = Student.StudentNumber INNER JOIN Minor ON StudentHasMinor.MinorCode = Minor.MinorCode INNER JOIN StudentHasCourse ON Student.StudentNumber = StudentHasCourse.StudentNumber INNER JOIN Course ON StudentHasCourse.CourseNumber = Course.CourseNumber CROSS JOIN GPAReference" UpdateCommand="UPDATE Student, Course SET FirstName =, LastName =, MiddleInitial =, Age =, GPA =, StudentNumber =, ClassYear = FROM Student INNER JOIN StudentHasCourse ON Student.StudentNumber = StudentHasCourse.StudentNumber INNER JOIN StudentHasMajor ON Student.StudentNumber = StudentHasMajor.StudentNumber INNER JOIN StudentHasMinor ON Student.StudentNumber = StudentHasMinor.StudentNumber INNER JOIN Course ON StudentHasCourse.CourseNumber = Course.CourseNumber INNER JOIN hasGPA ON Student.StudentNumber = hasGPA.StudentNumber INNER JOIN CoursesInMajor ON Course.CourseNumber = CoursesInMajor.CourseNumber">
        </asp:SqlDataSource>
    </form>
</body>
</html>
