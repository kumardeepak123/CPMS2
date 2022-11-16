using CPMS.Models;
using CPMS.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.Controllers
{
   /* [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepo _IClientRepo;
        private readonly IWebHostEnvironment _hostEnvironment;
        private IConfiguration _config;

        public ClientController(IClientRepo iClientRepo, IWebHostEnvironment hostEnvironment, IConfiguration config)
        {
            _IClientRepo = iClientRepo;
            this._hostEnvironment = hostEnvironment;
            _config = config;
        }

        

        [HttpPost("create")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateClient([FromForm] Client client) 
        {
            string FileExtension = Path.GetExtension(client.AgreementPaperFile.FileName);
            if(FileExtension != ".pdf")
            {
                return BadRequest(new { message = "Please select pdf files" });
            }
            client.ProfileImageName = await SaveFile(client.ProfileImageFile);
            client.AgreementPaperName = await SaveFile(client.AgreementPaperFile);

            var res = await _IClientRepo.AddClient(client);
            if (res)
            {
                return Ok(new { message = "Client created successfully" });
            }

            return StatusCode(501);
        }
        
        [HttpGet]
        [Route("details/{id}")]
        [Authorize(Roles = "Admin,Client")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _IClientRepo.getClientById(id);
            if(client == null)
            {
                return NotFound(new { message="User not found with id "+id});
            }
            client.ProfileImageSrc = String.Format("{0}://{1}{2}/UploadFiles/{3}", Request.Scheme, Request.Host, Request.PathBase, client.ProfileImageName);
            client.AgreementPaperSrc = String.Format("{0}://{1}{2}/UploadFiles/{3}", Request.Scheme, Request.Host, Request.PathBase, client.AgreementPaperName);
            return Ok(client);

        }

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public  async Task<ActionResult<List<Client>>> GetAllClients(string sortBy, string orderBy, string searchByName)
        {
            var clients = await _IClientRepo.getAllClients(sortBy, orderBy, searchByName);

            var res = clients.Where(x=> x.Role == "Client").Select(client => new 
            {   Id = client.Id,
                Name =client.Name,
                Email = client.Email,
                Phone = client.Phone,
                Organization = client.Organization,
                ProfileImageName = client.ProfileImageName,
                AgreementPaperName = client.AgreementPaperName,
                ProfileImageSrc = String.Format("{0}://{1}{2}/UploadFiles/{3}", Request.Scheme, Request.Host, Request.PathBase, client.ProfileImageName),
                AgreementPaperSrc = String.Format("{0}://{1}{2}/UploadFiles/{3}", Request.Scheme, Request.Host, Request.PathBase, client.AgreementPaperName),
                Role = client.Role
            }).ToList();

            return Ok(res);
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(string email, string password)
        {
            var user = await Authenticate(email, password);
            if(user != null)
            {
                var token = Generate(user);
                return Ok(new
                {
                    message = "SignIn successfull",
                    UserId = user.Id,   
                    Role = user.Role,
                    Token = token
                });
            }

            return NotFound(new { message = "User Not Found" });
        }

        [NonAction]
        private string Generate(Client user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [NonAction]
        private async  Task<Client> Authenticate(string email, string password)
        {
            var client = await _IClientRepo.SignIn(email, password);
            return client;
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles ="Admin,Client")]
        public async Task<IActionResult> UpdateClient(int id,[FromForm] Client client)
        {
            if (client.ProfileImageFile != null)
            {
                DeleteFile(client.ProfileImageName);
                client.ProfileImageName = await SaveFile(client.ProfileImageFile);
            }

            if (client.AgreementPaperFile != null)
            {
                DeleteFile(client.AgreementPaperName);
                client.AgreementPaperName = await SaveFile(client.AgreementPaperFile);
            }
            var res =  await _IClientRepo.UpdateClient(id, client);
            if (!res)
            {
                return Ok(new { message = "Failed to update" });
            }

            return Ok(new { message = "Update successfull" });
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client =  await _IClientRepo.DeleteClient(id);
            if (client == null)
            {
                return NotFound();
            }
            DeleteFile(client.AgreementPaperName);
            DeleteFile(client.ProfileImageName);

            return Ok(new { message = "Deleted successfully" });
           
        }


        [NonAction]
        public async Task<string> SaveFile(IFormFile file)
        {
            string fileName = new String(Path.GetFileNameWithoutExtension(file.FileName).Take(10).ToArray()).Replace(' ', '-');
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_hostEnvironment.ContentRootPath, "UploadFiles", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName; 
        }

        [NonAction]
        public void DeleteFile(string fileName) 
        {
            var filePath = Path.Combine(_hostEnvironment.ContentRootPath, "UploadFiles", fileName);
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }

        //---
       
    }*/

}
