using KetabeKhoob.Razor.Infrastructure;
using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Users;
using KetabeKhoob.Razor.Models.Users.Commands;

namespace KetabeKhoob.Razor.Services.Users;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    private const string ModuleName = "User";

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResult> CreateUser(CreateUserCommand command)
    {
        var result = await _httpClient.PostAsJsonAsync(ModuleName, command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> EditUser(EditUserCommand command)
    {
        var formData = new MultipartFormDataContent
        {
            { new StringContent(command.Name), "Name" },
            { new StringContent(command.Family), "Family" },
            { new StringContent(command.Email), "Email" },
            { new StringContent(command.Gender.ToString()), "Gender" }
        };
        if(command.Avatar is not null)
            formData.Add(new StreamContent(command.Avatar.OpenReadStream()), "Avatar");

        var result = await _httpClient.PutAsync($"{ModuleName}", formData);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> EditUserCurrent(EditUserCommand command)
    {
        var formData = new MultipartFormDataContent
        {
            { new StringContent(command.Name), "Name" },
            { new StringContent(command.Family), "Family" },
            { new StringContent(command.Email), "Email" },
            { new StringContent(command.Gender.ToString()), "Gender" },
            { new StreamContent(command.Avatar.OpenReadStream()), "Avatar" }
        };

        var result = await _httpClient.PutAsync($"{ModuleName}/Current", formData);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> ChangeUserPassword(ChangeUserPasswordCommand command)
    {
        var result = await _httpClient.PutAsJsonAsync($"{ModuleName}/ChangePassword", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<UserDto?> GetUserById(long userId)
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<UserDto?>>($"{ModuleName}/{userId}");
        return result?.Data;
    }

    public async Task<UserDto?> GetCurrentUser()
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<UserDto?>>($"{ModuleName}/Current");
        return result?.Data;
    }

    public async Task<UserFilterResult> GetUsersByFilter(UserFilterParams filterParams)
    {
        var url = filterParams.GenerateBaseFilterUrl(ModuleName)+
                  $"&email={filterParams.Email}&PhoneNumber={filterParams.PhoneNumber}&Id={filterParams.Id}";
        var result = await _httpClient.GetFromJsonAsync<ApiResult<UserFilterResult>>(url);
        return result?.Data;
    }
}