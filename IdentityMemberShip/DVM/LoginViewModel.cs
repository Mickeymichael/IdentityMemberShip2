using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IdentityMemberShip.DVM
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password,ErrorMessage ="1-9,@,_,-")]
        
        public string Password { get; set; }



        [Display(Name="Rememeber Me")]
        public bool RememberMe { get; set; }
    }
}
