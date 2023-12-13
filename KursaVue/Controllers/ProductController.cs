using KursaVue.Model;
using KursaVue.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KursaVue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private DbWork dbWork =new DbWork();
        // GET: api/<ProductController>
        [HttpGet]
        public List<Product> Get()
        {
            var product = dbWork.GetAllProducts();
            return product;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public List<Category> Get(int idCategory)
        {
            var product = dbWork.GetProductsByCategory(idCategory);
            return product;
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
