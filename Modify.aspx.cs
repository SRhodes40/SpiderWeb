using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;  // for ConfigurationManager
using System.Data.SqlClient; // for SqlConnection, SqlCommand, and SqlDataReader
using System.Data;           // for CommandType

public partial class Modify : System.Web.UI.Page
{
    SqlConnection conn;
    SqlCommand cmd;
    SqlDataReader dr;
    string connectionString;
    ListItem listItem;
    int numRowsAffected;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        if (Session["User"] == null)
        {
            Response.Redirect("Login.aspx");
        }

    }

    protected void studentgv_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            lblStatus.Text = "Unable to delete. " + e.Exception.Message;
            e.ExceptionHandled = true;
        }
        else if (e.AffectedRows == 0)
        {
            lblStatus.Text = "Delete failed. Someone else changed or deleted this major.";
        }
    }

    protected void studentgv_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            lblStatus.Text = "Unable to update. " + e.Exception.Message;
            e.ExceptionHandled = true;
        }
        else if (e.AffectedRows == 0)
        {
            lblStatus.Text = "Update failed. Someone else changed or deleted this major.";
        }
    }

    protected void studentgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        studentgv.SelectedIndex = -1;
    }

    protected void studentgv_RowEditing(object sender, GridViewEditEventArgs e)
    {
        studentgv.SelectedIndex = -1;
    }

    protected void insertBtn_Click(object sender, EventArgs e)
    {
        {
            conn = new SqlConnection(getConnectionString());
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into StudentHasCourse (StudentNumber, CourseNumber, InProgress, Grade) VALUES ('"
                 + stunumbTxt.Text + "','" + coursenumbTxt.Text + "','" + progressTxt.Text + "','"  + gradeTxt.Text + "')";
            //Response.Write(cmd.CommandText);
            Response.Write(cmd.CommandText);
            try

            {
                numRowsAffected = cmd.ExecuteNonQuery();
                if (numRowsAffected == 1)
                {
                    lblStatus.Text = "Submitted";




                }
                else
                {
                    lblStatus.Text = "Submit Failed";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Data Incorrect, Submit Failed";//"Person not found.";
            }
            conn.Close();
            
            Response.Redirect("Modify.aspx");
        } // end of Insert
    }
    private string getConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["SpiderWebConnectionString"].ConnectionString;
    } // end of getConnectionString


    protected void deleteBtn_Click(object sender, EventArgs e)
    {
        conn = new SqlConnection(getConnectionString());
        conn.Open();
        cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "DELETE from StudentHasCourse " +
            "WHERE StudentNumber ='" + stunumbTxt.Text + "'AND CourseNumber ='" + coursenumbTxt.Text + "'AND InProgress ='" + progressTxt.Text + "'AND Grade ='" + gradeTxt.Text + "'";
        //Response.Write(cmd.CommandText);

        try

        {
            numRowsAffected = cmd.ExecuteNonQuery();
            if (numRowsAffected == 1)
            {
                lblStatus.Text = "Submitted";




            }
            else
            {
                lblStatus.Text = "Data Incorrect, Submit Failed";
            }
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;//"Person not found.";
        }
        
        conn.Close();
        Response.Redirect("Modify.aspx");
    }

    protected void modifyBtn_Click(object sender, EventArgs e) {
        {
            conn = new SqlConnection(getConnectionString());
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE StudentHasCourse SET InProgress ='" + toProgressTxt.Text + "', Grade ='" + togradeTxt.Text + "'"
                + " WHERE StudentNumber ='" + stunumbTxt.Text + "' AND CourseNumber ='" + coursenumbTxt.Text + "' AND InProgress ='" + progressTxt.Text + "' AND Grade ='" + gradeTxt.Text + "'";
            //Response.Write(cmd.CommandText);

            try

            {
                numRowsAffected = cmd.ExecuteNonQuery();
                if (numRowsAffected == 1)
                {
                    lblStatus.Text = "Submitted";




                }
                else
                {
                    lblStatus.Text = "Data Incorrect, Submit Failed";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;//"Person not found.";
            }

            conn.Close();
           Response.Redirect("Modify.aspx");
        }

     
    }

    protected void studentgv_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Response.Write(studentgv.SelectedRow.Cells[3].Text);
        stunumbTxt.Text = studentgv.SelectedRow.Cells[3].Text;
        coursenumbTxt.Text = studentgv.SelectedRow.Cells[4].Text;
        progressTxt.Text = studentgv.SelectedRow.Cells[5].Text;
        gradeTxt.Text = studentgv.SelectedRow.Cells[6].Text;
    }
}

