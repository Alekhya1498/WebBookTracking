using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookTrackingApplication.Data;
using BookTrackingApplication.Data.Context;

namespace BookTrackingApplication.Pages.CategoryTypePages
{
    public class IndexModel : PageModel
    {
        private readonly BookTrackingApplication.Data.Context.StoreContext _context;

        public IndexModel(BookTrackingApplication.Data.Context.StoreContext context)
        {
            _context = context;
        }

        public IList<CategoryType> CategoryType { get;set; }

        public async Task OnGetAsync()
        {
            CategoryType = await _context.CategoryType.ToListAsync();
        }
    }
}
