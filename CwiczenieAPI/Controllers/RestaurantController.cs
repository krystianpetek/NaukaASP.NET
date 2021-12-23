using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CwiczenieAPI.Entities;
using System.Linq;
using CwiczenieAPI.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CwiczenieAPI.Services;

namespace CwiczenieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private IRestaurantServices _restaurantServices;
        public RestaurantController(IRestaurantServices restaurantServices)
        {
            _restaurantServices = restaurantServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDTO>> GetAll()
        {
            var restaurantDTO = _restaurantServices.GetAll();
            return Ok(restaurantDTO);
        }

        [HttpGet("{x}")]
        public ActionResult<RestaurantDTO> GetAll([FromRoute] int x)
        {
            var restaurantDTO = _restaurantServices.GetById(x);
            if (restaurantDTO is null)
                return NotFound();
            
            return Ok(restaurantDTO);
        }

        [HttpPost]
        public ActionResult CreateRestaurant([FromBody]CreateRestaurantDTO dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _restaurantServices.Create(dto);
            return Created($"/api/restaurant/{id}",null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _restaurantServices.Delete(id);
            if (isDeleted) return NoContent();

            return NotFound();
        }

        //[HttpPut("{id}")]
        //public ActionResult Edit([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var wynik = _restaurantServices.Edit(id);

        //}

    }
}





//[HttpGet]
//public ActionResult<IEnumerable<Restaurant>> GetAll()
//{
//    var restaurants = _dbContext.Restaurants.ToList();
//    return Ok(restaurants);
//}

//[HttpGet("{x}")]
//public ActionResult<Restaurant> GetAll([FromRoute]int x)
//{
//    var restaurants = _dbContext.Restaurants.FirstOrDefault(p => p.Id == x);
//    if(restaurants is null)
//    {
//        return NotFound();
//    }
//    return Ok(restaurants);
//}