using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Dtos
{
    public class OfferDto
    {
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public int Offer_percent { get; set; }
        public bool Active { get; set; }

    }
}