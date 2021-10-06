using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantNet.Models
{
    public class DishDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal price { get; set; }

    }
}
