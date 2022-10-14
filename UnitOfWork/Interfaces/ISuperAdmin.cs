using Microsoft.AspNetCore.SignalR;

namespace BasheerCinamanApi.UnitOfWork.Interfaces
{
    public interface ISuperAdmin
    {
        public Task<string> AddUserToSuperAdminRole(string UserId);
        public Task<string> AddUserToAdminRole(string UserId);
        public Task<string> AddUserToDevRole(string UserId);
        public Task<string> AddUserToDataEntryRole(string UserId);
        public Task<string> UpdateToAdminRole(string UserId);

    }
}
