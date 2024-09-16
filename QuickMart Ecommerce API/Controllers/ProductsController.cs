using Microsoft.AspNetCore.Mvc;

namespace QuickMart_Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string GetProducts()
        {
            return "This is will be a list of Products!";
        }

        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return "This is will be a spacified Products!";
        }
    }

}
