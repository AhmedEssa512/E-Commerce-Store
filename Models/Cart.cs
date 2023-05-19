using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}