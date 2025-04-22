using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Orders;
using KetabeKhoob.Razor.Models.Orders.Command;

namespace KetabeKhoob.Razor.Services.Orders;

public interface IOrderService
{
    Task<ApiResult> AddOrderItemCommand(AddOrderItemCommand command);
    Task<ApiResult> CheckoutOrder(CheckoutOrderCommand command);
    Task<ApiResult> IncreaseOrderItem(IncreaseOrderItemCountCommand command);
    Task<ApiResult> DecreaseOrderItem(DecreaseOrderItemCountCommand command);
    Task<ApiResult> DeleteOrderItem(DeleteOrderItemCommand command);

    Task<OrderDto?> GetOrderById(long orderId);
    Task<OrderDto?> GetCurrentOrder();
    Task<OrderFilterResult> GetOrders(OrderFilterParams filterParams);
}