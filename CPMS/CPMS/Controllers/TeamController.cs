using CPMS.Models;
using CPMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepo _ITeamRepo;
        public TeamController(ITeamRepo  ITeamRepo)
        {
            _ITeamRepo = ITeamRepo;
        }

        [HttpPost("create-team")]
        public async Task<IActionResult> CreateTeam([FromBody]Team team, string employeeIds)
        {
            int[] _EmployeeIds = employeeIds.Trim().Split(",").Select(e => Convert.ToInt32(e)).ToArray();


            var res = await _ITeamRepo.CreateTeam(team, _EmployeeIds);
            if (!res)
            {
                return StatusCode(409); // a request conflict with the current state of the target resource.
            }

            return Ok(new { Message = "Team created successfully" });
        }

        [HttpGet("team-details/{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {

            var _Team = await _ITeamRepo.GetTeamById(id);
            if (_Team == null)
            {
                return NotFound();
            }

            return Ok(_Team);
        }

        [HttpDelete("delete-team/{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {

            var _Team = await _ITeamRepo.DeleteTeam(id);
            if (!_Team)
            {
                return NotFound();
            }

            return Ok(new {Message = "Deleted successfully"});
        }
    }
}
