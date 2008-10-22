using System;
using NHibernateIntro.Core.Domain;

namespace NHibernateInto.App
{
    public static class ObjectMother
    {
        public static Customer Customer()
        {
            return new Customer { FirstName = "Bob", LastName = "Smith" }; ;
        }

        public static Order Order()
        {
            return new Order {Amount = 100m, OrderDate = DateTime.Now, ProductName = "Silly Puddy", Quantity = 50};
        }

        public static Store Store()
        {
            return new Store
                       {
                           Name = "Bozos 'R Us!",
                           AccountingCode = "9987",
                       };
        }

        public static Customer[] LotsaCustomers()
        {
            return new[]
                       {
                           new Customer {FirstName = "Kurt", LastName = "Bittner"},
                           new Customer {FirstName = "Oleg", LastName = "Zhurakousky"},
                           new Customer {FirstName = "Rob", LastName = "Vettor"},
                           new Customer {FirstName = "John", LastName = "Cook"},
                           new Customer {FirstName = "Michael", LastName = "Azocar"},
                           new Customer {FirstName = "Dustin", LastName = "Lyday"},
                           new Customer {FirstName = "Maulik", LastName = "Modi"},
                           new Customer {FirstName = "Chris", LastName = "Koenig"},
                           new Customer {FirstName = "Shawn", LastName = "Weisfeld"},
                           new Customer {FirstName = "Phil", LastName = "Wheat"},
                           new Customer {FirstName = "Scott", LastName = "Hunter"},
                           new Customer {FirstName = "Murali", LastName = "Padmanaban"},
                           new Customer {FirstName = "Jefffery", LastName = "Palermo"},
                           new Customer {FirstName = "Jason", LastName = "Kergosien"},
                           new Customer {FirstName = "Zain", LastName = "Naboulsi"},
                           new Customer {FirstName = "Mohammad", LastName = "Azam"},
                           new Customer {FirstName = "Dan", LastName = "Cornell"},
                           new Customer {FirstName = "Sang", LastName = "Shin"},
                           new Customer {FirstName = "Minoy", LastName = "Mathew"},
                           new Customer {FirstName = "Claudio", LastName = "Lassala"},
                           new Customer {FirstName = "Dan", LastName = "Sline"},
                           new Customer {FirstName = "Will", LastName = "Ferris"},
                           new Customer {FirstName = "Todd", LastName = "Anglin"},
                           new Customer {FirstName = "Stephen", LastName = "Fulcher"},
                           new Customer {FirstName = "Raymond", LastName = "Lewallen"},
                           new Customer {FirstName = "Scott", LastName = "Hunter"},
                           new Customer {FirstName = "Jim", LastName = "Bethancourt"},
                           new Customer {FirstName = "Rob", LastName = "Vettor"},
                           new Customer {FirstName = "Tim", LastName = "Rayburn"},
                           new Customer {FirstName = "Bret", LastName = "Goldsmith"},
                           new Customer {FirstName = "Mike", LastName = "Saleme"},
                           new Customer {FirstName = "Jason", LastName = "Kergosien"},
                           new Customer {FirstName = "Philip", LastName = "Wheat"},
                           new Customer {FirstName = "Darin", LastName = "Marple"},
                           new Customer {FirstName = "Claudio", LastName = "Lassala"},
                           new Customer {FirstName = "Michael", LastName = "Azocar"},
                           new Customer {FirstName = "Ben", LastName = "Scheirman"},
                           new Customer {FirstName = "Jimmy", LastName = "Bogard"},
                           new Customer {FirstName = "Paul", LastName = "Roest"},
                           new Customer {FirstName = "Chris", LastName = "Koenig"},
                           new Customer {FirstName = "Joseph", LastName = "Hill"},
                           new Customer {FirstName = "Oleg", LastName = "Zhurakousky"},
                           new Customer {FirstName = "J", LastName = "Sawyer"},
                           new Customer {FirstName = "Mike", LastName = "Saleme"},
                           new Customer {FirstName = "David", LastName = "Neil"},
                           new Customer {FirstName = "Christian", LastName = "Thilmany"},
                           new Customer {FirstName = "Todd", LastName = "Anglin"},
                           new Customer {FirstName = "Alberto", LastName = "Antenangeli"},
                           new Customer {FirstName = "Mohammad", LastName = "Azam"},
                           new Customer {FirstName = "Tim", LastName = "Rayburn"},
                           new Customer {FirstName = "Jim", LastName = "Bethancourt"},
                           new Customer {FirstName = "John", LastName = "Ebeling"},
                           new Customer {FirstName = "Chad", LastName = "Myers"},
                           new Customer {FirstName = "Steve", LastName = "Reynolds"},
                           new Customer {FirstName = "Matheus", LastName = "Jonathan"},
                           new Customer {FirstName = "Dustin", LastName = "Lyday"},
                           new Customer {FirstName = "Scott", LastName = "Bellware"},
                           new Customer {FirstName = "Sang", LastName = "Shin"},
                           new Customer {FirstName = "Alvaro", LastName = "Fernandez"},
                           new Customer {FirstName = "Claudio", LastName = "Lassala"},
                           new Customer {FirstName = "John", LastName = "Teague"},
                           new Customer {FirstName = "Jared", LastName = "Bienz"},
                           new Customer {FirstName = "Michael", LastName = "Steinberg"},
                           new Customer {FirstName = "Omar", LastName = "Villarreal"},
                           new Customer {FirstName = "Todd", LastName = "Deering"},
                           new Customer {FirstName = "Rob", LastName = "Vettor"}
                       };
        }

    }
}