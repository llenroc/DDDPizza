namespace DDDPizza.Api.Factories
{
    public interface IViewModelFactory
    {
        TOut CreateFromVm<TIn, TOut>(TIn obj);
    }
}