using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RenewableEnergyCredits.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RenewableEnergyCredits;

namespace RenewableEnergyCredits.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly IDatabase _database;

        public DataController(IDatabase database)
        {
            _database = database;
        }

        [HttpGet("university")]
        public async Task<IActionResult> GetUniversities()
        {
            return Ok(await _database.GetUniversities());
        }

        [HttpGet("program")]
        public async Task<IActionResult> GetPrograms([FromQuery]string universityId, [FromQuery]string degree, [FromQuery]string year)
        {
            return Ok(await _database.GetPrograms(universityId, degree, year));
        }

        [HttpPost("university")]
        public async Task<IActionResult> AddUniversity([FromBody] University university)
        {
            int success = await _database.AddUniversity(university);
            return success == 0 ? (IActionResult)BadRequest("Failed to insert university in database") : Ok();
        }

        [HttpPost("program")]
        public async Task<IActionResult> AddProgram([FromBody] Models.Program program)
        {
            int success = await _database.AddProgram(program);
            return success == 0 ? (IActionResult)BadRequest("Failed to insert program in database") : Ok();
        }
    }
}
