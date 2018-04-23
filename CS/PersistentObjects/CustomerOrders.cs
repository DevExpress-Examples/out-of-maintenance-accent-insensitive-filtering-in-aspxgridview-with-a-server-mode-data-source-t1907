// Developer Express Code Central Example:
// How to display and edit XPO in the ASPxGridView
// 
// This is a simple example of how to bind the grid to an XpoDataSource (eXpress
// Persistent Objects) for data displaying and editing. It's implemented according
// to the http://www.devexpress.com/scid=K18061 article.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E320

using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;

namespace PersistentObjects {
    [NonPersistent]
    public class MyBaseObject : XPObject {
        public MyBaseObject(Session session) : base(session) { }
    }

    public class Customer : MyBaseObject  {
        public Customer(Session session) : base(session) { }

        string _CompanyName;
        public string CompanyName {
            get { return _CompanyName; }
            set { SetPropertyValue("CompanyName", ref _CompanyName, value); }
        }

        string _ContactName;
        public string ContactName {
            get { return _ContactName; }
            set { SetPropertyValue("ContactName", ref _ContactName, value); }
        }

        string _Country;
        public string Country {
            get { return _Country; }
            set { SetPropertyValue("Country", ref _Country, value); }
        }

        string _Phone;
        public string Phone {
            get { return _Phone; }
            set { SetPropertyValue("Phone", ref _Phone, value); }
        }

        [Association("Customer-Orders")]
        public XPCollection<Order> Orders {
            get { return GetCollection<Order>("Orders"); }
        }
    }

    public class Order : MyBaseObject {
        public Order(Session session) : base(session) { }

        DateTime _OrderDate;
        public DateTime OrderDate {
            get { return _OrderDate; }
            set { SetPropertyValue("OrderDate", ref _OrderDate, value); }
        }

        decimal _PaidTotal;
        public decimal PaidTotal {
            get { return _PaidTotal; }
            set { SetPropertyValue("PaidTotal", ref _PaidTotal, value); }
        }

        private Customer _Customer;

        [Association("Customer-Orders")]
        public Customer Customer {
            get {
                return _Customer;
            }
            set {
                SetPropertyValue("Customer", ref _Customer, value);
            }
        }
    }
}
