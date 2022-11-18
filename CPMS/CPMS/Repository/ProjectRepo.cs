using CPMS.DBConnect;
using CPMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.Repository
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly CPMDbContext cPMDbContext;

        public ProjectRepo(CPMDbContext cPMDbContext)
        {
            this.cPMDbContext = cPMDbContext;
        }

        public async Task<bool> CreateProject(Project project, int[] TeamIds)
        {

            var _Project = new Project
            {
                Name = project.Name,
                FRequirement = project.FRequirement,
                NFRequirement = project.NFRequirement,
                Budget = project.Budget,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Technology = project.Technology
            };
            cPMDbContext.Projects.Add(_Project) ;

            try
            {
                await cPMDbContext.SaveChangesAsync();

                foreach(var tid in TeamIds)
                {
                    var _Team =  await cPMDbContext.Teams.Where(x => x.Id == tid).FirstOrDefaultAsync();
                    _Team.ProjectId = _Project.Id;
                    await cPMDbContext.SaveChangesAsync();
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteProject(int id)
        {
            var project = await cPMDbContext.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (project == null) return false;

            var _Teams = await cPMDbContext.Teams.Where(x => x.ProjectId == id).ToListAsync();
            if(_Teams != null && _Teams.Count >= 1)
            {
                foreach(var t in _Teams)
                {
                    t.ProjectId = null;

                }
            }
            cPMDbContext.Projects.Remove(project);
            await cPMDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            var projects = await cPMDbContext.Projects.ToListAsync();
            return projects;
        }

        public async Task<Project> GetProjectById(int id)
        {
            var project = await cPMDbContext.Projects.Where(p => p.Id == id).Select(x => new Project
            {   Id= x.Id,
                Name = x.Name,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Budget = x.Budget,
                FRequirement = x.FRequirement,
                NFRequirement = x.NFRequirement,
                Technology = x.Technology,
                Teams = x.Teams.Select(t => new Team {
                    Id= t.Id,
                    Name = t.Name,
                    Employees= t.Employees
                }).ToList()
            }).FirstOrDefaultAsync();
            
            return project;
        }

        public async Task<List<Project>> GetProjectsUnderClient(int id)
        {
            /*var projects =  await cPMDbContext.Projects.Where(x => x.ClientId == id).ToListAsync();
            return projects;*/
            return null;
        }

        public async Task<List<Project>> GetProjectsWithNoClient()
        {
            /* var projects = await cPMDbContext.Projects.Where(x => x.ClientId == null).ToListAsync();
             return projects;*/
            return null;
        }

        public async Task<bool> UpdateProject(int id, Project project)
        {
            var proj = await cPMDbContext.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (proj == null) return false;

            proj.StartDate = project.StartDate;
            proj.EndDate = project.EndDate;
            proj.FRequirement = project.FRequirement;
            proj.NFRequirement = project.NFRequirement;
           /* proj.ClientId = project.ClientId;*/
            proj.Name = project.Name;
            proj.Technology = project.Technology;
            proj.Budget = project.Budget;

            cPMDbContext.Projects.Update(proj);
            try
            {
                await cPMDbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

       /* public async Task<Demo> ProjectName_WithClientName(int id)
        {

            var res = await cPMDbContext.Projects.Where(p => p.Id == id).Select(p =>  new Demo
            {
                ProjectName = p.Name,
                Client = p._Client

            }).FirstOrDefaultAsync();

            return res;
        }*/

      
    }

    
}
