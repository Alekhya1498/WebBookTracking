using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookTrackingApplication.Data;
using BookTrackingApplication.Data.Context;

namespace BookTrackingApplication.Pages.CategoryTypePages
{
    public class CreateModel : PageModel
    {
        private readonly BookTrackingApplication.Data.Context.StoreContext _context;

        public CreateModel(BookTrackingApplication.Data.Context.StoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CategoryType CategoryType { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CategoryType.Add(CategoryType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
