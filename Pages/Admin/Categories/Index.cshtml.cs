using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Models.Categories;
using KetabeKhoob.Razor.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace KetabeKhoob.Razor.Pages.Admin.Categories
{
    [BindProperties]
    public class IndexModel : BaseRazorPage
    {
        private readonly ICategoryService _categoryService;
        public List<CategoryDto> Categories { get; set; }
        public IndexModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task OnGet()
        {
            Categories = await _categoryService.GetCategories();
        }

        public async Task<IActionResult> OnPostDelete(long id)
        {
            return await AjaxTryCatch(async () => await _categoryService.DeleteCategory(id));
        }
    }
}
