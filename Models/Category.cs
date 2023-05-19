using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required,MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}