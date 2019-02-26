using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace ASPwNETFrameworkV2.Pages
{
    public partial class CustomerDetailSearchResults : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var session = new SessionHandler();
            if (!session.IsValidated)
            {
                Response.Redirect("/Login.aspx");
            }

            var customerName = Request.QueryString["name"];
            Int32.TryParse(Request.QueryString["purchase"], out int customerPurchase);
            var customerLocation = Request.QueryString["location"];

            GetCustomerDetail(customerName, customerPurchase, customerLocation);
        }
        private void GetCustomerDetail(string customerName, int? customerPurchase, string customerLocation)
        {
            var cm = new CoreMessaging();

            var matchingCustomers = cm.FindMatchingCustomers(customerName, customerPurchase, customerLocation);

            foreach(var ele in matchingCustomers)
            {
                var row = new TableRow();

                row.Cells.Add(new TableCell() { Text = ele.CustomerID.ToString() });
                row.Cells.Add(new TableCell() { Text = ele.CustomerName.ToString() });
                row.Cells.Add(new TableCell() { Text = ele.CustomerPurchase.ToString() });
                row.Cells.Add(new TableCell() { Text = ele.Location.ToString() });

                resultsTable.Rows.Add(row);
            }

        }
    }
}