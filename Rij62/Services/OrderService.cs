using System.Diagnostics;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Rij62.Data;
using Rij62.Models;
using Rij62.Models.Api;

namespace Rij62.Services;


public class OrderFilter
{
    public int? Count { get; set; }
    public bool ShowPaymentPending { get; set; }
}

public class OrderService
{

    private AppDbContext _context;
    private OrderEventsService _orderEventsService;

    public OrderService(AppDbContext context, OrderEventsService orderEventsService)
    {
        _context = context;
        _orderEventsService = orderEventsService;
    }

    public decimal CalcTotalOrderPayAmount(Order order)
    {
        if (order.OrderItems == null)
        {
            throw new ArgumentNullException("Order.OrderItems is null make shure you load it from the database");
        }

        decimal total = 0;
        foreach (var item in order.OrderItems)
        {

            if (item.OrderProduct == null)
            {
                throw new ArgumentNullException("Order.OrderItems is null make shure you load it from the database");
            }
            if (item.Choices == null)
            {
                throw new ArgumentNullException("Order.OrderItems is null make shure you load it from the database");
            }

            total += item.OrderProduct.Price;
            foreach (var choice in item.Choices)
            {
                if (choice.ChosenOrderProduct == null)
                {
                    throw new ArgumentNullException("Order.OrderItems is null make shure you load it from the database");
                }
                total += choice.ChosenOrderProduct.Price;
            }
        }
        return total;
    }

    public IIncludableQueryable<Order, OrderProduct> FetchOrders()
    {
        return _context.Orders
          .Include((o) => o.OrderItems)
          .ThenInclude((oi) => oi.OrderProduct)
          .Include((o) => o.OrderItems)
          .ThenInclude((oi) => oi.Choices)
          .ThenInclude((choice) => choice.ChosenOrderProduct);
    }

    public async Task<Order[]> GetOrders(OrderFilter filter)
    {
        var count = filter.Count ?? 100;

        return await FetchOrders()
          .Where((o) => filter.ShowPaymentPending || o.PaymentStatus == PaymentStatus.Success)
          .Where((o) => !o.OrderItems.All((o) => o.Status == OrderStatus.PickedUp))
          .OrderBy((o) => o.PickupTime)
          .Take(count)
          .ToArrayAsync();
    }


    public async Task DeleteOrder(Order order)
    {
        _context.Orders.Remove(order);

        _context.OrderItems.RemoveRange(order.OrderItems);
        _context.OrderProducts.RemoveRange(order.OrderItems.Select((oi) => oi.OrderProduct));

        foreach (var item in order.OrderItems)
        {
            _context.OrderItemChoices.RemoveRange(item.Choices);
            _context.OrderProducts.Remove(item.OrderProduct);
        }
    }

    public async Task UpdateOrderPaymentStatus(Order order, PaymentStatus status)
    {
        order.PaymentStatus = status;
        await _orderEventsService.BroadcastEvent(new ApiOrderPaymentStatusUpdatedEvent(ApiGetOrderPaymentStatusResponse.FromOrder(order)));
        await _context.SaveChangesAsync();
    }

}
