namespace KetabeKhoob.Razor.Models.Banners;

public class CreateBannerCommand
{
    public string Link { get; set; }
    public BannerPositionDto Position { get; set; }
    public IFormFile ImageFile { get; set; }
}