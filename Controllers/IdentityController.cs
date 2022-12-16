using BasheerCinamanApi.UnitOfWork.Interfaces;
using BasheerCinamanApi.ViewModels;
using BasheerCinamanApi.ViewModels.IdentityViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasheerCinamanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {

        private readonly IIdentityProvidor _identity;

        public IdentityController(IIdentityProvidor identity)
        {
            _identity = identity;
        }


        [HttpPost("SignUp")]
        public async Task<IActionResult> signUp([FromBody]RegisterViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                var Response = await _identity.AddNewUserToTheSystem(newUser);
                return Ok(Response);
            }
            else
            {
                return Ok(new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "Model state is not valid"
                });
            }
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> userSignIn([FromBody]LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _identity.UserLogin(login));
            }
            else
            {
                return Ok(new LoginResponse()
                {
                    Success = false,
                    Errors = new List<string>()
                    {
                        "Model State is not valid"
                    }
                });
            }
        }


    }
}
