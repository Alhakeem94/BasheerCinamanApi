using BasheerCinamanApi.Models;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasheerCinamanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IUsers _users;

        public UsersController(IUsers users)
        {
            _users = users;
        }




        [HttpPost("AddUsersToTheSystem")]
        public async Task<IActionResult> AddUser([FromForm]UsersModel newUserModel)
        {
            return Ok(await _users.AddUserByAdminToTheSystem(newUserModel));
        }




    }
}
