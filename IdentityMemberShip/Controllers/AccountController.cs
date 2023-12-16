using IdentityMemberShip.DVM;
using IdentityMemberShip.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityMemberShip.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;// used to register
        private readonly SignInManager<ApplicationUser> signInManager;// used to make signin

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }




        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Register(RegisterViewModel model)
        {
            // insert new user in db
            if (ModelState.IsValid)
            {
                var _user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Address= model.Address,
                  
                };
                var result = await userManager.CreateAsync(_user,model.Password);
                if (result.Succeeded)
                {
                    // i will signin after register
                     await signInManager.SignInAsync(_user, isPersistent: false);
                    return RedirectToAction("Index","Home");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var result= await  signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User");
                }
            
            }
            return View(model);
        }








        [HttpPost]
        public async Task< IActionResult> Logout()
        {
           await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    
    
    
    }
}
