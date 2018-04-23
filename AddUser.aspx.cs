using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        if (Session["User"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if ((String)Session["User"] != "admin")
        {
            Response.Redirect("Search.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Passwordtxt.Text.Length < 4)
        {
            Loginlbl.Text = "Password must be at least 4 characters";
            Label2.Text = "";
            return;
        }

        Security sec = new Security();
        if (!sec.UserExists(UserNametxt.Text))
        {
            sec.CreateUser(UserNametxt.Text, Passwordtxt.Text);
            Loginlbl.Text = "User created successfully";
            Label2.Text = "";
        }
        else
        {
            Loginlbl.Text = "Username already exists";
            Label2.Text = "";
        }


    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Security sec = new Security();
        if (!sec.UserExists(UserNametxt.Text))
        {
            Label2.Text = "User doesn't exist";
            Loginlbl.Text = "";
            return;
        }
        
        try
        {
            sec.DeleteUser(UserNametxt.Text);
            Label2.Text = "User deleted successfully";
            Loginlbl.Text = "";
        }
        catch(Exception ex)
        {
            string except = ex.ToString();
            Label2.Text = "User not deleted";
            Loginlbl.Text = "";
        }


    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {

    }
}