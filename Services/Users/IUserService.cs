using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Users;
using KetabeKhoob.Razor.Models.Users.Commands;
using KetabeKhoob.Razor.ViewModels.Users;

namespace KetabeKhoob.Razor.Services.Users;

public interface IUserService
{
    Task<ApiResult> CreateUser(CreateUserCommand command);
    Task<ApiResult> EditUser(EditUserCommand command);
    Task<ApiResult> ChangeUserPassword(ChangeUserPasswordCommand command);

    Task<UserDto?> GetUserById(long userId);
    Task<UserDto?> GetCurrentUser();
    Task<UserFilterResult> GetUsersByFilter(UserFilterParams filterParams);
}