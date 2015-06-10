using AutoMapper;

namespace DDDPizza.Api.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        public TOut CreateFromVm<TIn, TOut>(TIn obj)
        {
            return Mapper.Map<TOut>(obj);
        }
    }
}