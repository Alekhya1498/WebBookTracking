using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookTrackingApplication.Data;
using BookTrackingApplication.Data.Context;

namespace BookTrackingApplication.Pages.CategoryPages
{
    public class EditModel : PageModel
    {
        private readonly BookTrackingApplication.Data.Context.StoreContext _context;

        public EditModel(BookTrackingApplication.Data.Context.StoreContext context)
        {
            _context = context;
        }

        [FromForm]
        public Category Category { get; set; }

        public IEnumerable<SelectListItem> CategoryType { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.NameToken == id);
            List<SelectListItem> categorytypeList = _context.CategoryType.Select(
               CategoryType => new SelectListItem()
               {
                   Value = CategoryType.Type
                   ,
                   Text = CategoryType.Name
                   ,
                   Selected = false
               }
               ).ToList();

            CategoryType = new List<SelectListItem>(categorytypeList);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Category.NameToken))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CategoryExists(string id)
        {
            return _context.Category.Any(e => e.NameToken == id);
        }
    }
}
