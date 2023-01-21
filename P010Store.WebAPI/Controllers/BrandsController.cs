using Microsoft.AspNetCore.Mvc;
using P010Store.Entities;
using P010Store.Service.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P010Store.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IService<Brand> _service;

        public BrandsController(IService<Brand> service)
        {
            _service = service;
        }

        // GET: api/<BrandsController>
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return _service.GetAll();
        }

        // GET api/<BrandsController>/5
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return _service.Find(id);
        }

        // POST api/<BrandsController>
        [HttpPost]
        public Brand Post([FromBody] Brand value)
        {
            _service.Add(value);
            _service.SaveChanges();
            return value;
        }

        // PUT api/<BrandsController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Brand value)
        {
            _service.Update(value);
            _service.SaveChanges();
            return NoContent();
        }

        // DELETE api/<BrandsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var kayit = _service.Find(id);
            if (kayit == null)
            {
                return BadRequest();
            }
            _service.Delete(kayit);
            _service.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
