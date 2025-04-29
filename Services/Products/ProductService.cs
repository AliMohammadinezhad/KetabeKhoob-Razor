using System.Net.Http.Headers;
using System.Text;
using KetabeKhoob.Razor.Infrastructure;
using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Products;
using KetabeKhoob.Razor.Models.Products.Commands;
using Newtonsoft.Json;

namespace KetabeKhoob.Razor.Services.Products;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    private const string ModuleName = "Product";

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResult> CreateProduct(CreateProductCommand command)
    {
        var result = await _httpClient.PostAsJsonAsync(ModuleName, command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> EditProduct(EditProductCommand command)
    {
        var result = await _httpClient.PutAsJsonAsync(ModuleName, command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> DeleteProductImage(DeleteProductImageCommand command)
    {
        var json = JsonConvert.SerializeObject(command);
        var httpMessage = new HttpRequestMessage(HttpMethod.Delete, ModuleName)
        {
            Content = new StringContent(json, Encoding.UTF8, new MediaTypeHeaderValue("application/json"))
        };
        var result = await _httpClient.SendAsync(httpMessage);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> AddProductImage(AddProductImageCommand command)
    {
        var result = await _httpClient.PostAsJsonAsync($"{ModuleName}/Images", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ProductDto?> GetProductById(long productId)
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<ProductDto?>>($"{ModuleName}/{productId}");
        return result?.Data;
    }

    public async Task<ProductDto?> GetProductBySlug(string slug)
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<ProductDto?>>($"{ModuleName}/bySlug/{slug}");
        return result?.Data;
    }

    public async Task<ProductFilterResult> GetProductByFilter(ProductFilterParams filterParams)
    {
        var url = filterParams.GenerateBaseFilterUrl(ModuleName) +
            $"&slug={filterParams.Slug}&title={filterParams.Title}";
        if (filterParams.Id is not null)
            url += $"&Id={filterParams.Id}";
        var result = await _httpClient.GetFromJsonAsync<ApiResult<ProductFilterResult>>(url);
        return result?.Data;
    }

    public async Task<ProductShopResult> GetProductByShop(ProductShopFilterParam shopFilterParams)
    {
        var url =
            $"{ModuleName}?pageId={shopFilterParams.PageId}&take={shopFilterParams.Take}&" +
            $"categorySlug={shopFilterParams.CategorySlug}&onlyAvailableProducts={shopFilterParams.OnlyAvailableProducts}" +
            $"&search={shopFilterParams.Search}&SearchOrderBy={shopFilterParams.SearchOrderBy}&JustHasDiscount={shopFilterParams.JustHasDiscount}";
        var result = await _httpClient.GetFromJsonAsync<ApiResult<ProductShopResult>>(url);
        return result?.Data;
    }
}