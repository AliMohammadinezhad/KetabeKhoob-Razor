using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Models.Products;
using KetabeKhoob.Razor.Services.Categories;
using KetabeKhoob.Razor.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KetabeKhoob.Razor.Pages.Admin.Products;

public class IndexModel : BaseRazorFilter<ProductFilterParams>
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public IndexModel(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }
    public ProductFilterResult ProductFilterResult { get; set; }

    public async Task OnGet()
    {
        ProductFilterResult = await _productService.GetProductByFilter(FilterParams);
        
    }

    public async Task<IActionResult> OnGetLoadChildCategories(long parentId)
    {
        var options = "<option value='0'>انتخاب کنید.</option>";
        var children = await _categoryService.GetChildCategories(parentId);
        children?.ForEach(x =>
        {
            options += $"<option value='{x.Id}'>{x.Title}</option>";
        });
        return Content(options);
    }

    public async Task<IActionResult> OnPostDeleteProduct(long productId)
    {
        await _productService.DeleteProduct(productId);
        return Page();
    }
}