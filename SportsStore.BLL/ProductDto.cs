using System.Collections.Generic;

namespace SportsStore.BLL
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<int> CategoryIds { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
