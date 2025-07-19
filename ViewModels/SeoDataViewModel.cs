using System.ComponentModel.DataAnnotations;
using KetabeKhoob.Razor.Models;

namespace KetabeKhoob.Razor.ViewModels;

public class SeoDataViewModel
{
    [Display(Name = "عنوان صفحه")]
    [Required(ErrorMessage = "{0} را وارد کنید.")]
    public string? MetaTitle { get; set; }
    [DataType(DataType.MultilineText)]
    public string? MetaDescription { get; set; }
    public string? MetaKeyWords { get; set; }
    public bool IndexPage { get; set; }
    [DataType(DataType.Url)]
    public string? Canonical { get; set; }
    [DataType(DataType.MultilineText)]
    public string? Schema { get; set; }

    public SeoData MapToSeoData() => new()
    {
        Canonical = Canonical,
        MetaTitle = MetaTitle,
        MetaDescription = MetaDescription,
        MetaKeyWords = MetaKeyWords,
        IndexPage = IndexPage,
        Schema = Schema
    };

    public static SeoDataViewModel MapSeoDataViewModel(SeoData seoData) => new()
    {
        Canonical = seoData.Canonical,
        MetaTitle = seoData.MetaTitle,
        MetaDescription = seoData.MetaDescription,
        MetaKeyWords = seoData.MetaKeyWords,
        IndexPage = seoData.IndexPage,
        Schema = seoData.Schema
    };
}