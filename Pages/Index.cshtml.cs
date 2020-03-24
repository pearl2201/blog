using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using blog.Data;
using blog.Models;
using Microsoft.EntityFrameworkCore;

namespace blog.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        private readonly BlogIdentityDbContext _context;
       public IndexModel(ILogger<IndexModel> logger, BlogIdentityDbContext context) 
        {
_logger = logger;
_context = context;
        }

        public IList<Post> Posts { get;set; }
        public async Task OnGetAsync()
        {
            var postsQuery = from p in _context.Posts orderby p.CreatedDate select p;
            Posts = await postsQuery.ToListAsync();

        }
    }
}
