using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ASPwNETFrameworkV2
{
    /// <summary>
    /// Summary description for CoreMessaging
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // Done
    [System.Web.Script.Services.ScriptService]
    //used to be: public class CoreMessaging : System.Web.Services.WebService  - simplified

    public class CoreMessaging : WebService
    {
        private MFDDataClassDataContext dc = new MFDDataClassDataContext();

        [WebMethod]
        public List<PurchaseStruct> GetCustomerHistory(int? id, string name)
        {
            var results = (from Purchase in dc.Purchases
                             where Purchase.CustomerID == id && Purchase.CustomerName == name
                             select Purchase).ToList();
            var purchases = new List<PurchaseStruct>();
            
            foreach(var ele in results)
            {
                purchases.Add(new PurchaseStruct(ele.PurchaseID, ele.PurchaseAmmount, ele.DateofPurchase, ele.PurchaseDesc));
            }

            return purchases;
        }
        public struct PurchaseStruct
        {
            public int PurchaseID;
            public int PurchaseAmmount;
            public string DateofPurchase;
            public string PurchaseDesc;
            public PurchaseStruct(int id, int pa, DateTime dp, string pd)
            {
                PurchaseID = id;
                PurchaseAmmount = pa;
                DateofPurchase = dp.ToString("yyyy-MM-dd");
                PurchaseDesc = pd;
            }
        }

        [WebMethod]
        public dynamic DeleteCustomer(string id)
        {
            if (!Int32.TryParse(id, out int ID))
            {
                return false;
            }

            var results = (from Customer in dc.Customers
                           where Customer.CustomerID == ID
                           select Customer).ToList();
            if(results.Count > 1)
            {
                return false;
            }
            var cust = results.FirstOrDefault();

            dc.Customers.DeleteOnSubmit(cust);

            try
            {
                dc.SubmitChanges();
            }
            catch(Exception err)
            {
                return err;
            }

            return true;
        }


        [WebMethod]
        public dynamic AddCustomer(int id, string name, int purchase, string location)
        {

            if ((from Customer in dc.Customers
                 where Customer.CustomerID == id
                 select Customer).ToList().Count() > 0)
            {
                return "There is already a customer with that id";
            }

            var newCust = new Customer
            {
                CustomerID = id,
                CustomerName = name,
                CustomerPurchase = purchase,
                Location = location
            };

            dc.Customers.InsertOnSubmit(newCust);

            try
            {
                dc.SubmitChanges();
                return "The Customer was sucessfully added.";
            }
            catch (Exception err)
            {
                return "Sorry, there was an error adding that customer. Please contact IT with the error: " + err.ToString();
            }
        }

        [WebMethod]
        public List<Customer> FindMatchingCustomers(string name, int? purchase, string location)
        {
            try
            {
                

                //denotated with the Q in order to represent that the customer object is a queryable
                var Qcustomers = dc.Customers.AsQueryable();

                if (!string.IsNullOrEmpty(name))
                    Qcustomers = Qcustomers.Where(customer => customer.CustomerName.Equals(name));
                if (!string.IsNullOrEmpty(purchase.ToString()) && purchase != 0)
                    Qcustomers = Qcustomers.Where(customer => customer.CustomerPurchase == purchase);
                if (!string.IsNullOrEmpty(location))
                    Qcustomers = Qcustomers.Where(customer => customer.Location.Equals(location));

                //Not necessary apparently?
                //Qcustomers = Qcustomers.Select(customer => new Customer
                //{
                //    CustomerID = customer.CustomerID,
                //    CustomerName = customer.CustomerName,
                //    CustomerPurchase = customer.CustomerPurchase,
                //    Location = customer.Location
                //});

                var elements = Qcustomers.ToList();

                return elements;
            }
            catch (Exception err)
            {
                return null;
            }

            //Stolen from stackoverflow as template for this web method
            //var ads = db.Ads;
            //if (!string.IsNullOrEmpty(brand))
            //    ads = ads.Where(ad => ad.brand.Equals(brand));
            //if (!string.IsNullOrEmpty(tags))
            //    ads = ads.Where(ad => ad.tags.Equals(tags));
            //// etc.

            //ads = ads.Select(ad => new {
            //    id = ad.Id,
            //    title = ad.title,
            //    //retrieve other attributes.
            //});
            //return OK(ads);
        }

        [WebMethod]
        public Customer GetCustomer(string id)
        {
            if (!Int32.TryParse(id, out int ID))
            {
                return null;
            }
            try
            {
                var matchingids = (from Customer in dc.Customers
                                   where Customer.CustomerID == ID
                                   select Customer).ToList();
                if (matchingids.Count() == 1)
                {
                    Customer ourcust = new Customer();

                    var data = dc.getCustomer(ID);

                    ourcust = (Customer) data.FirstOrDefault();

                    return ourcust;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }

        //Searches for the id of the input provided that the other variables are not null
        [WebMethod]
        public dynamic UpdateCustomer(string id, string name, int? purchase, string location)
        {
            if (!Int32.TryParse(id, out int ID))
            {
                return false;
            }

            var result = (from Customer in dc.Customers
                          where Customer.CustomerID == ID
                          select Customer).FirstOrDefault();

            if (name != null && name != "") { result.CustomerName = name; }
            if (purchase != null) { result.CustomerPurchase = purchase; }
            if (location != null && location != "") { result.Location = location; }

            dc.SubmitChanges();

            return result;
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //Note Webmethods can not be static
        [WebMethod]
        public string TestMethod(string message)
        {
            return "Hello there: " + message;
        }
    }
}
