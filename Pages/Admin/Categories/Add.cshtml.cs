using System.ComponentModel.DataAnnotations;
using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Categories;
using KetabeKhoob.Razor.Services.Categories;
using KetabeKhoob.Razor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KetabeKhoob.Razor.Pages.Admin.Categories;

[BindProperties]
public class AddModel : BaseRazorPage
{
    private readonly ICategoryService _categoryService;

    public AddModel(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [Display(Name = "slug")]
    [Required(ErrorMessage = "{0} را وارد کنید.")]
    public string Slug { get; set; }
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید.")]
    public string Title { get; set; }
    [Display(Name = "سئو دیتا")]
    [Required(ErrorMessage = "{0} را وارد کنید.")]
    public SeoDataViewModel SeoData { get; set; }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost(long? parentId)
    {
        if (parentId is null)
        {
            var parentCategory = await _categoryService.CreateCategory(new CreateCategoryCommand()
            {
                Title = Title,
                SeoData = SeoData.MapToSeoData(),
                Slug = Slug
            });

            return RedirectAndShowAlert(parentCategory, RedirectToPage("Index"));
        }

        var childCategory = await _categoryService.AddChild(new AddChildCategoryCommand()
        {
            Slug = Slug,
            ParentId = (long)parentId!,
            Title = Title,
            SeoData = SeoData.MapToSeoData()
        });

        return RedirectAndShowAlert(childCategory, RedirectToPage("Index"));
    }
}