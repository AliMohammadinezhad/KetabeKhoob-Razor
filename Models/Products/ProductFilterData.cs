namespace KetabeKhoob.Razor.Models.Products;

public class ProductFilterData : BaseDto
{
    public string Title { get;  set; }
    public string ImageName { get;  set; }
    public string Description { get;  set; }
    public string Slug { get;  set; }
    public SeoData SeoData { get;  set; }
}