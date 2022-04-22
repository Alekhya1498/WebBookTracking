using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookTrackingApplication.Data.Context
{
  
    public class StoreContext
          : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
           : base(options)
        {

        }

        public DbSet<CategoryType> CategoryType { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Book> Book { get; set; }
    }
}
