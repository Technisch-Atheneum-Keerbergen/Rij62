using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;
using Rij62.Models.Api;

namespace Rij62.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet()]
        public async Task<IEnumerable<ApiProduct>> GetProducts()
        {
            _context.Products.Select((p) =>
            {
                new ApiProduct
                {
                    Id=p.Id,
                    Price=p.PriceCent,
                    Stock=p.Stock,
                    IsAvailible=p.IsAvailable,
                    ImgURL=p.ImgUrl,
                    CategoryId=p.CategoryId,

                }
            })
        }
    }
}