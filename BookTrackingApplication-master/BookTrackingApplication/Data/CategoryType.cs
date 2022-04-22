using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookTrackingApplication.Data
{
    public class CategoryType
    {
        [Key]
        [StringLength(80, MinimumLength = 1)]
        [Display(Name = "Category Type")]
        public string Type { get; set; }


        [StringLength(60, MinimumLength = 2)]
        [Display(Name = "Category Type Name", Description = "Type  Name")]
        [Required(ErrorMessage = "Type Name is Required", AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
