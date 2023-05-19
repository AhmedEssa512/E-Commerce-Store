using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Stock
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime Created_at { get; set; }
    }
}