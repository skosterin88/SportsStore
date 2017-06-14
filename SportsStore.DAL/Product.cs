using System.Collections.Generic;

namespace SportsStore.DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Order> Orders { get; set; }  
    }
}