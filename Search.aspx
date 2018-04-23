<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project SpiderWeb Search</title>
    <link rel="stylesheet" type="text/css" href="Style.css"/>
</head>
<body>
    <h2 style="background-color: #6699FF; border-style: ridge">Project SpiderWeb Search Page</h2>
    
    <form id="form1" runat="server">
        <div>
            <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1" Orientation="Horizontal" RenderingMode="Table" StaticDisplayLevels="2" OnMenuItemClick="Menu1_MenuItemClick">
                <StaticMenuStyle BackColor="White" BorderColor="#000066" BorderStyle="Solid" />
            </asp:Menu>
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<h2>Search by Student Name</h2>
&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;
        &nbsp&nbsp;&nbsp;&nbsp;
        &nbsp &nbsp &nbsp &nbsp
        &nbsp &nbsp &nbsp &nbsp
                  &nbsp 


            <asp:Label ID="LastLbl" runat="server" Text="Last Name:"></asp:Label>
              &nbsp &nbsp  
            <asp:Label ID="firstLbl" runat="server" Text="First Name:"></asp:Label>
            &nbsp   &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
              &nbsp   &nbsp 
            &nbsp;</div>
     
        <asp:Label ID="studentsearchLbl" runat="server" Text="Enter Student Name:"></asp:Label>
        &nbsp;<asp:TextBox ID="studentTxt" runat="server"></asp:TextBox>
        &nbsp&nbsp;&nbsp;&nbsp;
         
            <asp:TextBox ID="firstTxt" runat="server" Width="120px"></asp:TextBox>
        &nbsp;

            <asp:Button ID="studentsearchBtn" runat="server" Text="Search Student" OnClick="studentsearchBtn_Click" />
        &nbsp&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;
        &nbsp&nbsp;&nbsp;&nbsp;
        &nbsp &nbsp &nbsp &nbsp
        &nbsp &nbsp &nbsp &nbsp<br />
            <asp:DataList ID="studentDL" runat="server" DataKeyField="StudentNumber" Visible="False" CellPadding="0" CellSpacing="5" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" GridLines="Both" RepeatColumns="5" OnSelectedIndexChanged="studentDL_SelectedIndexChanged">
                <ItemTemplate>
                     Name:
                    <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                     &nbsp
                    <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
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
               
                    Is class currently in progress?:
                    <asp:Label ID="InProgressLabel" runat="server" Text='<%# Eval("InProgress") %>' />
                    <br />
<br />
                </ItemTemplate>
              

            </asp:DataList>
          
        <br />
        <br />
         <h2>&nbsp;Search by Student Number</h2>
       
        <asp:Label ID="numberLbl" runat="server" Text="Enter Student Number:"></asp:Label>
        &nbsp;<asp:TextBox ID="numberTxt" runat="server" style="margin-left: 0px" Width="176px"></asp:TextBox>
        &nbsp;<asp:Button ID="numberBtn" runat="server" Text="Search By Student Number" OnClick="numberBtn_Click" Width="228px" />
        &nbsp&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;
        &nbsp&nbsp;&nbsp;&nbsp;
        &nbsp &nbsp &nbsp &nbsp
        &nbsp &nbsp &nbsp &nbsp<br />
            <asp:DataList ID="numberDL" runat="server"  DataKeyField="StudentNumber" Visible="False" CellPadding="0" CellSpacing="5" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" GridLines="Both" RepeatColumns="5">
              <ItemTemplate>
                Name:
                    <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                     &nbsp
                    <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
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
               
                    Is class currently in progress?:
                    <asp:Label ID="InProgressLabel" runat="server" Text='<%# Eval("InProgress") %>' />
                    <br />
<br />
                </ItemTemplate>
            </asp:DataList>
        <br />
        <br />
        <h2>Search by Course Number</h2>
        
        <asp:Label ID="coursesearchLbl" runat="server" Text="Enter Course Code:"></asp:Label>
        &nbsp
        <asp:TextBox ID="courseTxt" runat="server"></asp:TextBox>
        &nbsp
        <asp:Button ID="courseBtn" runat="server" Text="Search Course" OnClick="courseBtn_Click" />
         &nbsp&nbsp;<br />
          
            <asp:DataList ID="courseDL" runat="server" DataKeyField="CourseNumber" Visible="False" CellPadding="3" GridLines="Both" RepeatColumns="1">
                <ItemTemplate>
                     Course:
                    <asp:Label ID="CourseLabel" runat="server" Text='<%# Eval("CourseNumber") %>' />
                    <br />
                     Name:
                    <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                     &nbsp
                    <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                    <br />
                 
                  
                

                  
                    <br />
                </ItemTemplate>
            </asp:DataList>
        <br />
        <p>
            &nbsp;</p>
        <asp:SqlDataSource ID="spiderwebDdb" runat="server" ConnectionString="<%$ ConnectionStrings:SpiderWebConnectionString %>" SelectCommand="SELECT DISTINCT Student.FirstName, Student.LastName, Student.MiddleInitial, Student.Age, Student.GPA, Student.StudentNumber, Student.ClassYear, Major.MajorCode, Minor.MinorCode, Course.CourseNumber, Course.NumberOfCredits, StudentHasCourse.Grade, StudentHasCourse.InProgress FROM Student INNER JOIN StudentHasMajor ON Student.StudentNumber = StudentHasMajor.StudentNumber INNER JOIN Major ON StudentHasMajor.MajorCode = Major.MajorCode INNER JOIN StudentHasMinor ON StudentHasMinor.StudentNumber = Student.StudentNumber INNER JOIN Minor ON StudentHasMinor.MinorCode = Minor.MinorCode INNER JOIN StudentHasCourse ON Student.StudentNumber = StudentHasCourse.StudentNumber INNER JOIN Course ON StudentHasCourse.CourseNumber = Course.CourseNumber CROSS JOIN GPAReference"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="StudentNumber,MajorCode,MinorCode"  Visible="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
