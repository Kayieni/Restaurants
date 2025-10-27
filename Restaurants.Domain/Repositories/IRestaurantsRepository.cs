using Restaurants.Domain.Entities;
namespace Restaurants.Domain.Repositories;

public interface IRestaurantsRepository
{
    Task<IEnumerable<Restaurant>> GetAllTask();
    Task<Restaurant?> GetByIdTask(int id);
}
