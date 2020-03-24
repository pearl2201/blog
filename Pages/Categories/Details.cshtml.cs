using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using blog.Data;
using blog.Models;

namespace blog.Pages_Categories
{
    public class DetailsModel : PageModel
    {
        private readonly blog.Data.BlogIdentityDbContext _context;

        public DetailsModel(blog.Data.BlogIdentityDbContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categories.Include(x => x.Posts).Include(x => x.writer).FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
