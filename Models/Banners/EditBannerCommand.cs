namespace KetabeKhoob.Razor.Models.Banners;

public class EditBannerCommand
{
    public long Id { get; set; }
    public string Link { get; set; }
    public BannerPositionDto Position { get; set; }
    public IFormFile ImageFile { get; set; }
}