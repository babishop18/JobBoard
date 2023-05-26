using JobBoard.Data.Entities;
using JobBoard.Models.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JobBoard.Service.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<bool> RegisterUserAsync(UserCreate user)
        {
            ApplicationUser appUser = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);

            if (result.Succeeded)
            {
                var currentUser = await _userManager.FindByNameAsync(user.UserName);
                if (currentUser.Role == "company")
                {
                    var roleResult = await _userManager.AddToRoleAsync(currentUser, "Company");
                }
                else if (currentUser.Role == "applicant")
                {
                    var roleResult = await _userManager.AddToRoleAsync(currentUser, "Applicant");
                }
                await _signInManager.SignInAsync(appUser, isPersistent: false);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LoginUserAsync(LoginViewModel user)
        {
            var currentUser = await _userManager.FindByNameAsync(user.UserName);
            if (currentUser != null) 
            {
                var passwordCheck = await _signInManager.PasswordSignInAsync(currentUser, user.Password, false, false);       
                if (passwordCheck.Succeeded) 
                { 
                    return true; 
                }
                else { return false; }

            }
            return false;
        }

        public async Task<bool> LogoutUserAsync()
        {
            await _signInManager.SignOutAsync();
            if (_userManager != null) 
            {
                return false;
            }
            return true;
        }
    }
}
