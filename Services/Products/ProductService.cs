using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using KetabeKhoob.Razor.Infrastructure;
using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Products;
using KetabeKhoob.Razor.Models.Products.Commands;
using Newtonsoft.Json;
using static System.String;

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
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(command.Slug), "Slug");
        formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
        formData.Add(new StringContent(command.Title), "Title");
        formData.Add(new StringContent(command.Description), "Description");
        formData.Add(new StringContent(command.CategoryId.ToString()), "CategoryId");
        formData.Add(new StringContent(command.SubCategoryId.ToString()), "SubCategoryId");
        if(command.SecondarySubCategoryId != null)
            formData.Add(new StringContent(command.SecondarySubCategoryId.ToString() ?? Empty), "SecondarySubCategoryId");
        formData.Add(new StringContent(command.SeoData.MetaTitle ?? Empty), "SeoData.MetaTitle");
        formData.Add(new StringContent(command.SeoData.Canonical ?? Empty), "SeoData.Canonical");
        formData.Add(new StringContent(command.SeoData.MetaKeyWords ?? Empty), "SeoData.MetaKeyWords");
        formData.Add(new StringContent(command.SeoData.MetaDescription ?? Empty), "SeoData.MetaDescription");
        formData.Add(new StringContent(command.SeoData.IndexPage.ToString()), "SeoData.IndexPage");
        formData.Add(new StringContent(command.SeoData.Schema ?? Empty), "SeoData.Schema");

        var specifications = JsonConvert.SerializeObject(command.Specifications);
        formData.Add(new StringContent(specifications, Encoding.UTF8, "application/json"), "Specifications");


        var result = await _httpClient.PostAsync(ModuleName, formData);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> EditProduct(EditProductCommand command)
    {
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(command.ProductId.ToString()), "ProductId");
        formData.Add(new StringContent(command.Slug), "Slug");
        if (command.ImageFile != null)
            formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
        formData.Add(new StringContent(command.Title), "Title");
        formData.Add(new StringContent(command.Description), "Description");
        formData.Add(new StringContent(command.CategoryId.ToString()), "CategoryId");
        formData.Add(new StringContent(command.SubCategoryId.ToString()), "SubCategoryId");
        formData.Add(new StringContent(command.SecondarySubCategoryId.ToString() ?? Empty), "SecondarySubCategoryId");
        formData.Add(new StringContent(command.SeoData.MetaTitle ?? Empty), "SeoData.MetaTitle");
        formData.Add(new StringContent(command.SeoData.Canonical ?? Empty), "SeoData.Canonical");
        formData.Add(new StringContent(command.SeoData.MetaKeyWords ?? Empty), "SeoData.MetaKeyWords");
        formData.Add(new StringContent(command.SeoData.MetaDescription ?? Empty), "SeoData.MetaDescription");
        formData.Add(new StringContent(command.SeoData.IndexPage.ToString()), "SeoData.IndexPage");
        formData.Add(new StringContent(command.SeoData.Schema ?? Empty), "SeoData.Schema");

        var specifications = JsonConvert.SerializeObject(command.Specifications);
        formData.Add(new StringContent(specifications, Encoding.UTF8, "application/json"), "Specifications");


        var result = await _httpClient.PutAsync(ModuleName, formData);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> DeleteProductImage(DeleteProductImageCommand command)
    {
        var json = JsonConvert.SerializeObject(command);
        var httpMessage = new HttpRequestMessage(HttpMethod.Delete, $"{ModuleName}/Images")
        {
            Content = new StringContent(json, Encoding.UTF8, new MediaTypeHeaderValue("application/json"))
        };
        var result = await _httpClient.SendAsync(httpMessage);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> AddProductImage(AddProductImageCommand command)
    {
        var formData = new MultipartFormDataContent();
        formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
        formData.Add(new StringContent(command.ProductId.ToString()), "ProductId");
        formData.Add(new StringContent(command.Order.ToString()), "Order");
        var result = await _httpClient.PostAsync($"{ModuleName}/Images", formData);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> DeleteProduct(long productId)
    {
        var result = await _httpClient.DeleteAsync($"{ModuleName}/{productId}");
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