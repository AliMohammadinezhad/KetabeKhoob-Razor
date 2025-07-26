using KetabeKhoob.Razor.Infrastructure.RazorUtils;
using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Sellers;
using KetabeKhoob.Razor.Models.Sellers.Commands;
using KetabeKhoob.Razor.Services.Sellers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KetabeKhoob.Razor.Pages.SellerPanel.Inventories
{
    public class IndexModel : BaseRazorPage
    {
        private readonly ISellerService _sellerService;
        private readonly IRenderViewToString _renderView;

        public IndexModel(ISellerService sellerService, IRenderViewToString renderView)
        {
            _sellerService = sellerService;
            _renderView = renderView;
        }

        public List<InventoryDto?> Inventories { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var seller = await _sellerService.GetCurrentSeller();
            if (seller is null)
                return Redirect("/");

            Inventories = await _sellerService.GetSellerInventories();
            return Page();
        }

        public async Task<IActionResult> OnGetEditPage(long inventoryId)
        {
            return await AjaxTryCatch(async () =>
            {
                var inventory = await _sellerService.GetInventoryById(inventoryId);
                if (inventory is null)
                    return ApiResult<string>.Error();

                var view = await _renderView.RenderToStringAsync("_Edit", new EditSellerInventoryCommand()
                {
                    Price = inventory.Price,
                    DiscountPercentage = inventory.DiscountPercentage,
                    Count = inventory.Count,
                    InventoryId = inventoryId,
                    SellerId = inventory.SellerId
                }, PageContext);

                return ApiResult<string>.Success(view);
            });
        }

        public async Task<IActionResult> OnPost(EditSellerInventoryCommand command)
        {
            return await AjaxTryCatch(async () => 
                await _sellerService.EditInventory(command));
        }
    }
}
