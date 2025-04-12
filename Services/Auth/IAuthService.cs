using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Auth;

namespace KetabeKhoob.Razor.Services.Auth;

public interface IAuthService
{
    Task<ApiResult<LoginResponse>?> Login(LoginCommand command);
    Task<ApiResult?> Register(RegisterCommand command);
    Task<ApiResult<LoginResponse>?> RefreshToken();
    Task<ApiResult?> LogOut();
}
