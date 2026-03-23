// **********************************
//          *** CRUD  ***
// Author: Xavier Demaerel
// Date: 02/03/2026
// File: Controllers/ScreenController.cs
// ************************************

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;

namespace Rij62.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScreenController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ScreenController(AppDbContext context)
        {
            _context = context;
        }
        
        // ************************************************************
        //                      *** CREATE ***
        //       POST: api/screens/AddScreen - Add a new screen
        // ************************************************************

        [Authorize(Policy = "AdminOnly")]
        [HttpPost("AddScreen")]
        public async Task<ActionResult<Screen>> PostScreen(Screen screen)
        {
            _context.Screens.Add(screen);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetScreens", new { id = screen.Id }, screen);
        }


        // ************************************************************
        //                      *** READ  ***
        //   GET: api/screens/GetScreens - Get all screens or with id
        // ************************************************************

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("GetScreens/{id?}")]
        public async Task<ActionResult<IEnumerable<Screen>>> GetScreens(int? id = null)
        {
            var screens = await _context.Screens.ToListAsync();
            if (screens == null || screens.Count == 0)
            {
                return NotFound();
            }
            if (id.HasValue)
            {
                screens = screens.Where(s => s.Id == id.Value).ToList();
            }
            return Ok(screens);
        }

        // ************************************************************
        //                      *** UPDATE ***
        //      UPDATE: api/screens/UpdateScreen/{id} - Update a screen by ID
        // ************************************************************
        
        [Authorize(Policy = "AdminOnly")]
        [HttpPut("UpdateScreen/{id}")] 
        public async Task<IActionResult> UpdateScreen(int id, Screen updatedScreen)
        {
            if (id != updatedScreen.Id)
            {
                return BadRequest();
            }

            var screen = await _context.Screens.FindAsync(id);
            if (screen == null)
            {
                return NotFound();
            }

            screen.Name = updatedScreen.Name;
            screen.Description = updatedScreen.Description;

            _context.Entry(screen).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // ************************************************************
        //                      *** DELETE ***
        //      DELETE: api/screens/{id} - Delete a screen by ID
        // ************************************************************
        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("screens/RemoveScreen/{id}")] 
        public async Task<IActionResult> DeleteScreen(int id)
        {
            var screen = await _context.Screens.FindAsync(id);
            if (screen == null)
            {
                return NotFound();
            }

            _context.Screens.Remove(screen);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}