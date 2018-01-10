using System;
using System.ComponentModel.DataAnnotations;

namespace letskanban.Models {
    public class Story {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }    
        [Required]
        [Display(Name = "Name of Module")]
        public string ModuleName { get; set; }
        [Required]
        [Display(Name = "Brief Description of Feature")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Name of Developer")] 
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Status")]
        public Types Status { get; set; }
        public Priority Priority { get; set; }
        [Required]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }
        [Required]
        [Display(Name = "Hours Required")]
        public int HoursRequired { get; set; }

    }
}