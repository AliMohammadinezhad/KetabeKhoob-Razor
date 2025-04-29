using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Roles;

namespace KetabeKhoob.Razor.Services.Roles;

public interface IRoleService
{
    Task<ApiResult> CreateRole(CreateRoleCommand command);
    Task<ApiResult> EditRole(EditRoleCommand command);

    Task<RoleDto?> GetRoleById(long id);
    Task<List<RoleDto?>> GetRoles();
}