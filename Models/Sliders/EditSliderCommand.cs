﻿namespace KetabeKhoob.Razor.Models.Sliders;

public class EditSliderCommand
{
    public long Id { get; set; }
    public string Link { get; set; }
    public IFormFile ImageFile { get; set; }
    public string Title { get; set; }
    public SliderPositionDto Position { get; set; }
}