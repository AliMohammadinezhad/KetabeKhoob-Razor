using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Banners;
using KetabeKhoob.Razor.Services.Banners;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KetabeKhoob.Razor.Pages.Admin.Banners;

public class IndexModel : BaseRazorPage
{
    private readonly IBannerService _bannerService;
    private readonly IRenderViewToString _renderView;
    public List<BannerDto> Banners { get; set; }
    public IndexModel(IBannerService bannerService, IRenderViewToString renderView)
    {
        _bannerService = bannerService;
        _renderView = renderView;
    }

    public async Task OnGet()
    {
        Banners = await _bannerService.GetBannerList();
    }

    public async Task<IActionResult> OnGetRenderAddPage()
    {
        return await AjaxTryCatch(async () =>
        {
            var view = await _renderView.RenderToStringAsync("_Add", new CreateBannerCommand(), PageContext);
            return ApiResult<string>.Success(view);
        });
    }

    public async Task<IActionResult> OnGetRenderEditPage(long id)
    {
        return await AjaxTryCatch(async () =>
        {
            var banner = await _bannerService.GetBannerById(id);
            if (banner is null)
                return ApiResult<string>.Error();

            var model = new EditBannerCommand()
            {
                Id = id,
                Position = banner.Position,
                Link = banner.Link
            };
            

            var view = await _renderView.RenderToStringAsync("_Edit", model, PageContext);
            return ApiResult<string>.Success(view);
        });
    }

    public async Task<IActionResult> OnPostDelete(long id)
    {
        return await AjaxTryCatch(async () => 
            await _bannerService.DeleteBanner(id)
            );
    }

    public async Task<IActionResult> OnPostEditBanner(EditBannerCommand command)
    {
        return await AjaxTryCatch(async () =>
            await _bannerService.EditBanner(command)
        );
    }

    public async Task<IActionResult> OnPostCreateBanner(CreateBannerCommand command)
    {
        return await AjaxTryCatch(async () =>
            await _bannerService.CreateBanner(command)
        );
    }
}