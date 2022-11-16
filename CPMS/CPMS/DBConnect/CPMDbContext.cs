using CPMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.DBConnect
{
    public class CPMDbContext:DbContext
    {
        public CPMDbContext(DbContextOptions<CPMDbContext> options):base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<Client_Project> Client_Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
