using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using blog.Data;
using blog.Models;

namespace blog.Pages_Posts
{
    public class IndexModel : PageModel
    {
        private readonly blog.Data.BlogIdentityDbContext _context;

        public IndexModel(blog.Data.BlogIdentityDbContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            Post = await _context.Posts.Include(p => p.Writer).Include(p => p.Category).ToListAsync();
        }
    }
}
