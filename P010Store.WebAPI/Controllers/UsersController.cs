using Microsoft.AspNetCore.Mvc;
using P010Store.Entities;
using P010Store.Service.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P010Store.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IService<User> _service;

        public UsersController(IService<User> service)
        {
            _service = service;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<User> GetAsync(int id)
        {
            return await _service.FindAsync(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<User> PostAsync([FromBody] User value)
        {
            await _service.AddAsync(value);
            await _service.SaveChangesAsync();
            return value;
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] User value)
        {
            _service.Update(value);
            await _service.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var kayit = _service.Find(id);
            if (kayit == null) 
                return BadRequest();
            _service.Delete(kayit);
            await _service.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
