using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Order //   (only products  of the order)
    {
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public int OrderDetailId { get; set; }
    public OrderDetail orderDetail { get; set; }

    }
}