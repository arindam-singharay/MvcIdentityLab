using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MVCCore.Models;
using System.Security.Claims;

namespace MVCCore.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> LoginAsync()
        {
            // Logic for displaying the login page
            Users user = new Users();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Users user)
        {
            if (ModelState.IsValid)
            {
                // Validate user
                //var foundUser = _users.FirstOrDefault(u =>
                //    u.Username == user.Username && u.Password == user.Password);

                if(user.Username=="Admin" && user.Password == "Password")
                //if (foundUser != null)
                {
                    //var roleNames = (from ur in _userRoles
                    //                 join r in _roles on ur.RoleId equals r.RoleId
                    //                 where ur.UserId == foundUser.UserId
                    //                 select r.Role).ToList();

                    var roles = new List<string> { "Admin", "Manager", "Contributor" }; // Replace with your actual roles


                    // Build claims
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, "testUser")
                    };
                    claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        claimsPrincipal,
                        new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                        });

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                }
            }
            // If we got this far, something failed; redisplay form
            return View(user);
        }
    }
}
