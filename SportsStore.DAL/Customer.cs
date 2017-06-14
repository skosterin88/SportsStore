using System.Collections.Generic;

namespace SportsStore.DAL
{
    public class Customer
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}