using BasheerCinamanApi.Data;
using BasheerCinamanApi.Models;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using BasheerCinamanApi.ViewModels.ProductsCatagoriesViewModels;
using BasheerCinamanApi.ViewModels.Responses.CategoriesResponses;
using Microsoft.EntityFrameworkCore;

namespace BasheerCinamanApi.UnitOfWork.Repos
{
    public class CatagoriesRepo : ICatagories
    {
        private ApplicationDbContext _db;
        private IWebHostEnvironment _env { get; set; }

        public CatagoriesRepo(ApplicationDbContext db, IWebHostEnvironment env, IProducts products)
        {
            _db = db;
            _env = env;
        }

        public async Task<AddCategoryResponse> AddCatagoryByAdmin(ProductCatagoryViewModel newProductCatagoryViewModel)
        {
            var CheckIfExits =await CheckIfCatagoryExists(newProductCatagoryViewModel.CatagoryName);

            if (CheckIfExits)
            {
                return new AddCategoryResponse()
                {
                    IsSuccess =false,
                    Message= "The Catagory Already Exists in the Database"
                };
            }
            else
            {
                var CatagoryModel = new ProductCatagoryModel();
                CatagoryModel.CatagoryName = newProductCatagoryViewModel.CatagoryName;
                CatagoryModel.CatagoryImagePath = await InputImage(newProductCatagoryViewModel.CatagoryImage);
                
                await _db.ProductCatagoryTable.AddAsync(CatagoryModel);
                var Result = await _db.SaveChangesAsync();
                if (Result == 0)
                {
                    return new AddCategoryResponse()
                    {
                        IsSuccess = false,
                        Message = "Error ,the Catagory Has not been Added"
                    };
                }
                else
                {
                    return new AddCategoryResponse()
                    {
                        IsSuccess =true,
                        Message = "The Catagory Has Been Added Successfuly"
                    };
                }
            }

        }


        private async Task<string> InputImage(IFormFile CatagoryImage)
        {
            var FileName = CatagoryImage.FileName;
            var FullName = Guid.NewGuid().ToString() + Path.GetExtension(CatagoryImage.FileName);

            var FolderDirectory = $"{_env.WebRootPath}//Images";
            var FullPath = Path.Combine(FolderDirectory, FullName);

            var memorystream = new MemoryStream();
            await CatagoryImage.OpenReadStream().CopyToAsync(memorystream);

            await using (var fs = new FileStream(FullPath, FileMode.Create, FileAccess.Write))
            {
                memorystream.WriteTo(fs);
            }

            return $"https://localhost:7098/Images/{FullName}";
        }



        public async Task<bool> CheckIfCatagoryExists(string CatagoryName)
        {
            var DoesCatagoryExits = await _db.ProductCatagoryTable.FirstOrDefaultAsync(a => a.CatagoryName.ToLower() == CatagoryName.ToLower());

            if (DoesCatagoryExits is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Task<bool> CheckIfCatagoryExists(ProductCatagoryViewModel newProductCatagoryViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductCatagoryModel>> GetListOfAllCatagories()
        {
            return await _db.ProductCatagoryTable.ToListAsync();
        }
    }
}
