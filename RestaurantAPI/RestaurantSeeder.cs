using RestaurantAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestuarants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private static IEnumerable<Restaurant> GetRestuarants()
        {
            var restaurants = new List<Restaurant>()
            {
               new Restaurant()
               {
                   Name = "KFC",
                   Category = "Fast Food",
                   Description = "Kentucky Fried Chicken",
                   ContactEmail = "contact@fc.com",
                   HasDelivery = true,
                   Dishes = new List<Dish>()
                   {
                       new Dish()
                       {
                           Name = "Hot Chick",
                           Price = 10.30M
                       },
                       new Dish()
                       {
                           Name = "Chick Niggers",
                           Price = 6.9M
                       }
                   },
                   Address = new Address()
                   {
                       City = "Krakow",
                       Street = "Długi 420",
                       PostalCode = "213-70"
                   }
               },
               new Restaurant()
               {
                   Name = "McDonald",
                   Category = "Fast Food",
                   Description = "Maczek",
                   ContactEmail = "contact@mc.com",
                   HasDelivery = true,
                   Dishes = new List<Dish>()
                   {
                       new Dish()
                       {
                           Name = "Wiśniak",
                           Price = 13.30M
                       },
                       new Dish()
                       {
                           Name = "pifko",
                           Price = 3M
                       }
                   },
                   Address = new Address()
                   {
                       City = "Warszawa",
                       Street = "Kaczyńskiego 5",
                       PostalCode = "10-04-10"
                   }
               }
            };

            return restaurants;
        }
    }
}
