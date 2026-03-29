using Microsoft.AspNetCore.Mvc;
using Rij62.Data;
using Rij62.Services;

namespace Rij62.Controllers
{
    [ApiController]
    [Route("/api/category/root")]
    public class RootCategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly LocalizationService _localization;

        public RootCategoryController(AppDbContext context, LocalizationService localization)
        {
            _context = context;
            _localization = localization;
        }


        [HttpGet("")]
        public string[] GetRootCategories()
        {
            return Enum.GetNames<RootCategory>();
        }


    }
}
