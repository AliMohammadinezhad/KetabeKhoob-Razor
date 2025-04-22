using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Orders;
using KetabeKhoob.Razor.Models.Orders.Command;
using System.Net.Http;

namespace KetabeKhoob.Razor.Services.Orders;

public class OrderService : IOrderService
{
    private readonly HttpClient _client;

    public OrderService(HttpClient client)
    {
        _client = client;
    }

    public async Task<ApiResult> AddOrderItemCommand(AddOrderItemCommand command)
    {
        var result = await _client.PostAsJsonAsync("Order", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> CheckoutOrder(CheckoutOrderCommand command)
    {
        var result = await _client.PostAsJsonAsync("Order/Checkout", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> IncreaseOrderItem(IncreaseOrderItemCountCommand command)
    {
        var result = await _client.PutAsJsonAsync("Order/OrderItem/IncreaseCount", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> DecreaseOrderItem(DecreaseOrderItemCountCommand command)
    {
        var result = await _client.PutAsJsonAsync("Order/OrderItem/DecreaseCount", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> DeleteOrderItem(DeleteOrderItemCommand command)
    {
        var result = await _client.DeleteAsync($"Order/OrderItem/{command.OrderItemId}");
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<OrderDto?> GetOrderById(long orderId)
    {
        var result = await _client.GetFromJsonAsync<ApiResult<OrderDto?>>($"Order/OrderItem/{orderId}");
        return result?.Data;
    }

    public async Task<OrderDto?> GetCurrentOrder()
    {
        var result = await _client.GetFromJsonAsync<ApiResult<OrderDto?>>($"Order/Current");
        return result?.Data;
    }

    public async Task<OrderFilterResult> GetOrders(OrderFilterParams filterParams)
    {
        var result = await _client.GetFromJsonAsync<ApiResult<OrderFilterResult>>($"Order");
        return result?.Data;
    }
}