using Microsoft.AspNetCore.Mvc;
using P010Store.Entities;
using P010Store.Service.Abstract;

namespace P010Store.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IService<Contact> _service;

        public ContactsController(IService<Contact> service)
        {
            _service = service;
        }
        // GET: api/<ContactsController>
        [HttpGet]
        public async Task<IEnumerable<Contact>> GetAsync()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public async Task<Contact> GetAsync(int id)
        {
            return await _service.FindAsync(id);
        }

        // POST api/<ContactsController>
        [HttpPost]
        public async Task<Contact> PostAsync([FromBody] Contact value)
        {
            await _service.AddAsync(value);
            await _service.SaveChangesAsync();
            return value;
        }

        // PUT api/<ContactsController>/5"{id}"
        [HttpPut]
        public async Task<ActionResult> PutAsync([FromBody] Contact value)
        {
            _service.Update(value);
            await _service.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var kayit = _service.Find(id);
            if (kayit == null)
            {
                return BadRequest();
            }
            _service.Delete(kayit);
            await _service.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
