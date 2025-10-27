using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantsService> logger) : IRestaurantsService
{
    public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantsRepository.GetAllTask();
        return restaurants;

    }

    public async Task<Restaurant?> GetRestaurantById([FromRoute] int id)
    {
        logger.LogInformation("Getting restaurant with id {Id}", id);
        var restaurant = await restaurantsRepository.GetByIdTask(id);
        return restaurant;
    }
}
