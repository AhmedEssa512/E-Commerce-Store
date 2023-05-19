using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Dtos
{
    public class CategoryDto
    {
        [MaxLength(25)]
        public string name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}