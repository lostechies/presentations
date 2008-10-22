using System;

namespace NHibernateIntro.Core.Domain
{
    public class Order
    {
        private DateTime _orderDate = DateTime.Now;

        public virtual int OrderID { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string ProductName { get; set; }
        public virtual int Quantity { get; set; }
        public virtual Customer OrderingCustomer { get; set; }

        public virtual DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }
    }
}