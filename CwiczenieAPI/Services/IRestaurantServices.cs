using CwiczenieAPI.Models;
using System.Collections.Generic;

namespace CwiczenieAPI.Services
{
    public interface IRestaurantServices
    {
        public RestaurantDTO GetById(int id);
        public IEnumerable<RestaurantDTO> GetAll();
        public int Create(CreateRestaurantDTO dto);
        public bool Delete(int id);
    }
}