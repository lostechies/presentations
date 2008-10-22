using System;
using NHibernate;
using NHibernateIntro.Core.Domain;

namespace NHibernateInto.App
{
    public class CRUD_with_Collections
    {
        public static void Run(ISessionFactory factory)
        {
            int customerId;

            // Save a customer with a bunch of orders
            using (ISession session = factory.OpenSession())
            {
                var customer = ObjectMother.Customer();

                for( var i = 0; i < 5; i++ )
                {
                    var order = ObjectMother.Order()
                        .Customer(customer)
                        .Amount(100 + i)
                        .Product("Product " + i)
                        .Quantity(10 + i)
                        .Date( (i+1) + "/1/2008");

                    customer.Orders.Add(order);
                }

                Print("Saving 1 Customer + 5 Orders...");

                session.Save(customer);
                session.Flush();

                customerId = customer.CustomerID;
            }

            // Load the customer back up, lazy load the orders
            using( ISession session = factory.OpenSession() )
            {
                Print("Loading customer...");

                var customer = session.Load<Customer>(customerId);

                Print(customer.ToString());

                Print("Loading the orders...");
                
                foreach( var order in customer.Orders )
                {
                    Print("Order {0}: Amount: {1}", order.OrderID, order.Amount);
                }

                Print("Deleting the customer (should delete orders too!)");

                session.Delete(customer);
                session.Flush();
            }
        }

        private static void Print(string format, params object[] args)
        {
            Console.WriteLine("\n\n***** " + format + "\n\n", args);
        }
    }
}