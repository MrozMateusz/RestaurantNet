using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantNet.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string HasDelivery { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address {get; set;}

        public virtual List<Dish> Dishes { get; set; }
    }
}
