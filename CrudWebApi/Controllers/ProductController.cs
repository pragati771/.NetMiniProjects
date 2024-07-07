using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FullStackPK.Entities;
using FullStackPK.Service;

namespace FullStackPK.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProductService _productService;
        public ProductController(IProductService ip) {
            _productService = ip;
        }
        [HttpGet]
        public IActionResult GetALL() {
            return Ok(_productService.GetAll());
        }


        [HttpPost]
        public IActionResult Insert(Product p) {
            return Ok(_productService.Insert(p));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            return Ok(_productService.GetById(id));
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,Product p) {
            return Ok(_productService.Update(id,p));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id) {
            return Ok(_productService.DeleteById(id));
        }

        
    }
}
