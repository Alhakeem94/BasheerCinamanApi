using BasheerCinamanApi.Models;
using BasheerCinamanApi.ViewModels.ProductsCatagoriesViewModels;
using BasheerCinamanApi.ViewModels.Responses.CategoriesResponses;

namespace BasheerCinamanApi.UnitOfWork.Interfaces
{
    public interface ICatagories
    {
        public Task<bool> CheckIfCatagoryExists(string CatagoryName);
        public Task<AddCategoryResponse> AddCatagoryByAdmin(ProductCatagoryViewModel newProductCatagoryViewModel);
        public Task<List<ProductCatagoryModel>> GetListOfAllCatagories();
    }
}
