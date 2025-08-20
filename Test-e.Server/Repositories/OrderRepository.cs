using Microsoft.EntityFrameworkCore;
using Test_e.Server.Data;
using Test_e.Server.Models;

namespace Test_e.Server.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserAsync(int userId)
        {
            return await _dbSet
                .Include(o => o.OrderStatus)
                .Include(o => o.Address)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.ProductVariant)
                        .ThenInclude(pv => pv.Product)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(int statusId)
        {
            return await _dbSet
                .Include(o => o.User)
                .Include(o => o.Address)
                .Include(o => o.OrderItems)
                .Where(o => o.OrderStatusId == statusId)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(o => o.User)
                .Include(o => o.Address)
                .Include(o => o.OrderStatus)
                .Include(o => o.OrderDiscount)
                .Include(o => o.DeliveryCompany)
                .Include(o => o.AssignedTo)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.ProductVariant)
                        .ThenInclude(pv => pv.Product)
                .Include(o => o.OrderAdjustments)
                .Include(o => o.OrderReturns)
                .Include(o => o.Payments)
                .Include(o => o.OrderStatusHistories)
                    .ThenInclude(osh => osh.NewStatus)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetOrdersWithItemsAsync()
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.ProductVariant)
                        .ThenInclude(pv => pv.Product)
                .Include(o => o.OrderStatus)
                .Include(o => o.User)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> UpdateOrderStatusAsync(int orderId, int newStatusId, int? changedBy = null, string? note = null)
        {
            var order = await GetByIdAsync(orderId);
            if (order == null)
                return false;

            order.OrderStatusId = newStatusId;

            // Add status history
            var statusHistory = new OrderStatusHistory
            {
                OrderId = orderId,
                NewStatusId = newStatusId,
                ChangedBy = changedBy,
                Note = note,
                ChangedAt = DateTime.UtcNow
            };

            _context.OrderStatusHistories.Add(statusHistory);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<decimal> CalculateOrderTotalAsync(int orderId)
        {
            var order = await _dbSet
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                return 0;

            var itemsTotal = order.OrderItems.Sum(oi => oi.TotalPrice);
            var adjustments = order.TotalAdjustment;
            var deliveryPrice = order.DeliveryPrice;

            return itemsTotal + adjustments + deliveryPrice;
        }

        public async Task<IEnumerable<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(o => o.OrderStatus)
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .Where(o => o.CreatedAt >= startDate && o.CreatedAt <= endDate)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }
    }
}
