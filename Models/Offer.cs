using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Offer
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public int Offer_percent { get; set; }
        public bool Active { get; set; }
        public DateTime Created_at { get; set; }
    }
}