using System.ComponentModel.DataAnnotations;

namespace letskanban.Models {
    public class RegisterViewModel 
    {
        [Required,Display(Name = "Name")]
        public string UserName { get; set; }
        [Required,DataType(DataType.Password)]
        public string  Password { get; set; }
        [Required,DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required,Display(Name="Email Id")]
        public string EmailId { get; set; }


    }
}