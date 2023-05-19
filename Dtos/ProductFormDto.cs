using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Dtos
{
    public class ProductFormDto
    {
        public int Id { get; set; }
        [Required,MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
        
        public IFormFile Photo { get; set; }
        [Required]
        public double Price { get; set; }
        public int categoryId { get; set; }

        [Required]
        public int stockId { get; set; }

        public int OfferId { get; set; }
    }
}