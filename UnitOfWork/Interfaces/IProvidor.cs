using BasheerCinamanApi.Models;

namespace BasheerCinamanApi.UnitOfWork.Interfaces
{
    public interface IProvidor
    {
        public Task<string> AddProvidor(ProvidorModel newProvidor);
        public Task<bool> CheckIfProvidorExistsInDataBase(string ProvidorName);
        public Task<List<ProvidorModel>> GetAllProvidors();
        public Task<ProvidorModel> GetProvidorById(int ProvidorId);
    }
}
