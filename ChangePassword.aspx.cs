using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        if (Session["User"] == null)
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        if (txtNewPassword.Text != txtConfirmPassword.Text)
        {
            lblPasswordChanged.Text = "Your password was not changed because the 2 new passwords didn't match.";
            return;
        }

        Security sec = new Security();
        string username = (String)Session["User"]; // query username from session    https://msdn.microsoft.com/en-us/library/ms178583.aspx
        int outcome = sec.ChangePassword(username, txtNewPassword.Text, txtOldPassword.Text);
        
        if (outcome == -2)
        {
            
            lblPasswordChanged.Text = "Your password was not changed because new passwords must be a minimum of 4 characters for security purposes.";

        }
        else if (outcome == -1)
        {
            lblPasswordChanged.Text = "Old password invalid: Password not changed.";
        }
        else if (outcome == 0)
        {
            lblPasswordChanged.Text = "Your password was successfully changed.";
        }
    }



    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {

    }
}