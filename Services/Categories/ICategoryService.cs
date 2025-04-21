using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Categories;

namespace KetabeKhoob.Razor.Services.Categories;

public interface ICategoryService
{
    Task<ApiResult> CreateCategory(CreateCategoryCommand command);
    Task<ApiResult> EditCategory(EditCategoryCommand command);
    Task<ApiResult> DeleteCategory(long categoryId);
    Task<ApiResult> AddChild(AddChildCategoryCommand command);

    Task<CategoryDto?> GetCategoryById(long categoryId);
    Task<List<CategoryDto?>> GetCategories();
    Task<List<ChildCategoryDto?>> GetChildCategories(long parentCategoryId);


}