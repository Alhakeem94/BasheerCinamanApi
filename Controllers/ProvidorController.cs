using BasheerCinamanApi.Models;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasheerCinamanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidorController : ControllerBase
    {

        private IProvidor _Providor;

        public ProvidorController(IProvidor providor)
        {
            _Providor = providor;
        }




        [HttpPost("AddProvidor")]
        public async Task<IActionResult> AddProvidorByAdmin([FromForm]ProvidorModel newProvidor)
        {
            return Ok(await _Providor.AddProvidor(newProvidor));
        }


        [HttpGet("GetAllProvidors")]
        public async Task<IActionResult> GetProvidors()
        {
            return Ok(await _Providor.GetAllProvidors());
        }


        [HttpGet("GetProvidorById")]
        public async Task<IActionResult> GetProvidorUsingId(int ProvidorId)
        {
            return Ok(await _Providor.GetProvidorById(ProvidorId));
        }


        [HttpGet("CheckIfProvidorExists")]
        public async Task<IActionResult> CheckIfExists(string ProvidorName)
        {
            return Ok(await _Providor.CheckIfProvidorExistsInDataBase(ProvidorName));
        }


    }
}
