using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Data;
using blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace blog.Pages
{
    public class LayoutModel<T> : PageModel
    {
        protected readonly ILogger<T> _logger;
        protected readonly BlogIdentityDbContext _context;
        public IList<Category> Categories {get;set;}
        public LayoutModel(ILogger<T> logger,BlogIdentityDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public virtual async Task OnGetAsync()
        {
            var categories = from m in _context.Categories select m;
            Categories = await categories.ToListAsync();
        }
    }
}
