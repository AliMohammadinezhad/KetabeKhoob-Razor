﻿using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KetabeKhoob.Razor.TagHelpers;

public class DeleteItem : TagHelper
{
    public string Url { get; set; }
    public string Description { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "button";
        output.Attributes.Add("onclick", $"DeleteItem('{Url}','{Description}')");
        output.Attributes.Add("class", "btn btn-danger btn-sm");
        base.Process(context, output);
    }
}