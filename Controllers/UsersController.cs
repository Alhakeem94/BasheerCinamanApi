using BasheerCinamanApi.Models;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BasheerCinamanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IUsers _users;
        private ISuperAdmin _SuperAdmin;

        public UsersController(IUsers users, ISuperAdmin superAdmin)
        {
            _users = users;
            _SuperAdmin = superAdmin;
        }




        [HttpPost("AddUsersToTheSystem")]
        public async Task<IActionResult> AddUser([FromForm]UsersModel newUserModel)
        {
            return Ok(await _users.AddUserByAdminToTheSystem(newUserModel));
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsersFromDataBase()
        {
            return Ok(await _users.GetAllUsers());
        }



        [HttpPost("AddToSuperAdminRole")]
        public async Task<IActionResult> AddToSuperAdminRoleToDataBase([FromForm]string UserId)
        {
           return Ok( await _SuperAdmin.AddUserToSuperAdminRole(UserId));
        }

        [HttpPost("AddToAdminRole")]
        public async Task<IActionResult> AddToAdminRoleToDataBase([FromForm] string UserId)
        {
            return Ok(await _SuperAdmin.AddUserToAdminRole(UserId));
        }

        [HttpPost("AddToDevRole")]
        public async Task<IActionResult> AddToDevRoleToDataBase([FromForm] string UserId)
        {
            return Ok(await _SuperAdmin.AddUserToDevRole(UserId));
        }

        [HttpPost("AddToDataEntryRole")]
        public async Task<IActionResult> AddToDataEntryRoleToDataBase([FromForm] string UserId)
        {
            return Ok(await _SuperAdmin.AddUserToDataEntryRole(UserId));
        }



        [HttpPut("UpdateToAdminRole")]
        public async Task<IActionResult> UpdateToAdminRoleInDataBase([FromForm]string UserId)
        {
            return Ok(await _SuperAdmin.UpdateToAdminRole(UserId));
        }


    }

}
