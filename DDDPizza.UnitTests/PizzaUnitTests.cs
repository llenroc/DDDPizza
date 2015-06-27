using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Events;
using DDDPizza.DomainModels;
using DDDPizza.DomainModels.Enums;
using DDDPizza.DomainModels.Events;
using DDDPizza.DomainModels.Interfaces;
using DDDPizza.Mocks;
using Moq;
using NUnit.Framework;

namespace DDDPizza.UnitTests
{

    [TestFixture]
    public class PizzaUnitTests
    {
        Mock<IEventPublisher> _mockEventPublisher;

        [SetUp]
        public void Setup()
        {
            _mockEventPublisher = new Mock<IEventPublisher>(MockBehavior.Strict);
        }

        [Test]
        public void Should_Create_Instance_Of_Size()
        {
            var sut = new Size("reallyBig!", 22.54m);
            Assert.IsInstanceOf<Size>(sut);
            Assert.NotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
  
        }

        [Test]
        public void Should_Create_Instance_Of_Pizza_Calculate_Total()
        {
            var sut = new Pizza(PizzaMocks.ToppingMocks().ToList(), PizzaMocks.SizeMocks().First(), PizzaMocks.BreadMocks().ElementAt(1), PizzaMocks.GetSauces().ElementAt(1), PizzaMocks.GetCheese().ElementAt(2));
            Assert.IsInstanceOf<Pizza>(sut);
            Assert.Greater(sut.Total,0);
        }


        [Test]
        public void Should_Create_Instance_Of_Order()
        {

            _mockEventPublisher.Setup(x => x.Publish(It.IsAny<IDomainEvent>())).Callback(() =>
            {
                new OrderNeedsDelivery(It.IsAny<Order>());
            });

            var pizza = new Pizza(PizzaMocks.ToppingMocks().ToList(), PizzaMocks.SizeMocks().First(), PizzaMocks.BreadMocks().ElementAt(1), PizzaMocks.GetSauces().ElementAt(1), PizzaMocks.GetCheese().ElementAt(2));
            var pizzas = new List<Pizza>() {pizza};
            var sut = new Order(ServiceType.Delivery, pizzas,"Jose");
            sut.ProcessOrder(sut, _mockEventPublisher.Object);

            _mockEventPublisher.VerifyAll();
            Assert.IsInstanceOf<Order>(sut);
            Assert.Greater(sut.ServiceCharge, 0);
            Assert.Greater(sut.SubTotal, 0);
            Assert.AreEqual(sut.ServiceCharge + sut.SubTotal, sut.TotalAmount);
        }

    }
}
