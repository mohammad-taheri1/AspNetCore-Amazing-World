using CleanArch.Infrastructure.Persistence.MSSQLServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDBController : ControllerBase
    {
        // Don't use Your Context Directly in Controller
        // This is Just for test 
        private readonly AppMSSQLDbContext _context;

        public TestDBController(AppMSSQLDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var result = await _context.Students.ToListAsync();

            return Ok(result);
        }
    }
}
