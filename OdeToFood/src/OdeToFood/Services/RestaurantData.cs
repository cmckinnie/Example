using OdeToFood.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace OdeToFood.Services
{

    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant newRestaurant);
    }

    public class SqlRestaurantData : IRestaurantData
    {
        private OdeTFoodDbContext _context;
        public SqlRestaurantData(OdeTFoodDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants;
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _context.Restaurants.Add(newRestaurant);
            _context.SaveChanges();
            return newRestaurant;
        }
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        static List<Restaurant> _restaurant;

        static InMemoryRestaurantData()
        {
            _restaurant = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "The House of Kobe" },
                new Restaurant {Id = 2, Name = "Mr Food" },
                new Restaurant {Id = 3, Name = "My Food House"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurant;
        }

        public Restaurant Get(int id)
        {
            return _restaurant.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurant.Max(r => r.Id) + 1;
            _restaurant.Add(newRestaurant);
            return newRestaurant;
        }
    }
}
