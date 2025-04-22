namespace KetabeKhoob.Razor.Models;

public class BaseFilter
{
    public int EntityCount { get; set; }
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
    public int StartPage { get; set; }
    public int EndPage { get; set; }
    public int Take { get; set; }

}

public class BaseFilter<TData, TParam> : BaseFilter
    where TData : BaseDto
    where TParam : BaseFilterParam
{
    public List<TData> Data { get; set; } = [];
    public required TParam FilterParams { get; set; }
}


public class BaseFilterParam
{
    public int PageId { get; set; } = 1;
    public int Take { get; set; } = 10;
};