using KetabeKhoob.Razor.Services.Auth;
using KetabeKhoob.Razor.Services.Banners;
using KetabeKhoob.Razor.Services.Categories;
using KetabeKhoob.Razor.Services.Comments;
using KetabeKhoob.Razor.Services.Orders;
using KetabeKhoob.Razor.Services.Products;
using KetabeKhoob.Razor.Services.Roles;
using KetabeKhoob.Razor.Services.Sellers;
using KetabeKhoob.Razor.Services.Sliders;
using KetabeKhoob.Razor.Services.UserAddresses;
using KetabeKhoob.Razor.Services.Users;

namespace KetabeKhoob.Razor.Infrastructure;

public static class RegisterServices
{
    public static IServiceCollection RegisterApiServices(this IServiceCollection services)
    {
        const string baseAddress = "https://localhost:7221/api/";

        services.AddHttpClient<IAuthService, AuthService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IBannerService, BannerService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<ICategoryService, CategoryService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<ICommentService, CommentService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IOrderService, OrderService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IProductService, ProductService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IRoleService, RoleService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<ISellerService, SellerService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<ISliderService, SliderService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IUserAddressService, UserAddressService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IUserService, UserService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
        return services;
    }
}