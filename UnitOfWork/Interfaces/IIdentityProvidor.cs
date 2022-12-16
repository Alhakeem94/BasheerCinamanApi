using BasheerCinamanApi.ViewModels;
using BasheerCinamanApi.ViewModels.IdentityViewModel;
using Microsoft.AspNetCore.Identity;

namespace BasheerCinamanApi.UnitOfWork.Interfaces
{
    public interface IIdentityProvidor
    {
        public Task<GeneralResponse> AddNewUserToTheSystem(RegisterViewModel NewUser);
        public Task<LoginResponse> UserLogin(LoginViewModel UserLogIn);

        //public Task<IdentityUser> GetUserByJwtToken(string jwtToken);

    }
}
