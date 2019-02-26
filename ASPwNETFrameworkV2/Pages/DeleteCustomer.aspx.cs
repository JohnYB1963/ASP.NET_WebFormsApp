using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPwNETFrameworkV2.Pages
{
    public partial class DeleteCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var session = new SessionHandler();
            if (!session.IsValidated)
            {
                Response.Redirect("/Login.aspx");
            }
            if(!session.IsAdmin)
            {
                Response.Redirect("/Login.aspx");   
            }
        }
    }
}