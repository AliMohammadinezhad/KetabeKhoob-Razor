using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KetabeKhoob.Razor.Pages.Auth
{
    public class LogoutModel : BaseRazorPage
    {
        private readonly IAuthService _authService;

        public LogoutModel(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<IActionResult> OnGet()
        {
            var result = await _authService.LogOut();
            if (result.IsSuccess)
            {
                HttpContext.Response.Cookies.Delete("access-token");
                HttpContext.Response.Cookies.Delete("refresh-token");
            }
            return RedirectAndShowAlert(result,RedirectToPage("../Index"));
        }
    }
}
