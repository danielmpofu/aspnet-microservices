using Catalog.API.Entities;
using Catalog.API.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    //come back here and do some defensive codding here -if you ever get the time
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET: api/<CatalogController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> LIstProducts()
        {
            var products = await productRepository.GetProducts();
            return Ok(products);
        }

        // GET api/<CatalogController>/product_id_then_comes_here
        [HttpGet("id/{id}")]
        public async Task<ActionResult<Product>> GetById(string id)
        {
            var product = await productRepository.GetProductById(id);
            return product != null ? Ok(product) : NotFound();
        }


        // GET api/<CatalogController>/product_name_then_comes_here
        [HttpGet("name/{name}")]
        public async Task<ActionResult<Product>> GetByName(string name)
        {
            var product = await productRepository.GetProductsByName(name);
            return product != null ? Ok(product) : NotFound();
        }

        [HttpGet("category/{categoryName}")]
        public async Task<ActionResult<Product>> GetByCategory(string categoryName)
        {
            var product = await productRepository.GetProductsByCategory(categoryName);
            return product != null ? Ok(product) : NotFound();
        }

        // POST api/<CatalogController>
        [HttpPost]
        public async Task<ActionResult> SaveProduct([FromBody] Product product)
        {
            await productRepository.CreateProduct(product);
            return NoContent();
        }

        // PUT api/<CatalogController>/
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product)
        {
            await productRepository.UpdateProduct(product);
            return NoContent();
        }

        // DELETE api/<CatalogController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var product = productRepository.GetProductById(id);
            if (product == null) return NotFound("Maybe this product has already been deleted");
            await productRepository.DeleteProduct(id);
            return NoContent();
        }
    }
}
