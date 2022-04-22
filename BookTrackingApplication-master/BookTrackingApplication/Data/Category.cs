using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookTrackingApplication.Data
{
    public class Category
    {

        [Key]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Length should match .")]
        [Display(Name = "Name Token", Description = "Category  Name")]
        [Required(ErrorMessage = "Token is Required", AllowEmptyStrings = false)]


        public string NameToken { get; set; }


        [StringLength(200, MinimumLength = 10, ErrorMessage = "Length should match .")]
        [Display(Name = "Category Description")]
        public string Decription { get; set; }


        public ICollection<CategoryType> CategoryType { get; set; }
    }
}
