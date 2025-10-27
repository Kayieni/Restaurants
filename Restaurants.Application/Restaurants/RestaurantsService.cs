using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantsService> logger) : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantsRepository.GetAllTask();

        var restaurantsDtos = restaurants.Select(RestaurantDto.FromEntity);
        return restaurantsDtos!;
    }

    public async Task<RestaurantDto?> GetRestaurantById([FromRoute] int id)
    {
        logger.LogInformation("Getting restaurant with id {Id}", id);
        var restaurant = await restaurantsRepository.GetByIdTask(id);

        var restaurantDto = RestaurantDto.FromEntity(restaurant);
        return restaurantDto;
    }
}
