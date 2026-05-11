using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;
using Rij62.Models.Api;

namespace Rij62.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> CreateUser([FromBody] ApiCreateUser apiUser)
    {
        var user = new User
        {
            IsAdmin = apiUser.IsAdmin,
            DisplayName = "Pending User"
        };
        _context.Users.Add(user);

        var key = Guid.NewGuid();
        var linkKey = new LinkKey
        {
            Key=key,
            UserId=user.Id,
            CreatedTime = DateTime.UtcNow,
        };
        _context.LinkKeys.Add(linkKey);
        await _context.SaveChangesAsync();
        return Ok(new ApiPostUserResponse {
            Id = user.Id,
            LinkKey = key,
        });
    }

    [HttpGet]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(_context.Users.Select((u)=>ApiGetUser.FromUser(u)));
    }

    [HttpGet("{id}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(ApiGetUser.FromUser(user));
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> PutUser(int id, [FromBody] ApiPutUser apiUser)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        user.DisplayName = apiUser.DisplayName;
        user.IsAdmin = apiUser.IsAdmin;
        _context.Users.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var result = await _context.Users.Where((u)=>u.Id == id).ExecuteDeleteAsync();
        if (result == 0)
        {
            return NotFound();
        }
        return Ok();
    }

}

