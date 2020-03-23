using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using blog.Data;
using blog.Models;

namespace blog.Pages_Categories
{
    public class EditModel : PageModel
    {
        private readonly blog.Data.BlogIdentityDbContext _context;

        public EditModel(blog.Data.BlogIdentityDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categories.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var categoryToUpdate = await _context.Categories.FirstOrDefaultAsync(m => m.ID == id);
            if (categoryToUpdate == null)
            {
                return NotFound();
            }

            _context.Entry(categoryToUpdate)
                .Property("RowVersion").OriginalValue = Category.RowVersion;

           
            if (await TryUpdateModelAsync<Category>(categoryToUpdate, "Category"))
            {
                try
                {
                    categoryToUpdate.ModifiedDate = System.DateTime.Now;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Category)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty, "Unable to save. " +
                            "The category was deleted by another user.");
                        return Page();
                    }

                    var dbValues = (Category)databaseEntry.ToObject();
                    setDbErrorMessage(dbValues, clientValues, _context);

                    // Save the current RowVersion so next postback
                    // matches unless an new concurrency issue happens.
                    Category.RowVersion = (byte[])dbValues.RowVersion;
                    // Clear the model error for the next postback.
                    ModelState.Remove("DeparCategoriestment.RowVersion");
                }
            }


            return RedirectToPage("./Index");
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.ID == id);
        }

        private void setDbErrorMessage(Category dbValues,
                Category clientValues, BlogIdentityDbContext context)
        {

            if (dbValues.Name != clientValues.Name)
            {
                ModelState.AddModelError("Categoryyy.Name",
                    $"Current value: {dbValues.Name}");
            }


            ModelState.AddModelError(string.Empty,
                "The record you attempted to edit "
              + "was modified by another user after you. The "
              + "edit operation was canceled and the current values in the database "
              + "have been displayed. If you still want to edit this record, click "
              + "the Save button again.");
        }
    }
}
