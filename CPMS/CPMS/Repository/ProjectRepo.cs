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

        public async Task<bool> CreateProject(Project project)
        {   //when admin will create this project set client id to 0(default)3

            cPMDbContext.Projects.Add(new Project
            {
                Name = project.Name,
                FRequirement = project.FRequirement,
                NFRequirement = project.NFRequirement,
                Budget = project.Budget,
                StartDate = project.StartDate,
                EndDate =project.EndDate,
                Technology =project.Technology,
               /* ClientId = null*/
            }) ;

            try
            {
                await cPMDbContext.SaveChangesAsync();
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
            var project =  await cPMDbContext.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();
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
