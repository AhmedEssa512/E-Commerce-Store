using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Dtos
{
    public class ProductDto
    {
        [Required,MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
        [Required]
        public double Price { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public int StockId { get; set; }
        public int OfferId { get; set; }

    }
}