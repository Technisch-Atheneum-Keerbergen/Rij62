// **********************************
//     *** Table Controller  ***
// Author: Xavier Demaerel
// Date: 09/03/2026
// File: Rij62\Controllers\TableController.cs
// **********************************


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;

namespace Rij62.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TableController(AppDbContext context)
        {
            _context = context;
        }
        
        // ************************************************************
        //                      *** CREATE ***
        //       POST: api/tables/AddTable - Add a new table
        // ************************************************************

        [HttpPost("AddTable")]
        public async Task<ActionResult<Table>> PostTable(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTables", new { id = table.Id }, table);        
        }

        // ************************************************************ 
        //                      *** READ ***
        //   GET: api/tables/GetTables - Get all tables or with id
        // ************************************************************

        [HttpGet("GetTables/{id?}")]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables(int? id = null)
        {
            var tables = await _context.Tables.ToListAsync();
            if (tables == null || tables.Count == 0)
            {
                return NotFound();
            }
            if (id.HasValue)
            {
                tables = tables.Where(s => s.Id == id.Value).ToList();
            }
            return Ok(tables);
        }

        // ************************************************************ 
        //                      *** DELETE ***
        //   DELETE: api/tables/DeleteTable - Delete a table by id
        // ************************************************************

        [HttpDelete("DeleteTable/{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}