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


          //if (IsPostBack)
       // {
        
        //}
        



            

        


      

        
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
            da = new SqlDataAdapter("SELECT DISTINCT Student.FirstName, Student.LastName, Student.MiddleInitial, Student.Age, Student.GPA, Student.StudentNumber, Student.ClassYear, Major.MajorCode, Minor.MinorCode, Course.CourseNumber, Course.NumberOfCredits, StudentHasCourse.Grade, StudentHasCourse.InProgress FROM Student INNER JOIN StudentHasMajor ON Student.StudentNumber = StudentHasMajor.StudentNumber INNER JOIN Major ON StudentHasMajor.MajorCode = Major.MajorCode INNER JOIN StudentHasMinor ON StudentHasMinor.StudentNumber = Student.StudentNumber INNER JOIN Minor ON StudentHasMinor.MinorCode = Minor.MinorCode INNER JOIN StudentHasCourse ON Student.StudentNumber = StudentHasCourse.StudentNumber INNER JOIN Course ON StudentHasCourse.CourseNumber = Course.CourseNumber CROSS JOIN GPAReference WHERE Student.LastName LIKE '" + studentTxt.Text + "%" + "' ORDER BY StudentNumber", connectionString);
            ds = new DataSet();
            da.Fill(ds);
            studentDL.DataSource = ds;
            studentDL.DataBind();


            if (studentTxt.Text == "")
            {
                studentDL.Visible = false;
            }
            else if (studentTxt.Text == studentTxt.Text)
            {
                studentDL.Visible = true;
            }
        }




    }

        protected void courseBtn_Click(object sender, EventArgs e)
        {
            DataSet ds2;
            SqlDataAdapter da2;
            string connectionString;
            connectionString = getConnectionString();
            da2 = new SqlDataAdapter("SELECT DISTINCT Student.FirstName, Student.LastName, Student.MiddleInitial, Student.Age, Student.GPA, Student.StudentNumber, Student.ClassYear, Course.CourseNumber, Course.NumberOfCredits, Course.CourseDescription, StudentHasCourse.InProgress, StudentHasCourse.Grade FROM Student INNER JOIN StudentHasCourse ON Student.StudentNumber = StudentHasCourse.StudentNumber INNER JOIN Course ON StudentHasCourse.CourseNumber = Course.CourseNumber WHERE Course.CourseNumber LIKE '" + courseTxt.Text + "%" + "' ORDER BY Student.LastName", connectionString);
            ds2 = new DataSet();
            da2.Fill(ds2);
            courseDL.DataSource = ds2;
            courseDL.DataBind();
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
    }
