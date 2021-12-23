using AutoMapper;
using CwiczenieAPI.Entities;
using CwiczenieAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CwiczenieAPI.Services
{
    public class RestaurantServices : IRestaurantServices
    {
        private RestaurantDbContext _dbContext;
        private IMapper _mapper;
        public RestaurantServices(RestaurantDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public RestaurantDTO GetById(int id)
        {
            var restaurants = _dbContext.Restaurants.Include(r => r.Address).Include(r => r.Dishes).FirstOrDefault(p => p.Id == id);
            if (restaurants is null)
                 return null;


            var result = _mapper.Map<RestaurantDTO>(restaurants);
            return result;
        }

        public IEnumerable<RestaurantDTO> GetAll()
        {
            var restaurants = _dbContext.Restaurants.Include(r => r.Address).Include(r => r.Dishes).ToList();
            var restaurantDTO = _mapper.Map<List<RestaurantDTO>>(restaurants);

            return restaurantDTO;
        }

        public int Create(CreateRestaurantDTO dto)
        {
            var restaurant = _mapper.Map<Restaurant>(dto);
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
            return restaurant.Id;
        }

        public bool Delete(int id)
        {
            var restaurants = _dbContext.Restaurants.FirstOrDefault(p => p.Id == id);
            if (restaurants is null)
                return false;

            _dbContext.Restaurants.Remove(restaurants);
            _dbContext.SaveChanges();
            return true;
        }
        //public Restaurant Edit(int x)
        //{
        //    var restauracja = _dbContext.Restaurants.Where
        //}
    }
}
