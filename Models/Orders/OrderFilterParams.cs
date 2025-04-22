namespace KetabeKhoob.Razor.Models.Orders;

public class OrderFilterParams : BaseFilterParam
{
    public long? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public OrderStatusDto? Status { get; set; }

}