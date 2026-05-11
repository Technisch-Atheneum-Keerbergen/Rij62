using Rij62.Data;
using Rij62.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Rij62.Services;

public class UserService
{
    private AppDbContext _context;
    public UserService(AppDbContext context)
    {
        _context = context;
    }


    public async Task<User?> ConsumeLinkKey(Guid linkKey)
    {
        var link = await _context.LinkKeys.Where((k)=>k.Key == linkKey).FirstOrDefaultAsync();
        if (link == null)
        {
            return null;
        }

        _context.LinkKeys.Remove(link);

        var user = await _context.Users.FirstOrDefaultAsync((u)=> u.Id == link.UserId);

        await _context.SaveChangesAsync();
        return user;
    }
    
}