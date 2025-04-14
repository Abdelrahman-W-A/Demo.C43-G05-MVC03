using Demo.DAL.Models.IDentityModel;
using Demo.Presentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class AccountController(UserManager<Application_User> _userManager) : Controller
    {

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            // Return the registration view
            return View();
        }


        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if(!ModelState.IsValid) return View(viewModel);

            var user = new Application_User
            {
                UserName = viewModel.UserName,
                Email = viewModel.Email,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
            };

            var Result = _userManager.CreateAsync(user,viewModel.Password).Result;
            if (Result.Succeeded)
            {
                // User created successfully
                return RedirectToAction("Login");
            }
            else
            {
                // Handle errors
                foreach (var error in Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(viewModel);
            }
        }
        #endregion

        #region Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Simulate login logic
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Username and password are required.");
            }
            // Login successful
            return Ok("Login successful.");
        }
        #endregion

        #region Logout
        [HttpPost]
        public IActionResult Logout()
        {
            // Simulate logout logic
            // Logout successful
            return Ok("Logout successful.");
        }
        #endregion

    }
}
