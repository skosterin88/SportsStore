using System;
using System.Collections;
using System.Collections.Generic;

namespace SportsStore.DAL
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalSum { get; set; }
        public DateTime CreationTime { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}