using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using KetabeKhoob.Razor.Models.Auth;
using KetabeKhoob.Razor.Services.Auth;

namespace KetabeKhoob.Razor.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class LoginModel : PageModel
    {
        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [MinLength(5, ErrorMessage = "کلمه عبور باید بزرگتر از 5 کاراکتر باشد.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "کلمه عبور باید بزرگتر از 5 کاراکتر باشد.")]
        public string Password { get; set; }

        private readonly IAuthService _authService;
        public LoginModel(IAuthService authService)
        {
            _authService = authService;
        }

        public Task<IActionResult> OnGet()
        {
            if(User.Identity.IsAuthenticated)
                return Task.FromResult<IActionResult>(Redirect("/"));
            return Task.FromResult<IActionResult>(Page());
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _authService.Login(new LoginCommand()
            {
                PhoneNumber = PhoneNumber,
                Password = Password
            });
            if (result.IsSuccess is false)
            {
                ModelState.AddModelError(nameof(PhoneNumber), result.MetaData.Message);
                return Page();
            }

            var accessToken = result.Data.AccessToken;
            var refreshToken = result.Data.RefreshToken;
            HttpContext.Response.Cookies.Append("access-token", accessToken);
            HttpContext.Response.Cookies.Append("refresh-token", refreshToken);
            return Redirect("/");
        }
    }
}
