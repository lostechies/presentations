using System.Collections.Generic;
using NUnit.Framework;

namespace InternalDSL.Tests.AdvCSharp
{
    [TestFixture]
    public class Initializers_Examples
    {
        [Test]
        public void Type_initializers_are_cool()
        {
            var order = new Order
                            {
                                OrderID = "999",
                                ProductSKU = "ABC1239944",
                                Quantity = 42,
                                Amount = 19.95m
                            };

            order.OrderID.ShouldEqual("999");
        }

        [Test]
        public void So_are_list_initializers()
        {
            var orderList = new List<Order> {new Order(), new Order(), new Order()};

            orderList.Count.ShouldEqual(3);
        }

        [Test]
        public void Dictionary_initializers_are_kinda_cool_but_a_tad_noisy()
        {
            var orderDict = new Dictionary<string, Order>
                                {
                                    {"ABC1239944", new Order()},
                                    {"999", new Order()},
                                    {"FFF", new Order {OrderID = "FFF"}}
                                };

            orderDict.ContainsKey("FFF").ShouldBeTrue();
        }

    }

    public class Order
    {
        public string OrderID { get; set; }
        public string ProductSKU { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}