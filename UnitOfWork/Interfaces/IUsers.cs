using BasheerCinamanApi.Models;
using Microsoft.AspNetCore.Identity;

namespace BasheerCinamanApi.UnitOfWork.Interfaces
{
    public interface IUsers
    {
        public Task<string> AddUserByAdminToTheSystem(UsersModel newUser);
        public Task<List<IdentityUser>> GetAllUsers();
        public Task<IdentityUser> GetUserById(string UserId);
        public Task<IdentityUser> GetUserByName(string UserName);

    }
}
