using System.Diagnostics;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;
using Rij62.Models.Api;
using Rij62.Observers;
using Rij62.Services;

namespace Rij62.Controllers;

[ApiController]
[Route("api/order/events")]
public class OrderEventsController : ControllerBase
{
    private readonly OrderEventsWebsocketService _orderEventsWebsocketService;

    public OrderEventsController(OrderEventsWebsocketService orderEventsWebsocketService)
    {

        _orderEventsWebsocketService = orderEventsWebsocketService;
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpGet("events")]
    public async Task Events([FromQuery] OrderFilter filter)
    {
        if (!HttpContext.WebSockets.IsWebSocketRequest)
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }
        using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync("rij62.OrderEvents");
        await _orderEventsWebsocketService.HandleWebsocketConnection(webSocket, filter);

    }

}

