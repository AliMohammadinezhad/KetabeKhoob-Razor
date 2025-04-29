using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Roles;

namespace KetabeKhoob.Razor.Services.Roles;

public class RoleService : IRoleService
{
    private readonly HttpClient _httpClient;

    public RoleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private const string ModuleName = "Role";
    public async Task<ApiResult> CreateRole(CreateRoleCommand command)
    {
        var result = await _httpClient.PostAsJsonAsync(ModuleName, command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> EditRole(EditRoleCommand command)
    {
        var result = await _httpClient.PutAsJsonAsync(ModuleName, command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<RoleDto?> GetRoleById(long id)
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<RoleDto?>>($"{ModuleName}/{id}");
        return result?.Data;
    }

    public async Task<List<RoleDto?>> GetRoles()
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<List<RoleDto?>>>(ModuleName);
        return result?.Data;
    }
}