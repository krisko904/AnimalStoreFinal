using AnimalStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalStore.Repository
{
    public interface IOrderRepository
    {
        Task<List<OrderModel>> GetAllOrdersAsync();
        Task<OrderModel> GetOrderByIdAsync(int orderId);
        Task<int> AddOrderAsync(OrderModel orderModel);
        Task DeleteOrderAsync(int orderId);
    }
}
