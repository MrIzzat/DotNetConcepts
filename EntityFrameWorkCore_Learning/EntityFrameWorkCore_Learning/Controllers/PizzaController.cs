using ContosoPizza.Entities;
using ContosoPizza.Entities.DTO;
using EntityFrameWorkCore_Learning.DataAccess;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkCore_Learning.Controllers
{
    [Route("api/Pizzas")]
    [ApiController]
    public class PizzaController : ControllerBase
    {

        private readonly ApplicationDbContext _db;

        public PizzaController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("Products/GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getAllProducts()
        {
            return Ok(_db.Products.ToList());
        }

        [HttpGet("Products/GetGreaterThan10")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getProductGreaterThan10()
        {

            List<Product> Products = _db.Products.Where(p => p.Price > 9.99M).OrderBy(p => p.Name).ToList();
            //Can also  use this: This is called link syntax
            /*List<Product> Products = from product in _db.Products
                                     where product.Price > 9.99M
                                     orderby product.Name
                                     select product;*/
           

            return Ok(Products);
        }

        [HttpPatch("Products/UpdatePrice/{Id:int},{Price:decimal}", Name = "Update Product Price ")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdateProductPrice(int Id,decimal Price)
        {
            Console.WriteLine("TESTTEST");
            var Product = _db.Products.Where(p => p.Id == 1).FirstOrDefault();

            if(Product is Product)
            {
                Product.Price = Price;
            }
            else
            {
                return BadRequest();
            }

            _db.SaveChanges();

            return NoContent();

        }




    }
}
