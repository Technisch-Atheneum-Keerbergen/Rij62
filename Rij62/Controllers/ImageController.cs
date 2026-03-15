// **********************************
//          *** CRUD  ***
// Author: Xavier Demaerel
// Date: 02/03/2026
// File: Controllers/OrderController.cs
// **********************************

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;

namespace Rij62.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly string _imageDbPath;

        public ImageController(AppDbContext context, IConfiguration config)
        {
            _imageDbPath = config["ImageDbPath"];
            _context = context;
        }


        [HttpGet("{imageId}")]
        public async Task<IActionResult> GetImage(Guid imageId)
        {
            try
            {
                return File(await System.IO.File.ReadAllBytesAsync(_imageDbPath + "/" + imageId), "application/octet-stream");
            }
            catch (FileNotFoundException)
            {
                return NotFound();
            }

        }

        [HttpPost("")]
        public async Task<IActionResult> PostImage([FromForm] IFormFile image)
        {
            var imageId = Guid.NewGuid();

            Directory.CreateDirectory(_imageDbPath);
            var file = System.IO.File.OpenWrite(_imageDbPath + "/" + imageId);
            await image.CopyToAsync(file);
            file.Close();
            return Ok(imageId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            try
            {
                System.IO.File.Delete(_imageDbPath+"/"+id);
            }catch(FileNotFoundException)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}