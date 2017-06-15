using System.Collections.Generic;

namespace SportsStore.BLL
{
    public class OrderDto
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<int> ProductIds { get; set; }
    }
}