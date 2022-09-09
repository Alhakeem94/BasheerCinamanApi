using BasheerCinamanApi.Models;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasheerCinamanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCatagoryController : ControllerBase
    {

        private ICatagories _catagories;

        public ProductCatagoryController(ICatagories catagories)
        {
            _catagories = catagories;
        }



        [HttpPost("AddCatagoryByAdmin")]
        public  async Task<IActionResult> AddCatagory([FromForm]ProductCatagoryModel newProductCatagory)
        {

            try
            {
                var CheckIfCatagoryExists = await _catagories.CheckIfCatagoryExists(newProductCatagory);

                if (CheckIfCatagoryExists == true)
                {
                    return Ok("The Catagory Already Exits in the database");
                }
                else
                {
                    return Ok(await _catagories.AddCatagoryByAdmin(newProductCatagory));
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("GetAllCatagories")]
        public async Task<IActionResult> GetAllCatagories()
        {
            return Ok(await _catagories.GetListOfAllCatagories());
        }






    }
}
