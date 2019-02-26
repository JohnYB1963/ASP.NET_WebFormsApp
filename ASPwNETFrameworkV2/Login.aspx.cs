using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Security.Principal;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ASPwNETFrameworkV2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void CheckCredentials(object sender, EventArgs e)
        {
            var dc = new MFDDataClassDataContext();

            var username = Username.Text.Trim();
            var password = Password.Text.Trim();
            try
            {
                var results = (from User in dc.Users
                               where User.Password == password && User.Username == username
                               select User).ToList();
                if (results.Count() > 1)
                {
                    txtResponse.Text = "There was an internal server error";
                }
                else if(results.Count() < 1)
                {
                    txtResponse.Text = "That username and password to not match";
                }
                else
                {
                    var user = results.FirstOrDefault();
                    var identity = new System.Security.Principal.GenericIdentity(user.Username);
                    string[] roles = { "user" }; 
                    var principal = new GenericPrincipal(identity, roles);
                    HttpContext.Current.User = principal;

                    if(HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        var session = new SessionHandler();
                        txtResponse.Text = "You have been authenticated";
                        session.User = user.Username + "-" + user.Password;
                        Response.Redirect("/Default.aspx");
                    }
                    else
                    {
                        txtResponse.Text = "There was an internal server error. Please contact your network administrator";
                    }
                }
            }
            catch(Exception err)
            {
                txtResponse.Text = "There was an internal server error. Please contact your network administrator";
            }
        }
    }
}