﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        Security sec = new Security();
        if (sec.Verify(UserNametxt.Text, Passwordtxt.Text))
        {
            Session["User"] = UserNametxt.Text;
            Response.Redirect("~/Search.aspx");
        }
        else
        {
            Loginlbl.Text = "Invalid Username or Password";
        }


    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {

    }
}