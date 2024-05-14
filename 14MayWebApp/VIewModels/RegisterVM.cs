using System.ComponentModel.DataAnnotations;

namespace _14MayWebApp.VIewModels
{
    public class RegisterVM
    {
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string Surname { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string  Username { get; set; }
        [DataType(DataType.EmailAddress
            )]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }


    }
}
