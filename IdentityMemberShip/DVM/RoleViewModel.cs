using System.ComponentModel.DataAnnotations;

namespace IdentityMemberShip.DVM
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
