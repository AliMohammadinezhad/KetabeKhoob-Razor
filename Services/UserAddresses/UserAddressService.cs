using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.UserAddresses;

namespace KetabeKhoob.Razor.Services.UserAddresses;

public class UserAddressService : IUserAddressService
{
    private readonly HttpClient _httpClient;

    private const string ModuleName = "UserAddress";

    public UserAddressService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResult> CreateAddress(CreateUserAddressCommand command)
    {
        var result = await _httpClient.PostAsJsonAsync(ModuleName, command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> EditAddress(EditUserAddressCommand command)
    {
        var result = await _httpClient.PutAsJsonAsync(ModuleName, command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> DeleteAddress(long addressId)
    {
        var result = await _httpClient.DeleteAsync($"{ModuleName}/{addressId}");
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> SetActiveAddress(long addressId)
    {
        var result = await _httpClient.PutAsync($"{ModuleName}/SetActiveAddress/{addressId}", null);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<AddressDto?> GetAddressById(long id)
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<AddressDto?>>($"{ModuleName}/{id}");
        return result?.Data;
    }

    public async Task<List<AddressDto?>> GetAddresses()
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<List<AddressDto?>>>(ModuleName);
        return result?.Data;
    }
}