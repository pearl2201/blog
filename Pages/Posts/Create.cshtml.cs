using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using blog.Data;
using blog.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace blog.Pages_Posts
{
    public class CreateModel : CategoryNamePage
    {
        private readonly blog.Data.BlogIdentityDbContext _context;
        private readonly ILogger<CreateModel> _logger;
        public CreateModel(ILogger<CreateModel> logger, blog.Data.BlogIdentityDbContext context)
        {
            _logger = logger;
            _context = context;
        }

      
        public IActionResult OnGet()
        {
            PopulateCategoriesDropdownList(_context);

            return Page();
        }

        [BindProperty]
        public Post Post { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateCategoriesDropdownList(_context,Post.Category);
                return Page();
            }
            Post.CreatedDate = DateTime.Now;
            Post.ModifiedDate = DateTime.Now;
            Console.WriteLine("Post: " + Post.ModifiedDate);
            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
