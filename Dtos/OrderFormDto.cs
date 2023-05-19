using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Dtos
{
    public class OrderFormDto
    {
    [Required,MaxLength(256)]
    public string Name { get; set; }
    [Required,MaxLength(400)]
    public string Address { get; set; }
    [Required,MaxLength(12)]
    public string Phone { get; set; }

     public int TotalAmount { get; set; }



    }
}