namespace KetabeKhoob.Razor.Models.Products;

public class ProductFilterResult : BaseFilter<ProductFilterData, ProductFilterParams>
{
    public string Title { get;  set; }
    public string ImageName { get;  set; }
    public string Slug { get;  set; }
}