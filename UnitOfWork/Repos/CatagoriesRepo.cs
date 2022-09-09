using BasheerCinamanApi.Data;
using BasheerCinamanApi.Models;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasheerCinamanApi.UnitOfWork.Repos
{
    public class CatagoriesRepo : ICatagories
    {
        private ApplicationDbContext _db;

        public CatagoriesRepo(ApplicationDbContext db)
        {
            _db = db;
        }





        public async Task<string> AddCatagoryByAdmin(ProductCatagoryModel newProductCatagory)
        {
            await _db.ProductCatagoryTable.AddAsync(newProductCatagory);
           var Result = await _db.SaveChangesAsync();


            if (Result == 0)
            {
                return "Error , Failed to add Catagory";
            }
            else
            {
                return "The Catagory Has Been Added ";
            }

           
        }

        public async Task<bool> CheckIfCatagoryExists(ProductCatagoryModel newProductCatagory)
        {
            var DoesCatagoryExits = await _db.ProductCatagoryTable.FirstOrDefaultAsync(a => a.CatagoryName.ToLower() == newProductCatagory.CatagoryName.ToLower());

            if (DoesCatagoryExits is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<List<ProductCatagoryModel>> GetListOfAllCatagories()
        {
            return await _db.ProductCatagoryTable.ToListAsync();
        }
    }
}
