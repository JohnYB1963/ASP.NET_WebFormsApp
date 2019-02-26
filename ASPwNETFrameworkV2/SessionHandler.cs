using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPwNETFrameworkV2
{
    public class SessionHandler
    {
        MFDDataClassDataContext dc = new MFDDataClassDataContext();
        public dynamic User
        {
            get { if (this.IsValidated)
                    { return HttpContext.Current.Session["currUser"]; }
                else { return null; }
            }
            set { HttpContext.Current.Session["currUser"] = value; }
        }
        
        public bool IsValidated
        {
            get { if (HttpContext.Current.Session["currUser"] == null)
                { return false;}
                else if((from User in dc.Users
                         where (User.Username == HttpContext.Current.Session["currUser"].ToString().Split('-')[0] && 
                                User.Password == HttpContext.Current.Session["currUser"].ToString().Split('-')[1])
                         select User).ToList().Count() == 1)
                     {
                         return true;
                     }
                else
                {
                    return false;
                }
            }
        }
        public bool IsAdmin
        {
            get {
                if ((from User in dc.Users
                     where (User.Username == HttpContext.Current.Session["currUser"].ToString().Split('-')[0] &&
                            User.Password == HttpContext.Current.Session["currUser"].ToString().Split('-')[1])
                     select User).ToList().FirstOrDefault().IsAdmin == 1)
                {
                    return true;
                }
                else
                { return false; }
                 }
        }

    }
}