using KetabeKhoob.Razor.Infrastructure.Utils.CustomValidation.IFormFile;
using KetabeKhoob.Razor.Models.Sliders;
using KetabeKhoob.Razor.Services.Sliders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using KetabeKhoob.Razor.Infrastructure.RazorUtils;

namespace KetabeKhoob.Razor.Pages.Admin.Sliders
{
    [BindProperties]
    public class EditModel : BaseRazorPage
    {
        private readonly ISliderService _sliderService;

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "لینک")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Link { get; set; }

        [Display(Name = "عکس اسلایدر")]
        [FileImage(ErrorMessage = "عکس نامعتبر است.")]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "موقعیت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public SliderPositionDto Position { get; set; }

        public string ImageName { get; set; }

        public EditModel(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IActionResult> OnGet(long id)
        {
            var slider = await _sliderService.GetSliderById(id);
            if (slider is null)
                return RedirectToPage("Index");

            Title = slider.Title;
            Link = slider.Link;
            ImageName = slider.ImageName;
            Position = slider.Position;

            return Page();
        }

        public async Task<IActionResult> OnPost(long id)
        {
            var result = await _sliderService.EditSlider(new EditSliderCommand()
            {
                Id = id,
                ImageFile = ImageFile,
                Link = Link,
                Position = Position,
                Title = Title
            });

            return RedirectAndShowAlert(result, RedirectToPage("Index"), RedirectToPage("Edit", new { id }));
        }
    }
}
