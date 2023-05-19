using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required,MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public byte[] Photo { get; set; }
        [Required]
        public double Price { get; set; }
        public int categoryId { get; set; }
        public Category category { get; set; }
        [Required]
        public int stockId { get; set; }
        public Stock stock { get; set; }
        public int OfferId { get; set; }
        public Offer offer { get; set; }
        public DateTime Created_at { get; set; }

    }
}