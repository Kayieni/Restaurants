using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class RestaurantsRepository(RestaurantsDBContext dbContext)
    : IRestaurantsRepository
{
    public async Task<int> Create(Restaurant entity)
    {
        dbContext.Restaurants.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<Restaurant>> GetAllTask()
    {
        var restaurants = await dbContext.Restaurants.ToListAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetByIdTask(int id)
    {
        var restaurant = await dbContext.Restaurants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(rest => rest.Id == id);
        return restaurant;
    }
}