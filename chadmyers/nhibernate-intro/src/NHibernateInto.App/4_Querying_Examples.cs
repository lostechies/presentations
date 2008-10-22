using System;
using NHibernate;
using NHibernate.Criterion;
using NHibernateIntro.Core.Domain;

namespace NHibernateInto.App
{
    public class Querying_Examples
    {
        public static void Run(ISessionFactory factory)
        {
            using (ISession session = factory.OpenSession())
            {
                Print("Populating customers...");

                var store = ObjectMother.Store();

                int counter = 0;

                foreach( var customer in ObjectMother.LotsaCustomers() )
                {
                    counter++;

                    if( counter % 5 == 0 )
                    {
                        customer.Store = store;
                    }

                    session.Save(customer);
                }
                
                session.Flush();
            }

            using (ISession session = factory.OpenSession())
            {
                Print("_______ Using HQL");
                Print("Query a few customers");
                
                // Query using HQL
                var customerList = session
                    .CreateQuery("FROM Customer c WHERE c.LastName LIKE :lastName")
                    .SetString("lastName", "M%")
                    .List();

                Print("Customers returned: {0}", customerList.Count);


                Print("Do a COUNT() query");

                var count = session
                    .CreateQuery("SELECT COUNT(c) FROM Customer c WHERE c.LastName LIKE :lastName")
                    .SetString("lastName", "M%")
                    .UniqueResult<long>();

                Print("Customers count returned: {0}", count);

                Print("Access a related entity");
                
                count = session
                    // .CreateQuery("SELECT COUNT(c) FROM Customer c JOIN c.Store s WHERE s.Name LIKE :storeName")
                    .CreateQuery("SELECT COUNT(c) FROM Customer c WHERE c.Store.Name LIKE :storeName")
                    .SetString("storeName", "Bozos%")
                    .UniqueResult<long>();

                Print("Customers count returned: {0}", count);
            }

            using (ISession session = factory.OpenSession())
            {
                Print("_______ Using ICriteria");
                Print("Query a few customers");

                // Query using ICriteria
                var customerList = session
                    .CreateCriteria(typeof(Customer))
                    .Add(Restrictions.Like("LastName", "M", MatchMode.Start ))
                    .List();

                Print("Customers returned: {0}", customerList.Count);


                Print("Do a COUNT() query");

                var count = session
                    .CreateCriteria(typeof(Customer))
                    .SetProjection(Projections.Count("CustomerID"))
                    .Add(Restrictions.Like("LastName", "M", MatchMode.Start))
                    .UniqueResult<int>();

                Print("Customers count returned: {0}", count);

                Print("Access a related entity");

                count = session
                    // .CreateQuery("SELECT COUNT(c) FROM Customer c JOIN c.Store s WHERE s.Name LIKE :storeName")
                    //.CreateQuery("SELECT COUNT(c) FROM Customer c WHERE c.Store.Name LIKE :storeName")
                    .CreateCriteria(typeof(Customer))
                    .SetProjection(Projections.Count("CustomerID"))
                    .CreateAlias("Store", "s")
                        .Add(Restrictions.Like("s.Name", "Bozos", MatchMode.Start))
                    .UniqueResult<int>();

                Print("Customers count returned: {0}", count);
            }

        }

        private static void Print(string format, params object[] args)
        {
            Console.WriteLine("\n\n***** " + format + "\n\n", args);
        }
    }
}