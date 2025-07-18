﻿namespace KetabeKhoob.Razor.Models.Categories;

public class ChildCategoryDto : BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public long ParentId { get; set; }
    public List<SecondaryChildCategoryDto> Children { get; set; }
}