using System.Collections.Generic;

namespace SportsStore.BLL
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<int> OrderIds { get; set; }
    }
}