using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace BooksWebApp.Pages.admin
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost(string username, string password, string ReturnUrl)
        {
            if (username == "admin")
            {
                if (password == "admin")
                {
                    var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, username)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "Login");
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.
                    AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return Redirect(ReturnUrl == null ? "/Admin/Books" : ReturnUrl);
                }
            }
            return Page();
        }
    }
}

