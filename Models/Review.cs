using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace letskanban.Models 
{
    public class Review 
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Topic")]
        public string Name { get; set; }

        [Required]
        public string  Description { get; set; }

        [Required]
        [Display(Name = "Name of Developer")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }    
    }

}