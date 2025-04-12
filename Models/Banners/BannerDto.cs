namespace KetabeKhoob.Razor.Models.Banners;

public class BannerDto : BaseDto
{
    public string Link { get; set; }
    public string ImageName { get; set; }
    public BannerPositionDto Position { get; set; }
}