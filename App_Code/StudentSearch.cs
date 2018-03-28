using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;            // DataSet
using System.Data.SqlClient;  // SqlConnection, SqlCommand, SqlDataReader
using System.Configuration;   // to get the connection from Web.config
using System.ComponentModel;  // DataObject, DataObjectMethod

/// <summary>
/// Summary description for StudentSearch
/// </summary>
public class StudentSearch
{
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static SqlDataReader getCourse()
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        conn = new SqlConnection(getConnectionString());
        conn.Open();

        cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT * FROM Student ORDER BY StudentNumber";
        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        return dr;
    } // end of getStudent

    private static string getConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["SpiderWebConnectionString"].ConnectionString;
    }
}