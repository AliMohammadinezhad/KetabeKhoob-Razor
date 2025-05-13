using System.ComponentModel.DataAnnotations;
using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Models.Auth;
using KetabeKhoob.Razor.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KetabeKhoob.Razor.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class RegisterModel : BaseRazorPage
    {
        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [MinLength(5, ErrorMessage = "کلمه عبور باید بزرگتر از 5 کاراکتر باشد.")]
        public string PhoneNumber { get; set; }
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [MinLength(5, ErrorMessage = "کلمه عبور باید بزرگتر از 5 کاراکتر باشد.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "تکرار کلمه عبور")]
        [Compare(nameof(Password), ErrorMessage = "کلمات عبور یکسان نیستند.")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        private readonly IAuthService _authService;

        public RegisterModel(IAuthService authService)
        {
            _authService = authService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _authService.Register(new RegisterCommand()
            {
                PhoneNumber = PhoneNumber,
                Password = Password,
                ConfirmPassword = ConfirmPassword
            });

            return RedirectAndShowAlert(result, RedirectToPage("Login"));
        }
    }
}
