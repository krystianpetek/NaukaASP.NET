using AutoMapper;
using CwiczenieAPI.Entities;
using CwiczenieAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CwiczenieAPI.Services
{
    public class RestaurantServices : IRestaurantServices
    {
        private ILogger<RestaurantServices> _logger;
        private RestaurantDbContext _dbContext;
        private IMapper _mapper;
        public RestaurantServices(RestaurantDbContext dbContext, IMapper mapper, ILogger<RestaurantServices> logger)
        {

            _mapper = mapper;
            _logger = logger;
            _dbContext = dbContext;
        }

        public RestaurantDTO GetById(int id)
        {
            var restaurants = _dbContext.Restaurants.Include(r => r.Address).Include(r => r.Dishes).FirstOrDefault(p => p.Id == id);
            if (restaurants is null)
                throw new ArgumentException("not fouind");


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
            _logger.LogWarning($"Restaurant with id: {id} DELETE action invoked");
            var restaurants = _dbContext.Restaurants.FirstOrDefault(p => p.Id == id);
            if (restaurants is null)
                return false;

            _dbContext.Restaurants.Remove(restaurants);
            _dbContext.SaveChanges();
            return true;
        }
        public bool Edit(int x, UpdateRestaurantDTO dto)
        {
            var restauracja = _dbContext.Restaurants.FirstOrDefault(r => r.Id == x);

            if (restauracja is null)
                return false;

            restauracja.Name =  dto.Name;
            restauracja.Description = dto.Description;
            restauracja.HasDelivery = dto.HasDelivery;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
