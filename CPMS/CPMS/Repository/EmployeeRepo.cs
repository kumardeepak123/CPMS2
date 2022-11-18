using CPMS.DBConnect;
using CPMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public readonly CPMDbContext _CPMDbContext;

        public EmployeeRepo(CPMDbContext  cPMDbContext)
        {
            _CPMDbContext =  cPMDbContext;
        }
        public async Task<bool> CreateEmployee(Employee employee)
        {
            var _Employee = new Employee
            {
                Name = employee.Name,
                Email = employee.Email,
                Password = employee.Password,
                Phone = employee.Phone,
                Designation = employee.Designation
            };

           
            try
            {
                _CPMDbContext.Employees.Add(_Employee);
                await _CPMDbContext.SaveChangesAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
             

            return true;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var _Employee =  await _CPMDbContext.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();

            try
            {
                _CPMDbContext.Employees.Remove(_Employee);
                await _CPMDbContext.SaveChangesAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _CPMDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _CPMDbContext.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();         
        }

        public async Task<List<Employee>> SearchEmployeeByDesignationWithNoTeam(string designation)
        {
            var _Employees = await _CPMDbContext.Employees.Where(x => x.Designation.ToLower().Contains(designation) && x.TeamId == null).ToListAsync();
            return _Employees;
        }

        public async Task<bool> UpdateEmployee(int id, Employee employee)
        {
            var _Employee = await _CPMDbContext.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_Employee == null) return false;

            _Employee.Name = employee.Name;
            _Employee.Password = employee.Password;
            _Employee.Email = employee.Email;
            _Employee.Designation = employee.Designation;
            _Employee.TeamId = employee.TeamId;

            try
            {
               await  _CPMDbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
    }
}
