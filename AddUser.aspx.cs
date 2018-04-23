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
            return;
        }

        Security sec = new Security();
        if (!sec.UserExists(UserNametxt.Text))
        {
            sec.CreateUser(UserNametxt.Text, Passwordtxt.Text);
            Loginlbl.Text = "User created successfully";
        }
        else
        {
            Loginlbl.Text = "Username already exists";
        }


    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {

    }
}