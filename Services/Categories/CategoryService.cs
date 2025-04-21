using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Categories;

namespace KetabeKhoob.Razor.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResult> CreateCategory(CreateCategoryCommand command)
    {
        var result = await _httpClient.PostAsJsonAsync("Category", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> EditCategory(EditCategoryCommand command)
    {
        var result = await _httpClient.PutAsJsonAsync("Category", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> DeleteCategory(long categoryId)
    {
        var result = await _httpClient.DeleteAsync($"Category/{categoryId}");
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> AddChild(AddChildCategoryCommand command)
    {
        var result = await _httpClient.PostAsJsonAsync("Category/AddChild", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<CategoryDto?> GetCategoryById(long categoryId)
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<CategoryDto>>($"Category/{categoryId}");
        return result?.Data;
    }

    public async Task<List<CategoryDto?>> GetCategories()
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<List<CategoryDto>>>("Category");
        return result?.Data;
    }

    public async Task<List<ChildCategoryDto?>> GetChildCategories(long parentCategoryId)
    {
        var result = await _httpClient
            .GetFromJsonAsync<ApiResult<List<ChildCategoryDto>>>($"Category/GetChild/{parentCategoryId}");
        return result?.Data;
    }
}