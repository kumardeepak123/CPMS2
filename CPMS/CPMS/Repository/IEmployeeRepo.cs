using CPMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.Repository
{
    public interface IEmployeeRepo
    {
        public Task<bool> CreateEmployee(Employee employee);
        public Task<Employee> GetEmployeeById(int id);
        public Task<List<Employee>> GetAllEmployees();

        public Task<bool> UpdateEmployee(int id, Employee employee);
        public Task<bool> DeleteEmployee(int id);
        public Task<List<Employee>> SearchEmployeeByDesignationWithNoTeam(string designation);
    }
}
