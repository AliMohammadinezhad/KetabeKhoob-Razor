using KetabeKhoob.Razor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Models.Categories;
using KetabeKhoob.Razor.Services.Categories;

namespace KetabeKhoob.Razor.Pages.Admin.Categories;

[BindProperties]
public class EditModel : BaseRazorPage
{
    private readonly ICategoryService _categoryService;

    public EditModel(ICategoryService categoryService)
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
    
    public async Task<IActionResult> OnGet(long id)
    {
        var category = await _categoryService.GetCategoryById(id);
        if (category is null)
            return RedirectToPage("Index");

        Title = category.Title;
        Slug = category.Slug;
        SeoData = SeoDataViewModel.MapSeoDataViewModel(category.SeoData);

        return Page();
    }

    public async Task<IActionResult> OnPost(long id)
    {
        var res = await _categoryService.EditCategory(new EditCategoryCommand()
        {
            Title = Title,
            SeoData = SeoData.MapToSeoData(),
            Slug = Slug,
            Id = id
        });

        return RedirectAndShowAlert(res, RedirectToPage("Index"));
    }
}