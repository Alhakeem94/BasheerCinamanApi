using BasheerCinamanApi.Models;
using BasheerCinamanApi.ViewModels.ProductsCatagoriesViewModels;

namespace BasheerCinamanApi.UnitOfWork.Interfaces
{
    public interface ICatagories
    {
        public Task<bool> CheckIfCatagoryExists(string CatagoryName);
        public Task<string> AddCatagoryByAdmin(ProductCatagoryViewModel newProductCatagoryViewModel);
        public Task<List<ProductCatagoryModel>> GetListOfAllCatagories();
    }
}
