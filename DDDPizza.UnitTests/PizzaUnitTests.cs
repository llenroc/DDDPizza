using System;
using System.Collections.Generic;
using System.Linq;
using DDDPizza.DomainModels;
using DDDPizza.DomainModels.Enums;
using DDDPizza.Mocks;
using NUnit.Framework;

namespace DDDPizza.UnitTests
{

    [TestFixture]
    public class PizzaUnitTests
    {


        [Test]
        public void Should_Create_Instance_Of_Size()
        {
            var sut = new Size("reallyBig!", 22.54m);
            Assert.IsInstanceOf<Size>(sut);
            Assert.NotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
  
        }

        [Test]
        [Ignore]
        public void Should_Create_Instance_Of_Pizza()
        {
            var sut = new Pizza(PizzaMocks.ToppingMocks().ToList(), PizzaMocks.SizeMocks().First(), PizzaMocks.BreadMocks().ElementAt(1), PizzaMocks.GetSauces().ElementAt(1), PizzaMocks.GetCheese().ElementAt(2));
            Assert.IsInstanceOf<Pizza>(sut);
            Assert.Greater(sut.Total,0);
        }


        [Test]
        [Ignore]
        public void Should_Create_Instance_Of_Order()
        {

            var pizza = new Pizza(PizzaMocks.ToppingMocks().ToList(), PizzaMocks.SizeMocks().First(), PizzaMocks.BreadMocks().ElementAt(1), PizzaMocks.GetSauces().ElementAt(1), PizzaMocks.GetCheese().ElementAt(2));
            var pizzas = new List<Pizza>() {pizza};
            var sut = new Order(ServiceType.Delivery, pizzas);

            Assert.IsInstanceOf<Order>(sut);
            Assert.Greater(sut.ServiceCharge, 0);
            Assert.Greater(sut.SubTotal, 0);
            Assert.Greater(sut.TotalAmount, 0);
        }

    }
}
