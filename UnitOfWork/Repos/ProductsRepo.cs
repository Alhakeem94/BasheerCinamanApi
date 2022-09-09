using BasheerCinamanApi.Data;
using BasheerCinamanApi.Models;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasheerCinamanApi.UnitOfWork.Repos
{
    public class ProductsRepo : IProducts
    {

        private ApplicationDbContext _db;

        public ProductsRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<string> AddProductByAdmin(ProductModel newProduct)
        {
            try
            {
                await _db.ProductsTable.AddAsync(newProduct);
                var result = await _db.SaveChangesAsync();

                if (result == 0)
                {
                    return "Error , Saving the Product in the database";
                }
                else
                {
                    return "Success , The Product  had been added";
                }

            }
            catch (Exception e)
            {

                return e.InnerException.ToString();
            }
        }

        public async Task<bool> CheckIfProductExist(ProductModel newProduct)
        {
            var DoesProductExitsInDataBase = await _db.ProductsTable.FirstOrDefaultAsync(a => a.ProductName.ToLower() == newProduct.ProductName.ToLower());
            if (DoesProductExitsInDataBase is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await _db.ProductsTable.Include(a=>a.Catagory).Include(a=>a.Company).ToListAsync();
        }

        public async Task<List<ProductModel>> GetAllProductsByCatagoryId(int CatagoryId)
        {
            return await _db.ProductsTable.Include(a=>a.Catagory).Include(a=>a.Company).Where(a => a.CatagoryId == CatagoryId).ToListAsync();
        }

        public async Task<List<ProductModel>> GetAllProductsByName(string ProductName)
        {
            // الغايةةمن انكلود هي ربط الجداول مع بعضها واسترجاع المنتجات مع الشركة ومع الفئة
            return await _db.ProductsTable.Include(a=>a.Catagory).Include(a=>a.Company).Where(a => a.ProductName.ToLower().Contains(ProductName.ToLower())).ToListAsync();
        }

        public async Task<ProductModel> GetProductById(int ProductId)
        {
            var Product = await _db.ProductsTable.Include(a => a.Catagory).Include(a => a.Company).FirstOrDefaultAsync(a => a.ProductId == ProductId);

            if (Product is null)
            {
                return new ProductModel();
            }
            else
            {
                return Product;
            }
        }
    }
}
