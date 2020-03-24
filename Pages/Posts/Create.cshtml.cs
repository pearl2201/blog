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
using Microsoft.AspNetCore.Identity;
using blog.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace blog.Pages_Posts
{
    [Authorize]
    public class CreateModel : CategoryNamePage
    {

        private readonly UserManager<Writer> _userManager;
        private readonly SignInManager<Writer> _signInManager;
        private readonly blog.Data.BlogIdentityDbContext _context;
        private readonly ILogger<CreateModel> _logger;
        public CreateModel(UserManager<Writer> userManager, SignInManager<Writer> signInManager, ILogger<CreateModel> logger, blog.Data.BlogIdentityDbContext context)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<IActionResult> OnGet(int? CategoryID)
        {
            Console.WriteLine("Category: " + CategoryID);
            Category selectedCategory = null;
            if (CategoryID != null)
            {
                var categoryQuery = from category in _context.Categories where category.ID == CategoryID select category;
                selectedCategory = await categoryQuery.SingleAsync();
                Console.WriteLine("Category: " + selectedCategory.Name);
                Post = new Post();
                Post.CategoryID = selectedCategory.ID;
            }

            
            
            PopulateCategoriesDropdownList(_context, selectedCategory);

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
                PopulateCategoriesDropdownList(_context, Post.Category);
                return Page();
            }
           
            var user = await _userManager.GetUserAsync(HttpContext.User);
            Post.Writer = user;
            Post.CreatedDate = DateTime.Now;
            Post.ModifiedDate = DateTime.Now;
            Console.WriteLine("Post: " + Post.ModifiedDate);
            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
