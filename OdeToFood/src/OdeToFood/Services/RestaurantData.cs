using OdeToFood.Entities;
using System.Collections.Generic;

namespace OdeToFood.Services
{

    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }


    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurant;

        public InMemoryRestaurantData()
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
    }
}
