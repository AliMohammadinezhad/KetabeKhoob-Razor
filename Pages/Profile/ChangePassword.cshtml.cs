using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Models.Users.Commands;
using KetabeKhoob.Razor.Services.Users;
using Microsoft.AspNetCore.Authorization;

namespace KetabeKhoob.Razor.Pages.Profile
{
    [BindProperties]
    public class ChangePasswordModel : BaseRazorPage
    {
        private readonly IUserService _userService;

        public ChangePasswordModel(IUserService userService)
        {
            _userService = userService;
        }

        [Display(Name = "کلمه عبور فعلی")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [Display(Name = "کلمه عبور جدید")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [MinLength(6, ErrorMessage = "{0} باید بیشتر از 6 کاراکتر باشد.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "تکرار کلمه عبور جدید")]
        [Required(ErrorMessage = "{0} را وارد کنید.")]
        [MinLength(6, ErrorMessage = "{0} باید بیشتر از 6 کاراکتر باشد.")]
        [Compare(nameof(Password), ErrorMessage = "کلمات عبور جدید یکسان نیستند.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _userService.ChangeUserPassword(new ChangeUserPasswordCommand()
            {
                Password = Password,
                CurrentPassword = CurrentPassword,
                ConfirmPassword = ConfirmPassword
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
