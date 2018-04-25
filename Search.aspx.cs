using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;            // DataSet
using System.Data.SqlClient;  // SqlConnection, SqlCommand, SqlDataReader
using System.Configuration;   // to get the connection from Web.config
using System.ComponentModel;  // DataObject, DataObjectMethod

[DataObject(true)]
public partial class Search : System.Web.UI.Page
{
    [DataObjectMethod(DataObjectMethodType.Select)]

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        if (Session["User"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        
    }

    SqlConnection conn;
    SqlCommand cmd;
    SqlDataReader dr;
    string connectionString;
    ListItem listItem;
    int numRowsAffected;

    protected void studentsearchBtn_Click(object sender, EventArgs e)
    {

        {

            DataSet ds;
            SqlDataAdapter da;
            string connectionString;
            connectionString = getConnectionString();

            da = new SqlDataAdapter("SELECT DISTINCT Student.FirstName, Student.LastName, Student.MiddleInitial, Student.Age, Student.GPA, Student.StudentNumber, Student.ClassYear, Major.MajorCode, Minor.MinorCode, Course.CourseNumber, Course.NumberOfCredits, StudentHasCourse.Grade, StudentHasCourse.InProgress FROM Student INNER JOIN StudentHasMajor ON Student.StudentNumber = StudentHasMajor.StudentNumber INNER JOIN Major ON StudentHasMajor.MajorCode = Major.MajorCode INNER JOIN StudentHasMinor ON StudentHasMinor.StudentNumber = Student.StudentNumber INNER JOIN Minor ON StudentHasMinor.MinorCode = Minor.MinorCode INNER JOIN StudentHasCourse ON Student.StudentNumber = StudentHasCourse.StudentNumber INNER JOIN Course ON StudentHasCourse.CourseNumber = Course.CourseNumber CROSS JOIN GPAReference WHERE Student.LastName LIKE '" + studentTxt.Text + "%" + "' AND Student.FirstName LIKE '" + firstTxt.Text + "%" + "' ORDER BY StudentNumber, CourseNumber", connectionString);

            String lastNameSearchField = studentTxt.Text.Replace("'","''");
            String firstNameSearchField = firstTxt.Text.Replace("'", "''");

            da = new SqlDataAdapter("SELECT DISTINCT Student.FirstName, Student.LastName, Student.MiddleInitial, Student.Age, Student.GPA, Student.StudentNumber, " +
                "Student.ClassYear, Major.MajorCode, Minor.MinorCode, Course.CourseNumber, Course.NumberOfCredits, StudentHasCourse.Grade, StudentHasCourse.InProgress FROM Student INNER JOIN StudentHasMajor ON " +
                "Student.StudentNumber = StudentHasMajor.StudentNumber INNER JOIN Major ON StudentHasMajor.MajorCode = Major.MajorCode INNER JOIN StudentHasMinor ON StudentHasMinor.StudentNumber = Student.StudentNumber " +
                "INNER JOIN Minor ON StudentHasMinor.MinorCode = Minor.MinorCode INNER JOIN StudentHasCourse ON Student.StudentNumber = StudentHasCourse.StudentNumber INNER JOIN Course ON StudentHasCourse.CourseNumber = Course.CourseNumber " +
                "CROSS JOIN GPAReference WHERE Student.LastName LIKE '" + lastNameSearchField + "'AND Student.FirstName LIKE '" + firstNameSearchField  + "' ORDER BY StudentNumber, CourseNumber", connectionString);

            ds = new DataSet();
            da.Fill(ds);
            studentDL.DataSource = ds;
            studentDL.DataBind();
            numberTxt.Text = "";
            courseTxt.Text = "";
            coursenumLbl.Visible = false;
            coursetakeLbl.Visible = false;
            stunumberLbl.Visible = false;
            numbsearchLbl.Visible = false;
            //majorLbl = ("SELECT DISTINCT Major.MajorCode, Minor.MinorCode FROM Student INNER JOIN StudentHasMajor ON Student.StudentNumber = StudentHasMajor.StudentNumber INNER JOIN StudentHasMinor ON Student.StudentNumber = StudentHasMinor.StudentNumber INNER JOIN Major ON StudentHasMajor.MajorCode = Major.MajorCode INNER JOIN Minor ON StudentHasMinor.MinorCode = Minor.MinorCode WHERE Student.LastName LIKE '" + studentTxt.Text + "%" + "' AND Student.FirstName LIKE '" + firstTxt.Text, connectionString);
            studentnameLbl.Text = firstTxt.Text + " " + studentTxt.Text;
            
           
            string temp1;
            temp1 = studentTxt.Text + firstTxt.Text;
            namereturnLbl.Visible = true;

            if (temp1 == "")
            {
                studentDL.Visible = false;
            }
            else if (temp1 == temp1)
            {
                studentDL.Visible = true;
            }
            if (numberTxt.Text == "")
            {
                numberDL.Visible = false;
            }
            else if (numberTxt.Text == numberTxt.Text)
            {
                numberDL.Visible = true;
            }
            if (courseTxt.Text == "")
            {
                courseDL.Visible = false;
            }
            else if (courseTxt.Text == courseTxt.Text)
            {
                courseDL.Visible = true;

            } 
        }
        



    }


        protected void courseBtn_Click(object sender, EventArgs e)
        {
            DataSet ds2;
            SqlDataAdapter da2;
            string connectionString;
            connectionString = getConnectionString();
            da2 = new SqlDataAdapter("SELECT DISTINCT Student.FirstName, Student.LastName, Student.MiddleInitial, Student.Age, Student.GPA, Student.StudentNumber, Student.ClassYear, Course.CourseNumber, Course.NumberOfCredits, Course.CourseDescription, StudentHasCourse.InProgress, StudentHasCourse.Grade FROM Student INNER JOIN StudentHasCourse ON Student.StudentNumber = StudentHasCourse.StudentNumber INNER JOIN Course ON StudentHasCourse.CourseNumber = Course.CourseNumber WHERE Course.CourseNumber LIKE '" + courseTxt.Text + "' AND StudentHasCourse.Grade LIKE '' ORDER BY Student.LastName", connectionString);
            ds2 = new DataSet();
            da2.Fill(ds2);
            courseDL.DataSource = ds2;
            courseDL.DataBind();
        coursenumLbl.Visible = true;
        coursetakeLbl.Visible = true;
        coursenumLbl.Text = courseTxt.Text;
        numberTxt.Text = "";
        firstTxt.Text = "";
        studentTxt.Text = "";
        stunumberLbl.Visible = false;
        numbsearchLbl.Visible = false;
        string temp1;
        temp1 = studentTxt.Text + firstTxt.Text;
        studentnameLbl.Visible = false;
        namereturnLbl.Visible = false;

        if (courseTxt.Text == "")
            {
                courseDL.Visible = false;
            }
            else if (courseTxt.Text == courseTxt.Text)
            {
                courseDL.Visible = true;
            
            }
        if (temp1 == "")
        {
            studentDL.Visible = false;
        }
        else if (temp1 == studentTxt.Text)
        {
            studentDL.Visible = true;
        }
        if (numberTxt.Text == "")
        {
            numberDL.Visible = false;
        }
        else if (numberTxt.Text == numberTxt.Text)
        {
            numberDL.Visible = true;
        }



    }
        
    protected void numberBtn_Click(object sender, EventArgs e)
    {
        DataSet ds3;
        SqlDataAdapter da3;
        string connectionString;
        connectionString = getConnectionString();
        da3 = new SqlDataAdapter("SELECT DISTINCT Student.FirstName, Student.LastName, Student.MiddleInitial, Student.Age, Student.GPA, Student.StudentNumber, Student.ClassYear, Major.MajorCode, Minor.MinorCode, Course.CourseNumber, Course.NumberOfCredits, StudentHasCourse.Grade, StudentHasCourse.InProgress FROM Student INNER JOIN StudentHasMajor ON Student.StudentNumber = StudentHasMajor.StudentNumber INNER JOIN Major ON StudentHasMajor.MajorCode = Major.MajorCode INNER JOIN StudentHasMinor ON StudentHasMinor.StudentNumber = Student.StudentNumber INNER JOIN Minor ON StudentHasMinor.MinorCode = Minor.MinorCode INNER JOIN StudentHasCourse ON Student.StudentNumber = StudentHasCourse.StudentNumber INNER JOIN Course ON StudentHasCourse.CourseNumber = Course.CourseNumber CROSS JOIN GPAReference WHERE Student.StudentNumber = " + numberTxt.Text, connectionString);
        ds3 = new DataSet();
        da3.Fill(ds3);
        numberDL.DataSource = ds3;
        numberDL.DataBind();
        firstTxt.Text = "";
        studentTxt.Text = "";
        courseTxt.Text = "";
        string temp1;
        temp1 = studentTxt.Text + firstTxt.Text;
        stunumberLbl.Text = numberTxt.Text;
        coursenumLbl.Visible = false;
        coursetakeLbl.Visible = false;
        stunumberLbl.Visible = true;
        numbsearchLbl.Visible = true;
        studentnameLbl.Visible = false;
        namereturnLbl.Visible = false;
        if (numberTxt.Text == "")
        {
           numberDL.Visible = false;
        }
        else if (numberTxt.Text == numberTxt.Text)
        {
            numberDL.Visible = true;
        }
        if (temp1 == "")
        {
            studentDL.Visible = false;
        }
        else if (temp1 == temp1)
        {
            studentDL.Visible = true;
        }
        if (courseTxt.Text == "")
        {
            courseDL.Visible = false;
        }
        else if (courseTxt.Text == courseTxt.Text)
        {
            courseDL.Visible = true;

        }
        

    }
   

    private static string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SpiderWebConnectionString"].ConnectionString;
        }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {

    }

    protected void studentDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void numberDL_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}



   


