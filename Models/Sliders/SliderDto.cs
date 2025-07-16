namespace KetabeKhoob.Razor.Models.Sliders;

public class SliderDto : BaseDto
{
    public string Title { get; set; }
    public string Link { get; set; }
    public string ImageName { get; set; }
    public SliderPositionDto Position { get; set; }
}
public enum SliderPositionDto
{
    Left,
    Top,
    Right,
    Bottom,
}