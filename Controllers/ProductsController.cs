using BasheerCinamanApi.Models;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using BasheerCinamanApi.ViewModels.ProductsViewModels;
using BasheerCinamanApi.ViewModels.Responses.CategoriesResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasheerCinamanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProducts _products;

        public ProductsController(IProducts products)
        {
            _products = products;
        }



        [HttpPost("AddProductByAdmin")]
        public async Task<IActionResult> AddProduct([FromForm]AddProductViewModel newProduct)
        {
            try
            {
                var CheckIfExists = await _products.CheckIfProductExist(newProduct);

                if (CheckIfExists is false)
                {
                    return Ok(await _products.AddProductByAdmin(newProduct));
                }
                else
                {
                    return Ok("The Product Already Exists in the database");
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }       
        }



        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _products.GetAllProducts());
        }


        [HttpGet("GetProductsByCatagoryId")]
        public async Task<IActionResult> GetProductsByCatagory(int CatagoryId)
        {
            return Ok(await _products.GetAllProductsByCatagoryId(CatagoryId));
        }

        [HttpGet("GetProductsByName")]
        public async Task<IActionResult> GetProductsByProductName(string ProductName)
        {
            return Ok(await _products.GetAllProductsByName(ProductName));
        }


        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductWithId(int ProductId)
        {
            return Ok(await _products.GetProductById(ProductId));
        }

        [HttpPut("EditProduct")]
        public async Task<IActionResult> editProduct([FromForm] UpdateProductViewModel updateProductViewModel)
        {
            if (ModelState.IsValid)
            {
                var ResponseFromRepo = await _products.EditProductById(updateProductViewModel);
                return Ok(ResponseFromRepo);
            }
            else
            {
                return Ok(new AddCategoryResponse()
                {
                    IsSuccess =false,
                    Message = "Invalid Data, please enter valid data and send info"
                });
            }
        }

    }
}
