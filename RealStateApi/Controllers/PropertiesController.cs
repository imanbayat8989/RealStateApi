using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealStateApi.Data;
using RealStateApi.Models;
using System.Security.Claims;

namespace RealStateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        ApiDbContext _dbContext =new ApiDbContext();
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]Property property)
        {
            if (property == null)
            {
                return NoContent();
            }
            else
            {
               var userEmail = User.Claims.FirstOrDefault(C => C.Type == ClaimTypes.Email)?.Value;
                var user = _dbContext.Users.FirstOrDefault(u => u.Email == userEmail);
                _dbContext.Users.First(u => u.Email == userEmail);
                if (User == null)return NotFound();
                property.IsTrending = false;
                property.UserId = user.Id;
                _dbContext.Properties.Add(property);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);

            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] Property property)
        {
            var propertyResult = _dbContext.Properties.FirstOrDefault(p => p.Id == id);
            if (propertyResult == null)
            {
                return NoContent();
            }
            else
            {
                var userEmail = User.Claims.FirstOrDefault(C => C.Type == ClaimTypes.Email)?.Value;
                var user = _dbContext.Users.FirstOrDefault(u => u.Email == userEmail);
                _dbContext.Users.First(u => u.Email == userEmail);
                if (User == null) return NotFound();
                propertyResult.Name = property.Name;
                propertyResult.Detail = property.Detail;
                propertyResult.Price = property.Price;
                propertyResult.Address = property.Address;
                property.IsTrending = false;
                property.UserId = user.Id;
                
                _dbContext.SaveChanges();
                return Ok("Record updated successfully!");

            }
        }
    }
}
