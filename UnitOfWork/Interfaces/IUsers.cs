using BasheerCinamanApi.Models;

namespace BasheerCinamanApi.UnitOfWork.Interfaces
{
    public interface IUsers
    {
        public Task<string> AddUserByAdminToTheSystem(UsersModel newUser);
        public Task<List<UsersModel>> GetAllUsers();
        public Task<UsersModel> GetUserById(int UserId);
        public Task<UsersModel> GetUserByName(string UserName);

    }
}
