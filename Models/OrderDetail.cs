using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Models
{
    public class OrderDetail // Order details
    {
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    [Required,MaxLength(256)]
    public string Name { get; set; }
    [Required,MaxLength(400)]
    public string Address { get; set; }
    [Required,MaxLength(12)]
    public string phone { get; set; }
    [Required]
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
    [Required]
    public int TotalAmount { get; set; }
    // public ICollection<OrderItem> OrderItems { get; set; }

    }
}