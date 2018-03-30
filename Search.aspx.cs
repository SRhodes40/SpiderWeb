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

public partial class Search : System.Web.UI.Page
{
    [DataObjectMethod(DataObjectMethodType.Select)]
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack == true)
        {
            studentDL.Visible = true;
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

        // Show message box
        //Console.WriteLine("courseTxt.Text = " + courseTxt.Text);
        
        conn = new SqlConnection(getConnectionString());
        conn.Open();
        cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT * FROM Student WHERE Student.LastName LIKE '" + studentTxt.Text + "%" +"' ORDER BY StudentNumber";
        dr = cmd.ExecuteReader();
        conn.Close();
    }


    private static string getConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["SpiderWebConnectionString"].ConnectionString;
    }
}