using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPwNETFrameworkV2.Pages
{
    public partial class CustomerDetailSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var session = new SessionHandler();
            if (!session.IsValidated)
            {
                Response.Redirect("/Login.aspx");
            }
        }
        protected void ResultsRedirect(object sender, EventArgs e)
        {
            var name = "";
            var purchase = "";
            var location = "";
            if (txtName.Text != "")
                name = "name=" + txtName.Text;
            if (txtPurchase.Text != "")
                purchase = "purchase=" + txtPurchase.Text;
            if (txtLocation.Text != "")
                location = "location=" + txtLocation.Text;
            
            var url = String.Format("/Pages/CustomerDetailSearchResults.aspx?{0}{1}{2}", name, purchase, location);

            Response.Redirect(url);

        }
    }
}