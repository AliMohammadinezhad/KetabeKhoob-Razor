namespace KetabeKhoob.Razor.Models;

public class SeoData
{
    public string? MetaTitle { get; private set; }
    public string? MetaDescription { get; private set; }
    public string? MetaKeyWords { get; private set; }
    public bool IndexPage { get; private set; }
    public string? Canonical { get; private set; }
    public string? Schema { get; private set; }
}