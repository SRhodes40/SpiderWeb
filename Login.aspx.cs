﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      
        if (UserNametxt.Text == "admin" && Passwordtxt.Text == "admin1234")
        {
            Response.Redirect("~/Search.aspx");
        }
        else
        {
            Loginlbl.Text = "Invalid Username or Password";
        }


    }
}