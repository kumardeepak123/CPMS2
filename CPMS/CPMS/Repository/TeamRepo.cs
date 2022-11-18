using CPMS.DBConnect;
using CPMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.Repository
{
    public class TeamRepo : ITeamRepo
    {
        public readonly CPMDbContext _CPMDbContext;

        public TeamRepo(CPMDbContext cPMDbContext)
        {
            _CPMDbContext = cPMDbContext;
        }

        public async Task<bool> CreateTeam(Team Team, int[] EmployeeIds)
        {
            var _Team = new Team
            {
                Name = Team.Name
            };

            try
            {
                _CPMDbContext.Teams.Add(_Team);
                await _CPMDbContext.SaveChangesAsync();

                foreach (var eid in EmployeeIds)
                {
                    var _Employee = await _CPMDbContext.Employees.Where(x => x.Id == eid).FirstOrDefaultAsync();
                    _Employee.TeamId = _Team.Id;
                    await _CPMDbContext.SaveChangesAsync();

                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;

        }

        public async Task<bool> DeleteTeam(int id)
        {
            var _Team = await _CPMDbContext.Teams.Where(t => t.Id == id).FirstOrDefaultAsync();
            if (_Team == null) return false;

            _CPMDbContext.Teams.Remove(_Team);
            var _Employees = await _CPMDbContext.Employees.Where(e => e.TeamId == id).ToListAsync();
            if(_Employees!=null && _Employees.Count >= 1)
            {
                foreach(var e in _Employees)
                {
                    e.TeamId = null;
                }
            }
            await _CPMDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Team> GetTeamById(int id)
        {
            var _Team = await  _CPMDbContext.Teams.Select(x => new Team
            {   
                Id = x.Id,
                Name = x.Name,
                Project = x.Project,
                Employees = x.Employees
            }).Where(p => p.Id == id).FirstOrDefaultAsync();

            return _Team;
        }
    }
}
