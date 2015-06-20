using System.Threading.Tasks;

namespace DDDPizza.Interfaces
{
    public interface ISeedRepository
    {
        Task SeedToppings();
        Task SeedSizes();
        Task SeedSauces();
        Task SeedCheeses();
        Task SeedBreads();
    }
}