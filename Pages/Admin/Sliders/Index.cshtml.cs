using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Models.Sliders;
using KetabeKhoob.Razor.Services.Sliders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KetabeKhoob.Razor.Pages.Admin.Sliders
{
    public class IndexModel : BaseRazorPage
    {
        private readonly ISliderService _sliderService;

        public List<SliderDto?> Sliders { get; set; }

        public IndexModel(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task OnGet()
        {
            Sliders = await _sliderService.GetSliders();
        }

        public async Task<IActionResult> OnPostDeleteSlider(long sliderId)
        {
            return await AjaxTryCatch(async () =>
            {
                return await _sliderService.DeleteSlider(sliderId);
            });
        }
    }
}
