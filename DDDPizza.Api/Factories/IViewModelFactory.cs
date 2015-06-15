using DDDPizza.DomainModels;
using DDDPizza.ViewModels;

namespace DDDPizza.Api.Factories
{
    public interface IViewModelFactory
    {
        Order CreateOrder(OrderVm order);
        Pizza CreatePizza(PizzaVm pizza);
        TOut CreateFromVm<TIn, TOut>(TIn obj);
    }
}