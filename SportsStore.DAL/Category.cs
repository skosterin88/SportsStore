using System.Collections.Generic;

namespace SportsStore.DAL
{
    public class Category
    {
        public int Id { get; set; }
        public int ParentCategoryId { get; set; }
        public int NumberInCategoryList { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}