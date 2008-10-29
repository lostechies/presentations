using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace InternalDSL.Tests.AdvCSharp
{
    [TestFixture]
    public class Lambda_Examples
    {
        [Test]
        public void inline_lambda()
        {
            LambdaHelper.CountWhere(new[] {"a", "aa", "b"}, s => s.StartsWith("a")).ShouldEqual(2);
        }

        [Test]
        public void multiline_lambda()
        {
            var dates = new[]
                            {
                                DateTime.Parse("25-OCT-2008 9:00AM"),
                                DateTime.Parse("26-OCT-2008 1:00PM"),
                                DateTime.Parse("27-OCT-2008 5:00PM")
                            };

            LambdaHelper.CountWhere(dates, d =>
                                               {
                                                   var timeOfDay = d.TimeOfDay;
                                                   return timeOfDay.Hours >= 12;
                                               })
                .ShouldEqual(2);
        }

        [Test]
        public void block_lambda_with_parameter()
        {
            LambdaHelper.ProcessSomeStuff(new[] { "a", "aa", "b" }, s=>
            {
                Console.WriteLine("Get ready...");
                Console.WriteLine(s);
            });
        }

        [Test]
        public void block_lambda_with_no_parameters()
        {
            LambdaHelper.JustCallMe15Times(()=>
                                               {
                                                   Console.WriteLine("Get ready...");
                                                   Console.WriteLine("Another call...");
                                               });
        }
    }

    public static class LambdaHelper
    {
        public static int CountWhere<T>(IEnumerable<T> items, Func<T, bool> finder)
        {
            var counter = 0;

            foreach( var item in items )
            {
                if (finder(item)) counter++;
            }

            return counter;
        }

        public static void ProcessSomeStuff<T>(IEnumerable<T> items, Action<T> processor)
        {
            foreach( var item in items )
            {
                processor(item);
            }
        }

        public static void JustCallMe15Times( Action someAction )
        {
            for (var i = 0; i < 15; i++)
                someAction();
        }

    }
}