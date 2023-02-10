using BasheerCinamanApi.Models;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using BasheerCinamanApi.ViewModels.ProductsCatagoriesViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        public  async Task<IActionResult> AddCatagory([FromForm]ProductCatagoryViewModel newProductCatagoryViewModel)
        {
            return Ok(await _catagories.AddCatagoryByAdmin(newProductCatagoryViewModel));
        }



        [HttpGet("GetAllCatagories")]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme,Roles = "DataEntry")]
        public async Task<IActionResult> GetAllCatagories()
        {
            return Ok(await _catagories.GetListOfAllCatagories());
        }






    }
}
