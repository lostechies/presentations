using System;
using NHibernateIntro.Core.Domain;

namespace NHibernateInto.App
{
    public static class FluentFixtures
    {
        public static Order Amount(this Order order, decimal amount)
        {
            order.Amount = amount;
            return order;
        }

        public static Order Product(this Order order, string name)
        {
            order.ProductName = name;
            return order;
        }

        public static Order Quantity(this Order order, int quantity)
        {
            order.Quantity = quantity;
            return order;
        }

        public static Order Customer(this Order order, Customer customer)
        {
            order.OrderingCustomer = customer;
            return order;
        }

        public static Order Date(this Order order, string orderDateString)
        {
            order.OrderDate = DateTime.Parse(orderDateString);
            return order;
        }
    }
}