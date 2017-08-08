﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SportsStore.Web.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public int ParentCategoryId { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoryViewModel> Subcategories { get; set; }
        public MvcHtmlString HtmlView { get; set; }
    }
}