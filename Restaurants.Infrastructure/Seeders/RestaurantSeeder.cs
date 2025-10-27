using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantsDBContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = new List<Restaurant>
    {
        new()
        {
            Name = "McDonald's",
            Description = "The best fast food in the world",
            Category = "FastFood",
            ContactEmail = "contact@mcdonalds.com",
            HasDelivery = true,
            Address = new Address()
            {
                Street = "123 Main St",
                City = "Anytown",
                PostalCode = "12345"
            },
            Dishes = new List<Dish>
            {
                new ()
                {
                    Name = "Big Mac",
                    Description = "A delicious burger with special sauce",
                    Price = 5.99m
                },
                new ()
                {
                    Name = "Fries",
                    Description = "Crispy golden fries",
                    Price = 2.99m
                }
            }
        },
        new()
        {
            Name = "Pizza Hut",
            Description = "Delicious pizza and more",
            Category = "Pizza",
            HasDelivery = true,
            ContactEmail = "contact@pizzahut.com",
            ContactNumber = "987-654-3210",
            Address = new Address()
            {
                Street = "456 Elm St",
                City = "Othertown",
                PostalCode = "67890"
            },
            Dishes = new List<Dish>() // Initialize an empty list to avoid null references
        }
    };

        return restaurants;
    }
}
