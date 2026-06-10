using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;
using Rij62.Models.Api;
using Rij62.Services;

namespace Rij62.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TimeSlotController : ControllerBase
{
    private readonly TimeSlotService _timeSlotService;
    private readonly OrderService _orderService;
    private readonly AppDbContext _context;
    public TimeSlotController(AppDbContext context, TimeSlotService timeSlotService, OrderService orderService)
    {
        _timeSlotService = timeSlotService;
        _orderService = orderService;
        _context = context;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetTimeSlots(bool occupationCounts = false)
    {
        var slots = (await _timeSlotService.GetTimeSlots()).Slots();
        return Ok(slots.Select((s) => ApiGetTimeSlotResponse.FromTimeSlot(s, occupationCounts ? _orderService : null)));
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateTimeSlot([FromBody] ApiCreateTimeSlotRequest req)
    {
        var ts = TimeSlot.FromApiCreateTimeSlotRequest(req);
        _context.TimeSlots.Add(ts);
        await _context.SaveChangesAsync();
        return Ok();

    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateTimeSlot(int id, [FromBody] ApiCreateTimeSlotRequest req)
    {
        var slot = await _context.TimeSlots.Where((s) => s.Id == id).FirstOrDefaultAsync();
        if (slot == null)
        {
            return NotFound();
        }
        slot.StartTime = req.StartTime;
        slot.EndTime = req.EndTime;
        slot.Locked = req.Locked;
        _context.Entry(slot).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok();
    }


}