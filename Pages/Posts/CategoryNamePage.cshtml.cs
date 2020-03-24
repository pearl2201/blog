using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using blog.Data;
using blog.Models;
using Microsoft.EntityFrameworkCore;

namespace blog.Pages_Posts
{
    public class CategoryNamePage : PageModel
    {
        public SelectList CategoryNameSL { get; set; }

        public void PopulateCategoriesDropdownList(BlogIdentityDbContext _context, object selectedCategory = null)
        {
            var categoriesQuery = from c in _context.Categories orderby c.Name select c;
            var categories = categoriesQuery.AsNoTracking().ToList();
            foreach (var item in categories)
            {
                Console.WriteLine("item: " + item.Name);
            }

            CategoryNameSL = new SelectList(categories, nameof(Category.ID), nameof(Category.Name), selectedCategory);


        }
    }
}
