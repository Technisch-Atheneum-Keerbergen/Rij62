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
        //              POST: /api/tables - Add a new table
        // ************************************************************

        [HttpPost]
        public async Task<ActionResult<Table>> CreateTable(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTable), new { id = table.Id }, table);
        }

        // ************************************************************
        //                      *** READ ***
        //             GET: /api/tables - Get all tables
        // ************************************************************

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
            var tables = await _context.Tables.ToListAsync();

            if (tables.Count == 0)
            {
                return NotFound();
            }

            return Ok(tables);
        }

        // ************************************************************
        //                      *** READ ***
        //           GET: /api/tables/{id} - Get a specific table
        // ************************************************************

        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
            var table = await _context.Tables.FindAsync(id);

            if (table == null)
            {
                return NotFound();
            }

            return Ok(table);
        }

        // ************************************************************
        //                      *** QR CODE ***
        //        GET: /api/tables/{id}/qrcode - Generate table QR
        // ************************************************************

        [HttpGet("{id}/qrcode")]
        public async Task<IActionResult> GetTableQrCode(int id)
        {
            var table = await _context.Tables.FindAsync(id);

            if (table == null)
            {
                return NotFound();
            }

            // TODO: Replace with actual QR generation
            var qrContent = $"https://rij62.be/order?table={table.TableNumber}";

            return Ok(new
            {
                Table = table.TableNumber,
                Url = qrContent
            });
        }

        // ************************************************************
        //                      *** DELETE ***
        //           DELETE: /api/tables/{id} - Delete a table
        // ************************************************************

        [HttpDelete("{id}")]
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