using System;
using NHibernate;
using NHibernateIntro.Core.Domain;

namespace NHibernateInto.App
{
    public class Save_MTO_And_Lazy_Load_Example
    {
        public static void Run(ISessionFactory factory)
        {
            int bobId;
            int storeId;

            // Save a Customer with a store
            using (ISession session = factory.OpenSession())
            {
                Customer bob = ObjectMother.Customer();
                Store store = ObjectMother.Store();

                bob.Store = store;

                Print("Saving Customer and addres...");
                Print("Bob's ID before save/flush: {0}", bob.CustomerID);
                
                session.Save(bob);
                session.Flush();

                Print("Bob's ID after save/flush: {0}", bob.CustomerID);

                bobId = bob.CustomerID;
                storeId = store.StoreID;
            }

            // Load it back up and print out the details
            using (ISession session = factory.OpenSession())
            {
                Print("Loading Customer (but Store should be lazy-loaded)");
                
                Customer bob = session.Load<Customer>(bobId);

                Print("{0}", bob);

                Print("Accessing Store property... ");

                Print("{0}", bob.Store);

                Print("Deleting Customer should not delete Store");

                session.Delete(bob);
                session.Flush();
            }

            // Verify Bob was deleted and that the Store still exists
            using( ISession session = factory.OpenSession())
            {
                try
                {
                    Customer bob = session.Load<Customer>(bobId);
                    Print("ERROR: Customer was not deleted! {0}", bob);
                }
                catch( ObjectNotFoundException )
                {
                    Print("Customer was successfully deleted");
                }

                Store addr = session.Load<Store>(storeId);
                Print("Store still exists in the DB ({0})", addr.StoreID);
            }
        }

        private static void Print(string format, params object[] args)
        {
            Console.WriteLine("\n\n***** " + format + "\n\n", args);
        }
    }
}