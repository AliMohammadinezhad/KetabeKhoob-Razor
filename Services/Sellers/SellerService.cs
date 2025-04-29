using KetabeKhoob.Razor.Infrastructure;
using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Sellers;
using KetabeKhoob.Razor.Models.Sellers.Commands;

namespace KetabeKhoob.Razor.Services.Sellers;

public class SellerService : ISellerService
{
    private readonly HttpClient _httpClient;

    private const string ModuleName = "Seller";

    public SellerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResult> CreateSeller(CreateSellerCommand command)
    {
        var result = await _httpClient.PostAsJsonAsync(ModuleName, command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> EditSeller(EditSellerCommand command)
    {
        var result = await _httpClient.PutAsJsonAsync(ModuleName, command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> AddInventory(AddSellerInventoryCommand command)
    {
        var result = await _httpClient.PostAsJsonAsync($"{ModuleName}/inventory", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> EditInventory(EditSellerInventoryCommand command)
    {
        var result = await _httpClient.PutAsJsonAsync($"{ModuleName}/inventory", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<SellerDto?> GetSellerById(long sellerId)
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<SellerDto?>>($"{ModuleName}/{sellerId}");
        return result?.Data;
    }

    public async Task<SellerDto?> GetCurrentSeller()
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<SellerDto?>>($"{ModuleName}/current");
        return result?.Data;
    }

    public async Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams)
    {
        var url = filterParams.GenerateBaseFilterUrl(ModuleName) +
            $"NationalCode={filterParams.NationalCode}&ShopName={filterParams.ShopName}";
        var result = await _httpClient.GetFromJsonAsync<ApiResult<SellerFilterResult>>(url);
        return result?.Data;
    }

    public async Task<InventoryDto?> GetInventoryById(long inventoryId)
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<InventoryDto?>>($"{ModuleName}/inventory/{inventoryId}");
        return result?.Data;
    }

    public async Task<List<InventoryDto?>> GetSellerInventories()
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<List<InventoryDto?>>>($"{ModuleName}/inventory");
        return result?.Data;
    }
}