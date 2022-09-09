using BasheerCinamanApi.Models;

namespace BasheerCinamanApi.UnitOfWork.Interfaces
{
    public interface ICatagories
    {
        public Task<bool> CheckIfCatagoryExists(ProductCatagoryModel newProductCatagory);
        public Task<string> AddCatagoryByAdmin(ProductCatagoryModel newProductCatagory);
        public Task<List<ProductCatagoryModel>> GetListOfAllCatagories();
    }
}
