using Microsoft.AspNetCore.Mvc;
using P010Store.Entities;
using P010Store.Service.Abstract;
using P010Store.Service.Concrete;

namespace P010Store.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _productService.GetAllProductsByCategoriesBrandsAsync();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<Product> GetAsync(int id)
        {
            return await _productService.GetProductByCategoriesBrandsAsync(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<Product> PostAsync([FromBody] Product value)
        {
            await _productService.AddAsync(value);
            await _productService.SaveChangesAsync();
            return value;
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Product value)
        {
            _productService.Update(value);
            await _productService.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var kayit = _productService.Find(id);
            if (kayit == null)
            {
                return BadRequest();
            }
            _productService.Delete(kayit);
            await _productService.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
