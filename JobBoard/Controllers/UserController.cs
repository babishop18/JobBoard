using JobBoard.Data.Entities;
using JobBoard.Models.User;
using JobBoard.Service.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("RegisterUser")]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [Route("RegisterUser")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserCreate user)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(user);

                if (result == true)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(user);
        }

        [Route("Login")]
        public IActionResult LoginUser()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginViewModel user)
        {
            await _userService.LoginUserAsync(user);
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            return RedirectToAction("Index", "Home");
        }

        [Route("LogoutUser")]
        [HttpPost]
        public async Task<IActionResult> LogoutUser()
        {
            await _userService.LogoutUserAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
