using System.ComponentModel.DataAnnotations;
using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Infrastructure.Utils.CustomValidation.IFormFile;
using KetabeKhoob.Razor.Models.Products;
using KetabeKhoob.Razor.Models.Products.Commands;
using KetabeKhoob.Razor.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KetabeKhoob.Razor.Pages.Admin.Products.Galleries;

public class IndexModel : BaseRazorPage
{
    private readonly IProductService _productService;

    public IndexModel(IProductService productService)
    {
        _productService = productService;
    }

        
    public List<ProductImageDto> Images { get; set; }
        
    [Display(Name = "عکس محصول")]
    [Required(ErrorMessage = "{0} را وارد کنید.")]
    [FileImage(ErrorMessage = "عکس نامعتبر است.")]
    [BindProperty]
    public IFormFile ImageFile { get; set; }

    [Display(Name = "ترتیب نمایش")]
    [Required(ErrorMessage = "{0} را وارد کنید.")]
    [BindProperty]
    public int Order { get; set; }
    public async Task<IActionResult> OnGet(long productId)
    {
        var product = await _productService.GetProductById(productId);
        if (product == null)
            return RedirectToPage("Index");

        Images = product.Images;
        return Page();
    }

    public async Task<IActionResult> OnPost(long productId)
    {
        return await AjaxTryCatch(async () => 
            await _productService.AddProductImage(new AddProductImageCommand()
            {
                ImageFile = ImageFile,
                Order = Order,
                ProductId = productId
            }));
    }

    public async Task<IActionResult> OnPostDeleteImage(long productId, long imageId)
    {
        Order = 1;
        return await AjaxTryCatch(async () => await _productService.DeleteProductImage(new DeleteProductImageCommand()
        {
            ImageId = imageId,
            ProductId = productId
        }), checkModelState: false);
    }
}