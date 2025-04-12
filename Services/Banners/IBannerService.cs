using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Banners;

namespace KetabeKhoob.Razor.Services.Banners;

public interface IBannerService
{
    Task<ApiResult?> CreateBanner(CreateBannerCommand command);
    Task<ApiResult?> EditBanner(EditBannerCommand command);
    Task<ApiResult?> DeleteBanner(long bannerId);

    Task<BannerDto?> GetBannerById(long bannerId);
    Task<List<BannerDto>> GetBannerList();
}