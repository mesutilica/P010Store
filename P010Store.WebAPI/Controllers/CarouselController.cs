using Microsoft.AspNetCore.Mvc;
using P010Store.Entities;
using P010Store.Service.Abstract;
using P010Store.Service.Concrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P010Store.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarouselController : ControllerBase
    {
        private readonly IService<Carousel> _service;

        public CarouselController(IService<Carousel> service)
        {
            _service = service;
        }
        // GET: api/<CarouselController>
        [HttpGet]
        public async Task<IEnumerable<Carousel>> GetAsync()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<CarouselController>/5
        [HttpGet("{id}")]
        public async Task<Carousel> GetAsync(int id)
        {
            return await _service.FindAsync(id);
        }

        // POST api/<CarouselController>
        [HttpPost]
        public async Task<Carousel> PostAsync([FromBody] Carousel value)
        {
            await _service.AddAsync(value);
            await _service.SaveChangesAsync();
            return value;
        }

        // PUT api/<CarouselController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] Carousel value)
        {
            _service.Update(value);
            await _service.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<CarouselController>/5
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
