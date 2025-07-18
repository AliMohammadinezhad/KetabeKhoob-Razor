﻿using System.Text.Json.Serialization;

namespace KetabeKhoob.Razor.Models.Categories;

public class CategoryDto : BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public long? ParentId { get; set; }
    public List<ChildCategoryDto> Children { get; set; }
}