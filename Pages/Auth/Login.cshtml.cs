﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Models.Auth;
using KetabeKhoob.Razor.Services.Auth;
using Newtonsoft.Json;

namespace KetabeKhoob.Razor.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class LoginModel : BaseRazorPage
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
        public string? RedirectTo { get; set; }

        private readonly IAuthService _authService;
        public LoginModel(IAuthService authService)
        {
            _authService = authService;
        }

        public Task<IActionResult> OnGet(string redirectTo)
        {
            if(User.Identity.IsAuthenticated)
                return Task.FromResult<IActionResult>(Redirect("/"));
            if (string.IsNullOrWhiteSpace(redirectTo) == false)
                RedirectTo = redirectTo;
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
                var model = JsonConvert.SerializeObject(result);
                HttpContext.Response.Cookies.Append("SystemAlert", model);
                return Page();
            }

            var accessToken = result.Data.AccessToken;
            var refreshToken = result.Data.RefreshToken;
            HttpContext.Response.Cookies.Append("access-token", accessToken);
            HttpContext.Response.Cookies.Append("refresh-token", refreshToken);
            if (string.IsNullOrWhiteSpace(RedirectTo) is false)
                return LocalRedirect(RedirectTo);
            return Redirect("/");
        }
    }
}
