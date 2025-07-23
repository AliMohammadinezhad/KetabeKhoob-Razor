using KetabeKhoob.Razor.Infrastructure.Utils.CustomValidation.IFormFile;
using KetabeKhoob.Razor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Models.Products;
using KetabeKhoob.Razor.Models.Products.Commands;
using KetabeKhoob.Razor.Services.Products;

namespace KetabeKhoob.Razor.Pages.Admin.Products;

[BindProperties]
public class EditModel : BaseRazorPage
{
    private readonly IProductService _productService;

    public EditModel(IProductService productService)
    {
        _productService = productService;
    }


    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Title { get; set; }

    [Display(Name = "عکس محصول")]
    [FileImage(ErrorMessage = "عکس نامعتبر است")]
    public IFormFile? ImageFile { get; set; }

    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [UIHint($"Ckeditor4")]
    public string Description { get; set; }

    [Display(Name = "دسته بندی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [Range(1, long.MaxValue, ErrorMessage = "دسته بندی را وارد کنید")]
    public long CategoryId { get; set; }

    [Display(Name = "زیردسته بندی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [Range(1, long.MaxValue, ErrorMessage = "زیر دسته بندی را وارد کنید")]
    public long SubCategoryId { get; set; }

    [Display(Name = "دسته بندی سوم")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public long? SecondarySubCategoryId { get; set; }

    [Display(Name = "slug")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Slug { get; set; }


    public SeoDataViewModel SeoData { get; set; }

    public List<string> Keys { get; set; } = new();
    public List<string> Values { get; set; } = new();
    public async Task<IActionResult> OnGet(long productId)
    {
        var product = await _productService.GetProductById(productId);
        if (product is null)
            return RedirectToPage("Index");

        Title = product.Title;
        SeoData = SeoDataViewModel.MapSeoDataViewModel(product.SeoData);
        Slug = product.Slug;
        Description = product.Description;
        CategoryId = product.Category.Id;
        SubCategoryId = product.SubCategory.Id;
        SecondarySubCategoryId = product.SecondarySubCategory?.Id;
        InitSpecifications(product.Specifications);
        return Page();
    }

    public async Task<IActionResult> OnPost(long productId)
    {
        var result = await _productService.EditProduct(new EditProductCommand()
        {
            Title = Title,
            CategoryId = CategoryId,
            Description = Description,
            ImageFile = ImageFile,
            ProductId = productId,
            SubCategoryId = SubCategoryId,
            SecondarySubCategoryId = SecondarySubCategoryId,
            SeoData = SeoData.MapToSeoData(),
            Slug = Slug,
            Specifications = ConvertSpecifications()
        });

        return RedirectAndShowAlert(result, RedirectToPage("Index"));
    }

    private void InitSpecifications(List<ProductSpecificationDto> productSpecifications)
    {
        foreach (var specification in productSpecifications)
        {
            Keys.Add(specification.Key);
            Values.Add(specification.Value);
        }
    }

    private Dictionary<string, string> ConvertSpecifications()
    {
        var specifications = new Dictionary<string, string>();
        Keys.RemoveAll(x => x == null || string.IsNullOrWhiteSpace(x));
        Values.RemoveAll(x => x == null || string.IsNullOrWhiteSpace(x));
        for (var i = 0; i < Keys.Count; i++)
        {
            specifications.Add(Keys[i], Values[i]);
        }
        return specifications;
    }
}