using System.ComponentModel.DataAnnotations;

namespace IdentityMemberShip.DVM
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Enater Valied Email")]
        public string Email { get; set; }
        
        
        
        
        
        [Required]
        [MaxLength(150,ErrorMessage ="Max chars 150 chars")]
        public string Address { get; set; }






        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password not matched")]
        [Display(Name ="Confirm Pass")]
        public string ConfirmPassword { get; set; }

    }
}
