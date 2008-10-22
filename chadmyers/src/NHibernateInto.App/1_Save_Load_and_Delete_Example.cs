using System;
using NHibernate;
using NHibernateIntro.Core.Domain;

namespace NHibernateInto.App
{
    public class Save_Load_and_Delete_Example
    {
        public static void Run(ISessionFactory factory)
        {
            int bobId;

            // Save a Customer
            using (ISession session = factory.OpenSession())
            {
                Customer bob = ObjectMother.Customer();

                Print("Saving Customer...");

                session.Save(bob);
                session.Flush();

                bobId = bob.CustomerID;
            }

            // Load it back up and print out the details
            using (ISession session = factory.OpenSession())
            {
                Print("Loading Customer");
                Customer bob = session.Load<Customer>(bobId);

                Print("{0}", bob);

                Print("Loading Customer (again, but should be a cache hit)");

                // Load it again, 1st level cache
                bob = session.Load<Customer>(bobId);

                Print("{0}", bob);

                Print("Delete the Customer");
                session.Delete(bob);
                session.Flush();
            }

            // Verify it was deleted
            using (ISession session = factory.OpenSession())
            {
                Print("Try to load it again");

                try
                {
                    Customer bob = session.Load<Customer>(bobId);
                    Print("This should not execute! {0}", bob);
                }
                catch( ObjectNotFoundException )
                {
                    Print("Customer 'Bob' was successfully deleted");
                }
            }
        }

        private static void Print(string format, params object[] args)
        {
            Console.WriteLine("\n\n***** " + format + "\n\n", args);
        }
    }
}