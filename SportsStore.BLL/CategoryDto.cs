using System.Collections.Generic;

namespace SportsStore.BLL
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public int ParentCategoryId { get; set; }
        public int NumberInCategoryList { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoryDto> Subcategories { get; set; }
        public IEnumerable<int> ProductIds { get; set; }
    }
}
