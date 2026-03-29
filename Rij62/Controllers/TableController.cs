// **********************************
//     *** Table Controller  ***
// Author: Xavier Demaerel
// Date: 09/03/2026
// File: Rij62\Controllers\TableController.cs
// **********************************

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;

namespace Rij62.Controllers
{
    [ApiController]
    [Route("api/tables")]
    public class TableController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TableController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<ActionResult<Table>> CreateTable(Table table)
        {
            var existingTable = await _context.Tables.Where((t) => t.TableNumber == table.TableNumber).FirstOrDefaultAsync();
            if (existingTable != null)
            {
                return Conflict("Table with number already exists");
            }
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTable), new { id = table.Id }, table);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
            return Ok(await _context.Tables.ToListAsync());
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) return NotFound();

            return Ok(table);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("{id}/qrcode")]
        public async Task<IActionResult> GetTableQrCode(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) return NotFound();

            var qrContent = $"https://rij62.be/order?table={table.TableNumber}";

            return Ok(new
            {
                table = table.TableNumber,
                url = qrContent
            });
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) return NotFound();

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
