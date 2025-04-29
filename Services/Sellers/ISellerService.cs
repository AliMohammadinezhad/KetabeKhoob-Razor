using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Sellers;
using KetabeKhoob.Razor.Models.Sellers.Commands;

namespace KetabeKhoob.Razor.Services.Sellers;

public interface ISellerService
{
    Task<ApiResult> CreateSeller(CreateSellerCommand command);
    Task<ApiResult> EditSeller(EditSellerCommand command);
    Task<ApiResult> AddInventory(AddSellerInventoryCommand command);
    Task<ApiResult> EditInventory(EditSellerInventoryCommand command);

    Task<SellerDto?> GetSellerById(long sellerId);
    Task<SellerDto?> GetCurrentSeller();
    Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams);

    Task<InventoryDto?> GetInventoryById(long inventoryId);
    Task<List<InventoryDto?>> GetSellerInventories();

}