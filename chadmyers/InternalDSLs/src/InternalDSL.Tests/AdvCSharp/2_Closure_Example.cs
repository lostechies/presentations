using NUnit.Framework;

namespace InternalDSL.Tests.AdvCSharp
{
    [TestFixture]
    public class Closure_Example
    {
        [Test]
        public void closures_are_lambdas_that_reference_external_state()
        {
            var external_counter = 0;

            LambdaHelper.JustCallMe15Times(() =>
            {
                external_counter++;
            });

            external_counter.ShouldEqual(15);   
        }
    }
}