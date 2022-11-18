using CPMS.Models;
using CPMS.Repository;
using Microsoft.AspNetCore.Authorization;
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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepo _IProjectRepo;
        private readonly IClientRepo _IClientRepo;
        public ProjectController(IProjectRepo iProjectRepo, IClientRepo iClientRepo)
        {
            _IProjectRepo = iProjectRepo;
            _IClientRepo = iClientRepo;
        }

        [HttpPost("create-project")]
        /* [Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> CreateProject([FromBody] Project project, string TeamIds)
        {
            int[] _TeamIds = TeamIds.Trim().Split(",").Select(e => Convert.ToInt32(e)).ToArray();
            var res = await _IProjectRepo.CreateProject(project, _TeamIds);
            if (!res)
            {
                return Ok(new { message = "Failed to create Project" });
            }

            return Ok(new { message = "Project created successfully" });
        }

        [HttpGet("details/{id}")]
        /*[Authorize(Roles = "Admin,Client")]*/
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _IProjectRepo.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        /* [HttpGet("all")]
         [Authorize(Roles = "Admin")]
         public async Task<ActionResult<IEnumerable<Project>>> GetAllPrjects()
         {
             var projects = await _IProjectRepo.GetAllProjects();
             if (projects == null)
             {
                 return NotFound();
             }

             return Ok(projects);
         }*/

        /*[HttpPut("update/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProject(int id, Project project)
        {
            var res = await _IProjectRepo.UpdateProject(id, project);
            if (!res)
            {
                return Ok(new { message = "Failed to update" });
            }

            return Ok(new { message = "Updated successfully" });
        }*/

        [HttpDelete("delete-project/{id}")]
        /*[Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> DeleteProject(int id)
        {
            var res = await _IProjectRepo.DeleteProject(id);
            if (!res)
            {
                return NotFound();
            }
            return Ok(new { Message = "Deleted successfully" });
        }


        /* [HttpGet("client/{id}")]
         [Authorize(Roles = "Admin,Client")]
         public async Task<ActionResult<IEnumerable<Project>>> GetProjectsUnderClient(int id)
         {
             var projects = await _IProjectRepo.GetProjectsUnderClient(id);
             if (projects == null)
             {
                 return NotFound();
             }

             return Ok(projects);
         }*/

        /*[HttpGet("noclient")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsWithNoClients()
        {
            var projects = await _IProjectRepo.GetProjectsWithNoClient();
            if (projects == null)
            {
                return NotFound();
            }

            return Ok(projects);
        }*/

        /* [HttpPut("update/clientIds/{id}")]
         [Authorize(Roles = "Admin")]
         public async Task<IActionResult> UpdateClientIds(int id)
         {
             var projects = await _IProjectRepo.GetAllProjects();
             if (projects == null)
             {
                 return NotFound();
             }

             *//*foreach (var p in projects)
             {
                 if (p.ClientId == id)
                 {
                     p.ClientId = null;
                     var res = await _IProjectRepo.UpdateProject(p.Id, p);
                 }


             }*//*

             return Ok(new { message = "All Client Ids updated" });
         }*/

        /*  [HttpGet("demo")]
          public async Task<IActionResult> ProjectNameWithClientName(int id)
          {
              var res = await _IProjectRepo.ProjectName_WithClientName(id);
              return Ok(res);
          }*//*

      }*/
    }
}
