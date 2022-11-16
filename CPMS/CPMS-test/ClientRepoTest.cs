using CPMS.DBConnect;
using CPMS.Models;
using CPMS.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS_test
{
    /*public class ClientRepoTest
    {   
        private static DbContextOptions<CPMDbContext> dbContextOptions = new DbContextOptionsBuilder<CPMDbContext>()
               .UseInMemoryDatabase(databaseName: "CPMSTest")
               .Options;

        CPMDbContext context;
        ClientRepo _ClientRepo;

        [OneTimeSetUp]
        public void Setup()
        {  
           
            context = new CPMDbContext(dbContextOptions);
            context.Database.EnsureCreated();
            SeedDatabase();
            _ClientRepo = new ClientRepo(context);
        }

        [Test, Order(1)]
        public async Task GetAllClients_WithNoFilter_Test()
        {
            var res =  await _ClientRepo.getAllClients("","","");
            Assert.That(res.Count, Is.EqualTo(3));
        }

        [Test, Order(2)]
        public async Task GetAllClients_WithSearchBy_Test()
        {
            var res = await _ClientRepo.getAllClients("", "", "Ali");
            Assert.That(res.First().Name, Is.EqualTo("Alisha"));
        }

        [Test, Order(3)]
        public async Task GetClientById_WithResponse_Test()
        {
            var res = await _ClientRepo.getClientById(3);
            Assert.That(res, Is.Not.Null);
            Assert.That(res.Name, Is.EqualTo("Aman"));
            
        }
        [Test, Order(4)]
        public async Task GetClientById_WithoutResponse_Test()
        {
            var res = await _ClientRepo.getClientById(899);
            Assert.That(res, Is.Null);
            

        }

        [Test, Order(5)]
        public async Task AddClient_Test()
        {
            var client = new Client
            {

                Name = "John",
                Email = "john@gmail.com",
                Password = "john123",
                Phone = "9652658652",
                Organization = "hexaware",
                ProfileImageName = "profile1.png",
                AgreementPaperName = "agree1.pdf",
                Role = "Client"
            };
            var res = await _ClientRepo.AddClient(client);
            Assert.That(res, Is.True);

        }

        [Test, Order(6)]
        public async Task DeleteClient_WithResponse_Test()
        {
            var res = await _ClientRepo.DeleteClient(3);
            Assert.That(res, Is.Not.Null);
            Assert.That(res.Email, Is.EqualTo("aman@gmail.com"));


        }
        [Test, Order(7)]
        public async Task DeleteClient_WithoutResponse_Test()
        {
            var res = await _ClientRepo.DeleteClient(388);
            Assert.That(res, Is.Null);

        }

        [Test, Order(8)]
        public async Task UpdateClient_WithResponse_Test()
        {
            var client = new Client
            {
                Id = 1,
                Name = "Deepak Kumar Sahoo",
                Email = "deepak@gmail.com",
                Password = "deepak123",
                Phone = "9668855719",
                Organization = "hexaware",
                ProfileImageName = "profile1.png",
                AgreementPaperName = "agree1.pdf",
                Role = "Client"
            };
            var res = await _ClientRepo.UpdateClient(1, client);
            Assert.That(res, Is.True);

        }

        [Test, Order(9)]
        public async Task UpdateClient_WithoutResponse_Test()
        {
            var client = new Client
            {
                Id = 1,
                Name = "Deepak Kumar Sahoo",
                Email = "deepak@gmail.com",
                Password = "deepak123",
                Phone = "9668855719",
                Organization = "hexaware",
                ProfileImageName = "profile1.png",
                AgreementPaperName = "agree1.pdf",
                Role = "Client"
            };
            var res = await _ClientRepo.UpdateClient(856, client);
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

            };

            context.Clients.AddRange(_Clients);
            context.Projects.AddRange(_Projects);
            context.SaveChanges();

        }
    }*/
}