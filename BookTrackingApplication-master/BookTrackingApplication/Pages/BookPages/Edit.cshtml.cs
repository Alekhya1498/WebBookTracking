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

namespace BookTrackingApplication.Pages.BookPages
{
    public class EditModel : PageModel
    {
        private readonly BookTrackingApplication.Data.Context.StoreContext _context;

        public EditModel(BookTrackingApplication.Data.Context.StoreContext context)
        {
            _context = context;
        }

        [FromForm]
        public Book Book { get; set; }

        public IEnumerable<SelectListItem> Category { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book.FirstOrDefaultAsync(m => m.ISBN == id);
            List<SelectListItem> categoryList = _context.Category.Select(
               Category => new SelectListItem()
               {
                   Value = Category.NameToken
                   ,
                   Text = Category.Decription
                   ,
                   Selected = false
               }
               ).ToList();

            Category = new List<SelectListItem>(categoryList);

            if (Book == null)
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

            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.ISBN))
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

        private bool BookExists(string id)
        {
            return _context.Book.Any(e => e.ISBN == id);
        }
    }
}
