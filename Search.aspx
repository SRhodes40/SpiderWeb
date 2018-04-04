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
     
        <asp:Label ID="studentsearchLbl" runat="server" Text="Enter Student Last Name:"></asp:Label>
        &nbsp
        <asp:TextBox ID="studentTxt" runat="server"></asp:TextBox>
            <asp:Button ID="studentsearchBtn" runat="server" Text="Search Student" OnClick="studentsearchBtn_Click" />
        &nbsp
        &nbsp
        &nbsp
        &nbsp
        &nbsp
        <asp:Label ID="coursesearchLbl" runat="server" Text="Enter Course Code:"></asp:Label>
        &nbsp
        <asp:TextBox ID="courseTxt" runat="server"></asp:TextBox>
        <asp:Button ID="courseBtn" runat="server" Text="Search Course" OnClick="courseBtn_Click" />
        <br />
        <asp:Label ID="returnLbl" runat="server" Text="Please press enter or return when you are finished typing a name." Visible="False"></asp:Label>
        <p>
            <asp:DataList ID="studentDL" runat="server" DataKeyField="StudentNumber" Visible="False">
                <ItemTemplate>
                     Name:
                    <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                    &nbsp
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("MiddleInitial") %>' />
                     &nbsp
                    <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                    <br />
                   
                    
                    
                    Age:
                    <asp:Label ID="AgeLabel" runat="server" Text='<%# Eval("Age") %>' />
                    <br />
                    GPA:
                    <asp:Label ID="GPALabel" runat="server" Text='<%# Eval("GPA") %>' />
                    <br />
                    Student ID Number:
                    <asp:Label ID="StudentNumberLabel" runat="server" Text='<%# Eval("StudentNumber") %>' />
                    <br />
                    Graduation Year:
                    <asp:Label ID="ClassYearLabel" runat="server" Text='<%# Eval("ClassYear") %>' />
                    <br />
                    Major:
                    <asp:Label ID="MajorCodeLabel" runat="server" Text='<%# Eval("MajorCode") %>' />
                    <br />
                    Minor:
                    <asp:Label ID="MinorCodeLabel" runat="server" Text='<%# Eval("MinorCode") %>' />
                    <br />
                    Course Code:
                    <asp:Label ID="CourseNumberLabel" runat="server" Text='<%# Eval("CourseNumber") %>' />
                    <br />
                    Number Of Credits For Course:
                    <asp:Label ID="NumberOfCreditsLabel" runat="server" Text='<%# Eval("NumberOfCredits") %>' />
                    <br />
                    Grade In Course:
                    <asp:Label ID="GradeLabel" runat="server" Text='<%# Eval("Grade") %>' />
                    <br />
                    Is class currently in progress?:
                    <asp:Label ID="InProgressLabel" runat="server" Text='<%# Eval("InProgress") %>' />
                    <br />
<br />
                </ItemTemplate>
              

            </asp:DataList>
          
            <asp:DataList ID="courseDL" runat="server" DataKeyField="CourseNumber" Visible="False">
                <ItemTemplate>
                     Course:
                    <asp:Label ID="CourseLabel" runat="server" Text='<%# Eval("CourseNumber") %>' />
                    <br />
                     Name:
                    <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                    &nbsp
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("MiddleInitial") %>' />
                     &nbsp
                    <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                    <br />
                     Age:
                    <asp:Label ID="AgeLabel" runat="server" Text='<%# Eval("Age") %>' />
                    <br />
                    Student ID Number:
                    <asp:Label ID="StudentNumberLabel" runat="server" Text='<%# Eval("StudentNumber") %>' />
                    <br />
                     GPA:
                    <asp:Label ID="GPALabel" runat="server" Text='<%# Eval("GPA") %>' />
                    <br />

                    Graduation Year:
                    <asp:Label ID="ClassYearLabel" runat="server" Text='<%# Eval("ClassYear") %>' />
                    <br />
                    
                   
                    Number of Credits
                    <asp:Label ID="CreditsLabel" runat="server" Text='<%# Eval("NumberOfCredits") %>' />
                    <br />
                    Course Description
                    <asp:Label ID="CourseDescLabel" runat="server" Text='<%# Eval("CourseDescription") %>' />
                    <br />
                    Grade In Course:
                    <asp:Label ID="GradeLabel" runat="server" Text='<%# Eval("Grade") %>' />
                    <br />
                    Is class currently in progress?:
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
