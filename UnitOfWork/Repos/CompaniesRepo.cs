using BasheerCinamanApi.Data;
using BasheerCinamanApi.Models;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasheerCinamanApi.UnitOfWork.Repos
{
    public class CompaniesRepo : ICompanies
    {
        private ApplicationDbContext _db;

        public CompaniesRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<string> AddCompanyByAdmin(ProductCompanyModel newProductCompany)
        {
             await _db.ProductCompaniesTable.AddAsync(newProductCompany);
             int Result =  await _db.SaveChangesAsync();

            if (Result == 0)
            {
                 return "There was a problem storing the Company in the dataBase";
            }
            else if(Result == 1)
            {
                return "The Company has been added successfuly";
            }
            else
            {
                return "There was a problem adding the Company";
            }
        }





        public async Task<bool> CheckIfCompanyExists(ProductCompanyModel newProductCompany)
        {
            var DoesCompanyExists = await _db.ProductCompaniesTable.FirstOrDefaultAsync(a => a.CompanyName.ToLower() == newProductCompany.CompanyName.ToLower());

            if (DoesCompanyExists is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<List<ProductCompanyModel>> GetListOfAllProductCompanies()
        {
            return await _db.ProductCompaniesTable.ToListAsync();
        }
    }
}
