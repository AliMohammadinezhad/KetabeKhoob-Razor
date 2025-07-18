﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KetabeKhoob.Razor.TagHelpers;

public class OpenModal : TagHelper
{
    public string Url { get; set; }
    public string ModalTitle { get; set; } = "";
    public string Class { get; set; } = "btn btn-success";
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "button";
        output.Attributes.Add("class", Class);
        output.Attributes.Add("onclick", $"OpenModal('{Url}', 'defaultModal', '{ModalTitle}')");

        base.Process(context, output);
    }
}