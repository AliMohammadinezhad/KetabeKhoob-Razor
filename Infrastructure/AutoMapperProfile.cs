using AutoMapper;
using KetabeKhoob.Razor.Models.UserAddresses;
using KetabeKhoob.Razor.ViewModels.Users.Addresses;

namespace KetabeKhoob.Razor.Infrastructure;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateUserAddressCommand, CreateUserAddressViewModel>().ReverseMap();
    }
}