using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Models.Sellers.Commands;
using KetabeKhoob.Razor.Services.Sellers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KetabeKhoob.Razor.Pages.SellerPanel.Inventories;

[BindProperties]
public class AddModel : BaseRazorPage
{
    private readonly ISellerService _sellerService;

    public AddModel(ISellerService sellerService)
    {
        _sellerService = sellerService;
    }

    public long ProductId { get; set; }

    [Display(Name = "تعداد موجودی")]
    [Required(ErrorMessage = "{0} را وارد کنید.")]
    public int Count { get; set; }
        
    [Display(Name = "مبلغ")]
    [Required(ErrorMessage = "{0} را وارد کنید.")]
    public int Price { get; set; }
        
    [Display(Name = "درصد تخفیف")]
    [Required(ErrorMessage = "{0} را وارد کنید.")]
    [Range(0, 100, ErrorMessage = "عددی صحیح بین 0 تا 100 وارد کنید")]
    public int DiscountPercentage { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        var seller = await _sellerService.GetCurrentSeller();
        if (seller is null)
            return RedirectToPage("Index");
        var result = await _sellerService.AddInventory(new AddSellerInventoryCommand()
        {
            Count = Count,
            DiscountPercentage = DiscountPercentage,
            Price = Price,
            ProductId = ProductId,
            SellerId = seller.Id
        });
        return RedirectAndShowAlert(result, RedirectToPage("Index"));
    }
}