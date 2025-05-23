﻿namespace KetabeKhoob.Razor.Models.Products.Commands;

public class CreateProductCommand
{
    public string Title { get; set; }
    public IFormFile ImageFile { get; set; }
    public string Description { get; set; }
    public long CategoryId { get; set; }
    public long SubCategoryId { get; set; }
    public long SecondarySubCategoryId { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public Dictionary<string, string> Specifications { get; set; }
}


public class EditProductCommand
{

    public long ProductId { get; set; }
    public string Title { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string Description { get; set; }
    public long CategoryId { get; set; }
    public long SubCategoryId { get; set; }
    public long SecondarySubCategoryId { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public Dictionary<string, string> Specifications { get; set; }

}

public class AddProductImageCommand
{
    public long ProductId { get; set; }
    public IFormFile ImageFile { get; set; }
    public int Order { get; set; }
}

public class DeleteProductImageCommand
{
    public long ProductId { get; set; }
    public long ImageId { get; set; }
}