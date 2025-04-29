using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Products;
using KetabeKhoob.Razor.Models.Products.Commands;

namespace KetabeKhoob.Razor.Services.Products;

public interface IProductService
{
    Task<ApiResult> CreateProduct(CreateProductCommand command);
    Task<ApiResult> EditProduct(EditProductCommand command);
    Task<ApiResult> DeleteProductImage(DeleteProductImageCommand command);
    Task<ApiResult> AddProductImage(AddProductImageCommand command);

    Task<ProductDto?> GetProductById(long productId);
    Task<ProductDto?> GetProductBySlug(string slug);
    Task<ProductFilterResult> GetProductByFilter(ProductFilterParams filterParams);
    Task<ProductShopResult> GetProductByShop(ProductShopFilterParam shopFilterParams);
}