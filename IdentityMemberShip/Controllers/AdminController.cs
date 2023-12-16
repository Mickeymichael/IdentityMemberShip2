using IdentityMemberShip.DVM;
using IdentityMemberShip.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityMemberShip.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminController(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }





        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }








        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> CreateRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                ///create role 

                IdentityRole identityRole = new IdentityRole
                {
                    Name= model.RoleName
                };
                 IdentityResult result=  await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("GetAllRoles", "Admin");
                }

            }


            return View (model);
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var roles = roleManager.Roles;
            return View (roles);
        }

        [HttpGet]
        public async Task< IActionResult> EditRole(string id)
        {
            var role= await roleManager.FindByIdAsync(id);
            if (role==null)
            {
                ViewBag.error = "Not found Role";
                return View("NotFound");
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model); 

        }






    }
}
