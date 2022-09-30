using BasheerCinamanApi.Models;
using BasheerCinamanApi.ViewModels.ProductsViewModels;

namespace BasheerCinamanApi.UnitOfWork.Interfaces
{                    // HR
    public interface IProducts
    {
        public Task<string> AddProductByAdmin(AddProductViewModel newProductViewModel);
        public Task<bool> CheckIfProductExist(AddProductViewModel newProduct);
        public Task<List<ProductModel>> GetAllProducts();
        public Task<List<ProductModel>> GetAllProductsByCatagoryId(int CatagoryId);
        public Task<List<ProductModel>> GetAllProductsByName(string ProductName);
        public Task<ProductModel> GetProductById(int ProductId);
        public Task<ProductModel> GetProductsUnder10Amount(int ProductId);


    }
}
