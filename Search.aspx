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
            <asp:Button ID="studentsearchBtn" runat="server" Text="Search" OnClick="studentsearchBtn_Click" />
            <asp:DataList ID="studentDL" runat="server" DataKeyField="StudentNumber" DataSourceID="spiderwebDdb" Visible="False">
                <ItemTemplate>
                    FirstName:
                    <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                    <br />
                    LastName:
                    <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                    <br />
                    MiddleInitial:
                    <asp:Label ID="MiddleInitialLabel" runat="server" Text='<%# Eval("MiddleInitial") %>' />
                    <br />
                    Age:
                    <asp:Label ID="AgeLabel" runat="server" Text='<%# Eval("Age") %>' />
                    <br />
                    GPA:
                    <asp:Label ID="GPALabel" runat="server" Text='<%# Eval("GPA") %>' />
                    <br />
                    StudentNumber:
                    <asp:Label ID="StudentNumberLabel" runat="server" Text='<%# Eval("StudentNumber") %>' />
                    <br />
                    ClassYear:
                    <asp:Label ID="ClassYearLabel" runat="server" Text='<%# Eval("ClassYear") %>' />
                    <br />
                    MajorCode:
                    <asp:Label ID="MajorCodeLabel" runat="server" Text='<%# Eval("MajorCode") %>' />
                    <br />
                    MinorCode:
                    <asp:Label ID="MinorCodeLabel" runat="server" Text='<%# Eval("MinorCode") %>' />
                    <br />
                    CourseNumber:
                    <asp:Label ID="CourseNumberLabel" runat="server" Text='<%# Eval("CourseNumber") %>' />
                    <br />
                    NumberOfCredits:
                    <asp:Label ID="NumberOfCreditsLabel" runat="server" Text='<%# Eval("NumberOfCredits") %>' />
                    <br />
                    Grade:
                    <asp:Label ID="GradeLabel" runat="server" Text='<%# Eval("Grade") %>' />
                    <br />
                    InProgress:
                    <asp:Label ID="InProgressLabel" runat="server" Text='<%# Eval("InProgress") %>' />
                    <br />
<br />
                </ItemTemplate>
            </asp:DataList>
        </p>
        <asp:SqlDataSource ID="spiderwebDdb" runat="server" ConnectionString="<%$ ConnectionStrings:SpiderWebConnectionString %>" SelectCommand="SELECT DISTINCT Student.FirstName, Student.LastName, Student.MiddleInitial, Student.Age, Student.GPA, Student.StudentNumber, Student.ClassYear, Major.MajorCode, Minor.MinorCode, Course.CourseNumber, Course.NumberOfCredits, StudentHasCourse.Grade, StudentHasCourse.InProgress FROM Student INNER JOIN StudentHasMajor ON Student.StudentNumber = StudentHasMajor.StudentNumber INNER JOIN Major ON StudentHasMajor.MajorCode = Major.MajorCode INNER JOIN StudentHasMinor ON StudentHasMinor.StudentNumber = Student.StudentNumber INNER JOIN Minor ON StudentHasMinor.MinorCode = Minor.MinorCode INNER JOIN StudentHasCourse ON Student.StudentNumber = StudentHasCourse.StudentNumber INNER JOIN Course ON StudentHasCourse.CourseNumber = Course.CourseNumber CROSS JOIN GPAReference"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="StudentNumber,MajorCode,MinorCode" DataSourceID="spiderwebDdb" Visible="False">
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
