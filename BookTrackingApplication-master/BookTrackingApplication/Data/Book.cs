using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookTrackingApplication.Data
{
    public class Book
    {
        [Key]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "This needs to be of length 13.")]
        [Required]
        public string ISBN { get; set; }


        [Display(Name = "Book Title")]
        public string Title { get; set; }


        
        [StringLength(100, MinimumLength = 5, ErrorMessage = "This needs to be longer.")]
        [Display(Name = "Author", Description = "Author")]
        [Required(ErrorMessage = "Author is Required", AllowEmptyStrings = false)]
        public string Author { get; set; }


        public ICollection<Category> Category { get; set; }
    }
}
