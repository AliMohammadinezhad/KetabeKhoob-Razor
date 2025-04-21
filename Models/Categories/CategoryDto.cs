namespace KetabeKhoob.Razor.Models.Categories;

public class CategoryDto : BaseDto
{
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public long? ParentId { get; private set; }
    public List<ChildCategoryDto> Children { get; private set; }
}