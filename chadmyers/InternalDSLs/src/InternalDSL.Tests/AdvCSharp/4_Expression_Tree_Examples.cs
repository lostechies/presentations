using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using NUnit.Framework;

namespace InternalDSL.Tests.AdvCSharp
{
    [TestFixture]
    public class Expression_Tree_Examples
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void fun_an_profit_with_the_parse_tree()
        {
            var expression = GetPropertyExpression<Order>(o => o.OrderID);

            Console.WriteLine(expression);

            var memberExpression = expression.Body as MemberExpression;

            var propInfo = memberExpression.Member as PropertyInfo;

            propInfo.GetValue(new Order {OrderID = "ABC"}, null).ShouldEqual("ABC");
        }

        [Test]
        public void expressions_arent_just_for_reflection_they_can_be_compiled_and_run_at_runtime()
        {
            var expression = GetPropertyExpression<Order>(o => o.OrderID);

            var func = expression.Compile();

            func(new Order { OrderID = "ABC" }).ShouldEqual("ABC");
        }


        [Test]
        public void expression_can_even_be_created_and_modified()
        {
            var order = new Order {OrderID = "FUN!"};

            Get_prop_value_and_execute_method(
                order,
                o => o.OrderID,
                x => Console.WriteLine(x)
            );
        }
        
        public void Get_prop_value_and_execute_method<A>(
            A target,
            Expression<Func<A, object>> propertyExpression,
            Expression<Action<object>> methodExpression)
        {

            // Define the parameters for the various lambda expression
            // i.e. the 'x' in (x => x.Foo)
            var parameters = propertyExpression.Parameters;

            // Create an 'Invoke' expression to actually execute the property P getter
            var getPropValueExpression = Expression.Invoke(
                                                propertyExpression,
                                                parameters.Cast<Expression>());

            // Create a 'Call' expression to call the function with the value of property P
            var methodBody = methodExpression.Body as MethodCallExpression;
            var methodCall = Expression.Call(methodBody.Method, getPropValueExpression);

            // Wrap it in a lambda so we can actually call it at runtime
            var finalCall = Expression.Lambda<Action<A>>(methodCall, parameters);

            // Compile the lambda to get an actual Action<A>
            var action = finalCall.Compile();

            // Execute it!
            action(target);
        }

        public Expression<Func<T, object>> GetPropertyExpression<T>(Expression<Func<T, object>> expression)
        {
            return expression;
        }

        public MethodCallExpression GetMethodCallExpression(Expression<Action<object>> expression)
        {
            return (MethodCallExpression) expression.Body;
        }
    }
}