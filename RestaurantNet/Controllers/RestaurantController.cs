using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantNet.Entities;
using RestaurantNet.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace RestaurantNet.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDB dbcontext;
        private readonly IMapper _mapper;
        public RestaurantController(RestaurantDB restaurantDB, IMapper mapper)
        {
            dbcontext = restaurantDB;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(createRestaurantDto);
            dbcontext.Restaurants.Add(restaurant);
            dbcontext.SaveChanges();

            return Created($"/api/restaurant/{restaurant.Id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurants = dbcontext
                .Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .ToList();

            var restaurantsDto = _mapper.Map<List<RestaurantDto>>(restaurants);

            return Ok(restaurantsDto);
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = dbcontext
                .Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .FirstOrDefault(r => r.Id == id);

            if(restaurant == null)
            {
                return NotFound();
            }

            var restaurantsDto = _mapper.Map<RestaurantDto>(restaurant);

            return Ok(restaurantsDto);
        }
    }
}
