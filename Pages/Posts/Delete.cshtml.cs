using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using blog.Data;
using blog.Models;
using Microsoft.AspNetCore.Authorization;

namespace blog.Pages_Posts
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly blog.Data.BlogIdentityDbContext _context;

        public DeleteModel(blog.Data.BlogIdentityDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _context.Posts.FirstOrDefaultAsync(m => m.ID == id);

            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _context.Posts.FindAsync(id);

            if (Post != null)
            {
                _context.Posts.Remove(Post);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
