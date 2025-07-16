namespace KetabeKhoob.Razor.Infrastructure;

public class Directories
{
    private const string ProductImages = "/images/products";
    private const string ProductGalleryImage = "/images/products/gallery";

    private const string BannerImages = "/images/banners";
    private const string SliderImages = "/images/sliders";

    public const string UserAvatars = "/images/users/avatar";

    public static string GetSliderImage(string imageName)
    {
        return $"{SiteSettings.ServerPath}{SliderImages}/{imageName}";
    }
    public static string GetProductImage(string imageName)
    {
        return $"{SiteSettings.ServerPath}{ProductImages}/{imageName}";
    }
    public static string GetProductImageGallery(string imageName)
    {
        return $"{SiteSettings.ServerPath}{ProductGalleryImage}/{imageName}";
    }
    public static string GetBannerImage(string imageName)
    {
        return $"{SiteSettings.ServerPath}{BannerImages}/{imageName}";
    }

    public static string GetSliderImages(string imageName)
    {
        return $"{SiteSettings.ServerPath}{SliderImages}/{imageName}";

    }
}