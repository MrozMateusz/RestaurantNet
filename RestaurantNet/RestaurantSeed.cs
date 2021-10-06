using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantNet.Entities;

namespace RestaurantNet
{
    public class RestaurantSeed
    {
        private readonly RestaurantDB dbContext;
        public RestaurantSeed(RestaurantDB restaurantDB)
        {
            dbContext = restaurantDB;
        }

        //Dodawanie nowych restauracji do bazy danych
        public void Seed()
        {
            if (dbContext.Database.CanConnect())
            {
                if (!dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    dbContext.Restaurants.AddRange(restaurants);
                    dbContext.SaveChanges();
                }
            }
        }

        //Tworzenie listy z danymi restauracji
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>() {

            new Restaurant()
            {
                Name = "MCDonald",
                Category = "FastFood",
                Description = "MCDonald is American company, which has facility all over the world.",
                Email = "MCDonalds@gamail.com",
                Number = "777888999",
                HasDelivery = "Posiada w obrębie 20km.",
                Dishes = new List<Dish>()
                {
                    new Dish()
                    {
                        Name = "Chicken Bureger",
                        price = 4.50M,
                        Description = "Burger with chicken, salat."
                    },
                    new Dish()
                    {
                        Name = "Ice cream",
                        price = 6M,
                        Description = "Cold ice cream with cream",
                    },
                },
                Address = new Address()
                {
                    City = "Kielce",
                    Street = "ul. Sienkiewicza",
                    HouseNumber = "20",
                    PostalCode = "25-004",
                }
            },

            new Restaurant()
            {
                Name = "KFC",
                Category = "FastFood",
                Description = "KFC is American company, which has facility all over the world.",
                Email = "KFC@gamail.com",
                Number = "222333444",
                HasDelivery = "Posiada w obrębie 30km.",
                Dishes = new List<Dish>()
                {
                    new Dish()
                    {
                        Name = "Qurito Grande",
                        price = 14.50M,
                        Description = "Tortila with cheese."
                    },
                    new Dish()
                    {
                        Name = "Ice cream",
                        price = 8M,
                        Description = "Cold ice cream with cream",
                    },
                },
                Address = new Address()
                {
                    City = "Kielce",
                    Street = "ul. Sienkiewicza",
                    HouseNumber = "24",
                    PostalCode = "25-004",
                }
            },
        };
            return restaurants;
        }
    }
}
