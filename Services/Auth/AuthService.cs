using System.Net;
using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Auth;

namespace KetabeKhoob.Razor.Services.Auth;

public class AuthService : IAuthService
{
    private readonly HttpClient _client;
    private readonly IHttpContextAccessor _contextAccessor;

    public AuthService(HttpClient client, IHttpContextAccessor contextAccessor)
    {
        _client = client;
        _contextAccessor = contextAccessor;
    }

    public async Task<ApiResult<LoginResponse>?> Login(LoginCommand command)
    {
        var result = await _client.PostAsJsonAsync("auth/login", command);
        return await result.Content.ReadFromJsonAsync<ApiResult<LoginResponse>>();

    }

    public async Task<ApiResult?> Register(RegisterCommand command)
    {
        var result = await _client.PostAsJsonAsync("auth/register", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult<LoginResponse>?> RefreshToken()
    {
        var refreshToken = _contextAccessor.HttpContext?.Request.Cookies["refreshToken"];
        var result = await _client.PostAsync($"auth/refreshToken?refreshToken={refreshToken}", null);
        return await result.Content.ReadFromJsonAsync<ApiResult<LoginResponse>>();
    }

    public async Task<ApiResult?> LogOut()
    {
        var result = await _client.DeleteAsync("auth/logout");
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }
}