using CPMS.DBConnect;
using CPMS.Models;
using CPMS.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS_test
{
   /* public class ProjectRepoTest
    {
        private static DbContextOptions<CPMDbContext> dbContextOptions = new DbContextOptionsBuilder<CPMDbContext>()
               .UseInMemoryDatabase(databaseName: "CPMSProjectTest")
               .Options;

        CPMDbContext context;
        ProjectRepo _ProjectRepo;

        [OneTimeSetUp]
        public void Setup()
        {

            context = new CPMDbContext(dbContextOptions);
            context.Database.EnsureCreated();
            SeedDatabase();
            _ProjectRepo = new ProjectRepo(context);
        }

        [Test, Order(1)]
        public async Task CreateProject_Test()
        {
            var _Project = new Project
            {
                Id = 2,
                Name = "Employee Management System",
                StartDate = System.DateTime.Today.AddDays(2),
                EndDate = System.DateTime.Today.AddDays(10),
                Technology = "MEAN",
                FRequirement = "F.R.2",
                NFRequirement = "N.F.R.2",
                Budget = 5000,
                ClientId = null
            };
            var res = await _ProjectRepo.CreateProject(_Project);
            Assert.That(res, Is.True);
        }

        [Test, Order(2)]
        public async Task DeleteProject_WithResponse_Test()
        {

            var res = await _ProjectRepo.DeleteProject(3);
            Assert.That(res, Is.True);
        }
        [Test, Order(3)]
        public async Task DeleteProject_WithOutResponse_Test()
        {

            var res = await _ProjectRepo.DeleteProject(456);
            Assert.That(res, Is.False);
        }
        [Test, Order(4)]
        public async Task GetAllProjects_WithResponse_Test()
        {

            var res = await _ProjectRepo.GetAllProjects();
            Assert.That(res, Is.Not.Empty);
            Assert.That(res.Count, Is.EqualTo(4));
        }
        [Test, Order(5)]
        public async Task GetProjectById_WithResponse_Test()
        {

            var res = await _ProjectRepo.GetProjectById(3);
            Assert.That(res, Is.Not.Null);
            Assert.That(res.Name, Is.EqualTo("Parking Managemet System"));
            Assert.That(res.Budget, Is.EqualTo(2000));
        }
        [Test, Order(6)]
        public async Task GetProjectsUnderClient_Test()
        {

            var res = await _ProjectRepo.GetProjectsUnderClient(3);
            Assert.That(res, Is.Not.Null);
            Assert.That(res.Count, Is.EqualTo(2));
            
        }
        [Test, Order(7)]
        public async Task GetProjectsWithNoClient_Test()
        {

            var res = await _ProjectRepo.GetProjectsWithNoClient();
            Assert.That(res, Is.Not.Empty);
            Assert.That(res.First().Name, Is.EqualTo("Airline Management System"));

        }
        [Test, Order(8)]
        public async Task UpdateProjects_WithResponse_Test()
        {
            var _Project = new Project
            {
                Id = 2,
                Name = "Employee Management",
                StartDate = System.DateTime.Today.AddDays(2),
                EndDate = System.DateTime.Today.AddDays(10),
                Technology = "MEAN",
                FRequirement = "F.R.2",
                NFRequirement = "N.F.R.2",
                Budget = 5000,
                ClientId = null
            };
            var res = await _ProjectRepo.UpdateProject(2, _Project);
            Assert.That(res, Is.True);
           

        }
        [Test, Order(9)]
        public async Task UpdateProjects_WithoutResponse_Test()
        {
            var _Project = new Project
            {
                Id = 2,
                Name = "Employee Management",
                StartDate = System.DateTime.Today.AddDays(2),
                EndDate = System.DateTime.Today.AddDays(10),
                Technology = "MEAN",
                FRequirement = "F.R.2",
                NFRequirement = "N.F.R.2",
                Budget = 5000,
                ClientId = null
            };
            var res = await _ProjectRepo.UpdateProject(245, _Project);
            Assert.That(res, Is.False);


        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            context.Database.EnsureDeleted();
        }

        private void SeedDatabase()
        {
            var _Clients = new List<Client>()
            {
                new Client
                {
                    Id = 1,
                    Name ="Deepak",
                    Email="deepak@gmail.com",
                    Password="deepak123",
                    Phone="9668855719",
                    Organization="hexaware",
                    ProfileImageName="profile1.png",
                    AgreementPaperName="agree1.pdf",
                    Role="Client"
                },
                 new Client
                {
                    Id = 2,
                    Name ="Alisha",
                    Email="alisha@gmail.com",
                    Password="alisha123",
                    Phone="5268956235",
                    Organization="hexaware",
                    ProfileImageName="profile2.png",
                    AgreementPaperName="agree2.pdf",
                    Role="Admin"
                },
                  new Client
                {
                    Id = 3,
                    Name ="Aman",
                    Email="aman@gmail.com",
                    Password="aman123",
                    Phone="5623895623",
                    Organization="hexaware",
                    ProfileImageName="profile3.png",
                    AgreementPaperName="agree3.pdf",
                    Role="Client"
                }
            };

            var _Projects = new List<Project>()
            {
                new Project
                {
                    Id =1,
                    Name="Library Management System",
                    StartDate= System.DateTime.Today,
                    EndDate = System.DateTime.Today.AddDays(2),
                    Technology= "MERN",
                    FRequirement="F.R.1",
                    NFRequirement="N.F.R.1",
                    Budget= 1000,
                    ClientId= 3
                },
                 new Project
                {
                    Id =2,
                    Name="Employee Management System",
                    StartDate= System.DateTime.Today.AddDays(2),
                    EndDate = System.DateTime.Today.AddDays(10),
                    Technology= "MEAN",
                    FRequirement="F.R.2",
                    NFRequirement="N.F.R.2",
                    Budget= 5000,
                    ClientId= 3
                },
                  new Project
                {
                    Id =3,
                    Name="Parking Managemet System",
                    StartDate= System.DateTime.Today.AddDays(3),
                    EndDate = System.DateTime.Today.AddDays(10),
                    Technology= "LAMP",
                    FRequirement="F.R.3",
                    NFRequirement="N.F.R.3",
                    Budget= 2000,
                    ClientId= 1
                },
                 new Project
                {
                    Id =4,
                    Name="Airline Management System",
                    StartDate= System.DateTime.Today.AddDays(2),
                    EndDate = System.DateTime.Today.AddDays(9),
                    Technology= "MERN",
                    FRequirement="F.R.4",
                    NFRequirement="N.F.R.4",
                    Budget= 5000,
                    ClientId= null
                }

            };

            context.Clients.AddRange(_Clients);
            context.Projects.AddRange(_Projects);
            context.SaveChanges();

        }
    }*/
}
