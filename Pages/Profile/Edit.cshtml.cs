using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Infrastructure.Utils.CustomValidation.IFormFile;
using KetabeKhoob.Razor.Models.Users;
using KetabeKhoob.Razor.Models.Users.Commands;
using KetabeKhoob.Razor.Services.Users;
using Microsoft.AspNetCore.Authorization;

namespace KetabeKhoob.Razor.Pages.Profile;


[BindProperties]
public class EditModel : BaseRazorPage
{
    private readonly IUserService _userService;

    public EditModel(IUserService userService)
    {
        _userService = userService;
    }

    [Display(Name = "نام")]
    [Required(ErrorMessage = "{0} را وارد کنید.")]
    public string Name { get; set; }
    [Display(Name = "نام خانواندگی")]
    [Required(ErrorMessage = "{0} را وارد کنید.")]
    public string Family { get; set; }
    [Display(Name = "شماره تلفن")]
    [Required(ErrorMessage = "{0} را وارد کنید.")]
    public string PhoneNumber { get; set; }
    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "{0} را وارد کنید.")]
    public string Email { get; set; }
    [Display(Name = "جنسیت")]
    [Required(ErrorMessage = "{0} را وارد کنید.")]
    public GenderDto Gender { get; set; } = GenderDto.None;

    [Display(Name = "عکس پروفایل")]
    [FileImage(ErrorMessage = "تصویر پروفایل نامعتبر است.")]
    public IFormFile? Avatar { get; set; }
    public async Task OnGet()
    {
        var user = await _userService.GetCurrentUser();
        Name = user.Name;
        Family = user.Family;
        PhoneNumber = user.PhoneNumber;
        Email = user.Email;
        Gender = user.Gender;
    }

    public async Task<IActionResult> OnPost()
    {
        var result = await _userService.EditUserCurrent(new EditUserCommand()
        {
            PhoneNumber = PhoneNumber,
            Avatar = Avatar,
            Email = Email,
            Family = Family,
            Gender = Gender,
            Name = Name,
        });
        return RedirectAndShowAlert(result, RedirectToPage("./Index"));
    }
}