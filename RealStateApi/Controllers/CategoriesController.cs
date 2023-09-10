using Microsoft.AspNetCore.Mvc;
using RealStateApi.Data;
using RealStateApi.Models;

namespace RealStateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();
        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get()
        {
          return Ok(_dbContext.Categories);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category =  _dbContext.Categories.FirstOrDefault(x => x.Id == id);
            return Ok (category);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category categoryobj)
        {
           var category = _dbContext.Categories.Find(id);
            category.Name = categoryobj.Name;
            category.ImageUrl = categoryobj.ImageUrl;
            _dbContext.SaveChanges();
            return Ok("Record updated successfully");
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           var category = _dbContext.Categories.Find(id);
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return Ok("Record Deleted");
        }
    }
}
