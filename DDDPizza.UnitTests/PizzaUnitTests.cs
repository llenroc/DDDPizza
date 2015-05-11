using System.Linq;
using DDDPizza.DomainModels;
using DDDPizza.Mocks;
using NUnit.Framework;

namespace DDDPizza.UnitTests
{

    [TestFixture]
    public class PizzaUnitTests
    {

        [Test]
        public void Test()
        {
            var sut = new Pizza(PizzaMocks.ToppingMocks().ToList(), PizzaMocks.SizeMocks().First());
            Assert.IsInstanceOf<Pizza>(sut);
            Assert.Greater(sut.Total,0);
        }

    }
}
