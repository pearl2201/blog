using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using blog.Data;
using blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using blog.Areas.Identity.Data;

namespace blog.Pages_Categories
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly UserManager<Writer> _userManager;
        private readonly blog.Data.BlogIdentityDbContext _context;

        public CreateModel(UserManager<Writer> userManager, blog.Data.BlogIdentityDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            Category.writer = user;
            Category.ModifiedDate = DateTime.Now;
            Category.CreatedDate = DateTime.Now;
            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
