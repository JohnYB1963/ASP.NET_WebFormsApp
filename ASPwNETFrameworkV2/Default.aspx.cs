﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ASPwNETFrameworkV2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var session = new SessionHandler();
            if(!session.IsValidated)
            {
                Response.Redirect("/Login.aspx");   
            }
        }
    }
}