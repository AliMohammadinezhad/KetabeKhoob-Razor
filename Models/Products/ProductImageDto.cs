namespace KetabeKhoob.Razor.Models.Products;

public class ProductImageDto : BaseDto
{
    public long ProductId { get; set; }
    public string ImageName { get; set; }
    public int Order { get; set; }
}