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

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {

        if (txtOldPassword.Text == "admin1234" && txtNewPassword.Text == "admin1234")
        {
            
            lblPasswordChanged.Text = "Your password was changed successfully.";

        }
        else
        {
            lblPasswordChanged.Text = "Could not change password";
        }

    }
}