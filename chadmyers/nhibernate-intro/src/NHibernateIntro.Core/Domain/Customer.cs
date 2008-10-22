using System;
using System.Collections.Generic;

namespace NHibernateIntro.Core.Domain
{
    public class Customer
    {
        private DateTime _createdDate = DateTime.Now;
        private IList<Order> _orders = new List<Order>();

        public virtual int CustomerID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        public virtual Store Store { get; set; }

        public virtual IList<Order> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        public override string ToString()
        {
            return string.Format("Customer ({0}):\n\tFirst Name:{1}\n\tLast Name:{2}",
                                 CustomerID, FirstName, LastName);
        }
    }
}