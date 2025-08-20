using Test_e.Server.Models;

namespace Test_e.Server.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserAsync(int userId);
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(int statusId);
        Task<Order?> GetOrderWithDetailsAsync(int id);
        Task<IEnumerable<Order>> GetOrdersWithItemsAsync();
        Task<bool> UpdateOrderStatusAsync(int orderId, int newStatusId, int? changedBy = null, string? note = null);
        Task<decimal> CalculateOrderTotalAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
