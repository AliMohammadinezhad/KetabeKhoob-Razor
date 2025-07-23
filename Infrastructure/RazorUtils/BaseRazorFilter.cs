using KetabeKhoob.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KetabeKhoob.Razor.Infrastructure.RazorUtils;

public class BaseRazorFilter<TFilterParam> : PageModel
where TFilterParam : BaseFilterParam, new()
{
    [BindProperty(SupportsGet = true)]
    public TFilterParam FilterParams { get; set; }

    public BaseRazorFilter()
    {
        FilterParams = new TFilterParam();
    }
}