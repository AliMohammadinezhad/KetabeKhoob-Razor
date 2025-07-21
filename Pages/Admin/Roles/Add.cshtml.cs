using System.ComponentModel.DataAnnotations;
using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Infrastructure.Utils;
using KetabeKhoob.Razor.Models.Roles;
using KetabeKhoob.Razor.Services.Roles;
using Microsoft.AspNetCore.Mvc;

namespace KetabeKhoob.Razor.Pages.Admin.Roles;

[BindProperties]
public class AddModel : BaseRazorPage
{
    private readonly IRoleService _roleService;

    public AddModel(IRoleService roleService)
    {
        _roleService = roleService;
    }
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید.")]
    public string Title { get; set; }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost(string[] permission)
    {
        var permissionModel = new List<Permission>();
        foreach (var item in permission)
        {
            try
            {
                permissionModel.Add(EnumUtils.ParsEnum<Permission>(item));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        var result = await _roleService.CreateRole(new CreateRoleCommand()
        {
            Title = Title,
            Permissions = permissionModel
        });
        return RedirectAndShowAlert(result, RedirectToPage("Index"));
    }
}