using System.ComponentModel.DataAnnotations;
using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Infrastructure.Utils.CustomValidation.IFormFile;
using KetabeKhoob.Razor.Models.Sliders;
using KetabeKhoob.Razor.Services.Sliders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KetabeKhoob.Razor.Pages.Admin.Sliders
{
    [BindProperties]
    public class AddModel : BaseRazorPage
    {
        private readonly ISliderService _sliderService;

        public AddModel(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }
        
        [Display(Name = "لینک")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Link { get; set; }

        [Display(Name = "عکس اسلایدر")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [FileImage(ErrorMessage = "عکس نامعتبر است.")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "موقعیت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public SliderPositionDto Position { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _sliderService.CreateSlider(new CreateSliderCommand()
            {
                ImageFile = ImageFile,
                Link = Link,
                Title = Title,
                Position = Position
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
