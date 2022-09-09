using BasheerCinamanApi.Models;

namespace BasheerCinamanApi.UnitOfWork.Interfaces
{
    public interface ICompanies
    {
        public Task<string> AddCompanyByAdmin(ProductCompanyModel newProductCompany);
        public Task<bool> CheckIfCompanyExists(ProductCompanyModel newProductCompany);
        public Task<List<ProductCompanyModel>> GetListOfAllProductCompanies();
    }
}
