using BasheerCinamanApi.Models;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BasheerCinamanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCompanyController : ControllerBase
    {
        private ICompanies _Companies;

        public ProductCompanyController(ICompanies companies)
        {
            _Companies = companies;
        }



        [HttpPost("AddCompany")]
        public async Task<IActionResult> AddCompanyByAdmin([FromForm]ProductCompanyModel newCompany)
        {
            try
            {
                var CheckIfExistsResult = await _Companies.CheckIfCompanyExists(newCompany);
                if (CheckIfExistsResult == true)
                {
                    return Ok("The Company Already exists in the database");
                }
                else
                {
                    var Result = await _Companies.AddCompanyByAdmin(newCompany);
                    return Ok(Result);
                }
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("GetAllCompanies")]
        public async Task<IActionResult> GetCompanies()
        {
            return Ok(await _Companies.GetListOfAllProductCompanies());
        }



    }
}
