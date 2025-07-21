using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Models.Roles;
using KetabeKhoob.Razor.Services.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KetabeKhoob.Razor.Pages.Admin.Roles;

public class IndexModel : BaseRazorPage
{
    private readonly IRoleService _roleService;

    public IndexModel(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public List<RoleDto?> Roles { get; set; }

    public async Task OnGet()
    {
        Roles = await _roleService.GetRoles();
    }

    public async Task<IActionResult> OnPostDeleteRole(long roleId)
    {
        return await AjaxTryCatch(async () =>
            await _roleService.DeleteRole(roleId)
                );
    }
}