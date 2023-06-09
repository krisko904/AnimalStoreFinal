using AnimalStore.Data;
using AnimalStore.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalStore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AnimalStoreContext context;
        private readonly IMapper mapper;

        public OrderRepository(AnimalStoreContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<OrderModel>> GetAllOrdersAsync()
        {
            var records = await context.Orders.ToListAsync();
            return mapper.Map<List<OrderModel>>(records);
        }

        public async Task<OrderModel> GetOrderByIdAsync(int orderId)
        {
            var order = await context.Orders.FindAsync(orderId);
            return mapper.Map<OrderModel>(order);
        }

        public async Task<int> AddOrderAsync(OrderModel orderModel)
        {
            var order = new Orders()
            {
                OrderDate = orderModel.OrderDate
            };

            context.Orders.Add(order);
            await context.SaveChangesAsync();

            return order.Id;
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = new Orders() { Id = orderId };

            context.Orders.Remove(order);

            await context.SaveChangesAsync();
        }
    }
}
