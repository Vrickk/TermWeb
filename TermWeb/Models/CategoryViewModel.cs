using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TermWeb.Models
{
    public class CategoryViewModel
    {
        public List<Article>? Articles { get; set; }
        public SelectList? Category { get; set; }
        public string? ArticleCategory { get; set; }
        public string? SearchString { get; set; }
    }
}
