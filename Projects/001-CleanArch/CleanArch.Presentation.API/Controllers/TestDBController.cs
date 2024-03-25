using CleanArch.Infrastructure.Persistence.MSSQLServer;
using CleanArch.Infrastructure.Persistence.PostgreSQL;
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
        private readonly AppMSSQLDbContext _appMSSQLDbContext;
        private readonly AppPostgreSQLDbContext _appPostgreSQLDbContext;

        public TestDBController(AppMSSQLDbContext appMSSQLDbContext, AppPostgreSQLDbContext appPostgreSQLDbContext)
        {
            _appMSSQLDbContext = appMSSQLDbContext;
            _appPostgreSQLDbContext = appPostgreSQLDbContext;
        }


        [HttpGet]
        [Route("get-from-ms-sql-server")]
        public async Task<IActionResult> GetStudentsFromMSSQLServer()
        {
            var result = await _appMSSQLDbContext.Students.ToListAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("get-from-postgresql")]
        public async Task<IActionResult> GetStudentsFromPostgreSQL()
        {
            var result = await _appPostgreSQLDbContext.Students.ToListAsync();

            return Ok(result);
        }
    }
}
