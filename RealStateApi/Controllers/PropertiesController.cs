﻿using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("PropertList")]
        [Authorize]
        public IActionResult GetProperties(int categoryId)
        {
           var propertiesResult = _dbContext.Properties.Where(c => c.CategoryId == categoryId);
            if (propertiesResult == null)
            {
                return NotFound();
            }
            return Ok(propertiesResult);
        }

        [HttpGet("PropertyDetail")]
        [Authorize]
        public IActionResult GetPropertiesDetail(int id)
        {
            var propertiesResult = _dbContext.Properties.FirstOrDefault(p => p.Id == id);
            if (propertiesResult == null)
            {
                return NotFound();
            }
            return Ok(propertiesResult);
        }

        [HttpGet("TrendingProperties")]
        [Authorize]
        public IActionResult GetTrendingProperties()
        {
            var propertiesResult = _dbContext.Properties.Where(c => c.IsTrending == true);
            if (propertiesResult == null)
            {
                return NotFound();
            }
            return Ok(propertiesResult);
        }

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
                return NotFound();
            }
            else
            {
                var userEmail = User.Claims.FirstOrDefault(C => C.Type == ClaimTypes.Email)?.Value;
                var user = _dbContext.Users.FirstOrDefault(u => u.Email == userEmail);
                _dbContext.Users.First(u => u.Email == userEmail);
                if (User == null) return NotFound();
                if (propertyResult.UserId == user.Id)
                {
                    propertyResult.Name = property.Name;
                    propertyResult.Detail = property.Detail;
                    propertyResult.Price = property.Price;
                    propertyResult.Address = property.Address;
                    property.IsTrending = false;
                    property.UserId = user.Id;

                    _dbContext.SaveChanges();
                    return Ok("Record updated successfully!");
                }
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var propertyResult = _dbContext.Properties.FirstOrDefault(p => p.Id == id);
            if (propertyResult == null)
            {
                return NotFound();
            }
            else
            {
                var userEmail = User.Claims.FirstOrDefault(C => C.Type == ClaimTypes.Email)?.Value;
                var user = _dbContext.Users.FirstOrDefault(u => u.Email == userEmail);
                _dbContext.Users.First(u => u.Email == userEmail);
                if (User == null) return NotFound();
                if (propertyResult.UserId == user.Id)
                {
                    _dbContext.Properties.Remove(propertyResult);
                    _dbContext.SaveChanges();
                    return Ok("Record Deleted successfully!");
                }
                return BadRequest();
            }
        }
    }
}
