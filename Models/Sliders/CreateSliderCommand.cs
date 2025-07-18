﻿namespace KetabeKhoob.Razor.Models.Sliders;

public class CreateSliderCommand
{
    public string Link { get; set; }
    public IFormFile ImageFile { get; set; }
    public string Title { get; set; }
    public SliderPositionDto Position { get; set; }
}