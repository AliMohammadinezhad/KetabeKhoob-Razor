using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.UserAddresses;

namespace KetabeKhoob.Razor.Services.UserAddresses;

public interface IUserAddressService
{
    Task<ApiResult> CreateAddress(CreateUserAddressCommand command);
    Task<ApiResult> EditAddress(EditUserAddressCommand command);
    Task<ApiResult> DeleteAddress(long addressId);

    Task<AddressDto?> GetAddressById(long id);
    Task<List<AddressDto?>> GetAddresses();
}