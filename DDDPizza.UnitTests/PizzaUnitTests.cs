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

    [TestFixture, Category("UnitTests")]
    public class PizzaUnitTests
    {
        Mock<IEventPublisher> _mockEventPublisher;

        [SetUp]
        public void Setup()
        {
            _mockEventPublisher = new Mock<IEventPublisher>(MockBehavior.Strict);
        }

        #region " INVENTORY TESTS "

        [Test]
        public void Should_Create_Instance_Of_Bread()
        {
            const string name = "Double Crust";
            var sut = new Bread(name);
            var serialize = sut.ShouldSerializePrice();
            Assert.IsInstanceOf<Bread>(sut);
            Assert.IsNotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(0, sut.Price);
            Assert.AreEqual(name, sut.Name);
            Assert.AreEqual(false, serialize);
        }

        [Test]
        public void Should_Create_Instance_Of_Bread_With_Guid()
        {
            const string name = "Double Crust";
            var id = Guid.NewGuid();
            var sut = new Bread(id, name);
            var serialize = sut.ShouldSerializePrice();
            Assert.IsInstanceOf<Bread>(sut);
            Assert.IsNotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(0, sut.Price);
            Assert.AreEqual(name, sut.Name);
            Assert.AreEqual(false, serialize);
        }

        [Test]
        public void Should_Create_Instance_Of_Cheese()
        {
            const string name = "Mozzarella";
            var sut = new Cheese(name);
            var serialize = sut.ShouldSerializePrice();
            Assert.IsInstanceOf<Cheese>(sut);
            Assert.IsNotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(0, sut.Price);
            Assert.AreEqual(name, sut.Name);
            Assert.AreEqual(false, serialize);
        }

        [Test]
        public void Should_Create_Instance_Of_Cheese_With_Guid()
        {
            const string name = "Mozzarella";
            var id = Guid.NewGuid();
            var sut = new Cheese(id, name);
            var serialize = sut.ShouldSerializePrice();
            Assert.IsInstanceOf<Cheese>(sut);
            Assert.IsNotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(0, sut.Price);
            Assert.AreEqual(name, sut.Name);
            Assert.AreEqual(false, serialize);
        }

        [Test]
        public void Should_Create_Instance_Of_Sauce()
        {
            const string name = "Pesto";
            var sut = new Sauce(name);
            var serialize = sut.ShouldSerializePrice();
            Assert.IsInstanceOf<Sauce>(sut);
            Assert.IsNotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(0, sut.Price);
            Assert.AreEqual(name, sut.Name);
            Assert.AreEqual(false, serialize);
        }

        [Test]
        public void Should_Create_Instance_Of_Sauce_With_Guid()
        {
            var id = Guid.NewGuid();
            const string name = "Pesto";
            var sut = new Sauce(id, name);
            var serialize = sut.ShouldSerializePrice();
            Assert.IsInstanceOf<Sauce>(sut);
            Assert.IsNotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(0, sut.Price);
            Assert.AreEqual(name, sut.Name);
            Assert.AreEqual(false, serialize);
        }

        [Test]
        public void Should_Create_Instance_Of_Size()
        {
            const decimal price = 23.11m;
            var sut = new Size("reallyBig!", price);
            var serialize = sut.ShouldSerializePrice();
            Assert.IsInstanceOf<Size>(sut);
            Assert.NotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(price, sut.Price);
            Assert.AreEqual(true, serialize);
        }

        [Test]
        public void Should_Create_Instance_Of_Size_With_Guid()
        {
            var id = Guid.NewGuid();
            const decimal price = 23.11m;
            var sut = new Size(id,"reallyBig!", price);
            var serialize = sut.ShouldSerializePrice();
            Assert.IsInstanceOf<Size>(sut);
            Assert.NotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(price, sut.Price);
            Assert.AreEqual(true, serialize);
        }

        [Test]
        public void Should_Create_Instance_Of_Topping()
        {
            const decimal price = 1.1m;
            var sut = new Size("Mushrooms", price);
            var serialize = sut.ShouldSerializePrice();
            Assert.IsInstanceOf<Size>(sut);
            Assert.NotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(price, sut.Price);
            Assert.AreEqual(true, serialize);
        }

        [Test]
        public void Should_Create_Instance_Of_Topping_With_Guid()
        {
            var id = Guid.NewGuid();
            const decimal price = 1.1m;
            var sut = new Size(id, "Mushrooms", price);
            var serialize = sut.ShouldSerializePrice();
            Assert.IsInstanceOf<Size>(sut);
            Assert.NotNull(sut.Id);
            Assert.IsInstanceOf<Guid>(sut.Id);
            Assert.AreEqual(price, sut.Price);
            Assert.AreEqual(true, serialize);
        }

        #endregion

        [Test]
        public void Should_Create_Instance_Of_Pizza_Calculate_Total()
        {
            var sut = new Pizza(PizzaMocks.ToppingMocks().ToList(), PizzaMocks.SizeMocks().First(), PizzaMocks.BreadMocks().ElementAt(1), PizzaMocks.GetSauces().ElementAt(1), PizzaMocks.GetCheese().ElementAt(2));
            Assert.IsInstanceOf<Pizza>(sut);
            Assert.Greater(sut.Total,0);
        }

        [Test]
        public void Should_Create_Instance_Of_Order_With_Delivery()
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
            _mockEventPublisher.Verify(x => x.Publish(It.IsAny<IDomainEvent>()), Times.Once);
            Assert.IsInstanceOf<Order>(sut);
            Assert.Greater(sut.ServiceCharge, 0);
            Assert.Greater(sut.SubTotal, 0);
            Assert.AreEqual(sut.ServiceCharge + sut.SubTotal, sut.TotalAmount);
        }

        [Test]
        public void Should_Create_Instance_Of_Order_With_InRestaurant()
        {
            var pizza = new Pizza(PizzaMocks.ToppingMocks().ToList(), PizzaMocks.SizeMocks().First(), PizzaMocks.BreadMocks().ElementAt(1), PizzaMocks.GetSauces().ElementAt(1), PizzaMocks.GetCheese().ElementAt(2));
            var pizzas = new List<Pizza>() { pizza };
            var sut = new Order(ServiceType.InRestaurant, pizzas, "Jose");
            sut.ProcessOrder(sut, _mockEventPublisher.Object);

            _mockEventPublisher.VerifyAll();
            _mockEventPublisher.Verify(x => x.Publish(It.IsAny<IDomainEvent>()), Times.Never);
            Assert.IsInstanceOf<Order>(sut);
            Assert.AreEqual(sut.ServiceCharge, 0);
            Assert.Greater(sut.SubTotal, 0);
            Assert.AreEqual(sut.ServiceCharge + sut.SubTotal, sut.TotalAmount);
        }

        [Test]
        public void Should_Create_Instance_Of_Order_With_TakeOut()
        {
            var pizza = new Pizza(PizzaMocks.ToppingMocks().ToList(), PizzaMocks.SizeMocks().First(), PizzaMocks.BreadMocks().ElementAt(1), PizzaMocks.GetSauces().ElementAt(1), PizzaMocks.GetCheese().ElementAt(2));
            var pizzas = new List<Pizza>() { pizza };
            var sut = new Order(ServiceType.TakeOut, pizzas, "Jose");
            sut.ProcessOrder(sut, _mockEventPublisher.Object);

            _mockEventPublisher.VerifyAll();
            _mockEventPublisher.Verify(x => x.Publish(It.IsAny<IDomainEvent>()), Times.Never);
            Assert.IsInstanceOf<Order>(sut);
            Assert.AreEqual(sut.ServiceCharge, 0);
            Assert.Greater(sut.SubTotal, 0);
            Assert.AreEqual(sut.ServiceCharge + sut.SubTotal, sut.TotalAmount);
        }

    }
}
