using System;
using System.Collections.Generic;

namespace SportsStore.BLL
{
    public interface IOrderService : IDisposable
    {
        IEnumerable<OrderDto> GetAllOrders();
        void AddOrder(OrderDto orderDto);
    }
}