using BasheerCinamanApi.Data;
using BasheerCinamanApi.Models;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using BasheerCinamanApi.ViewModels.ProductsViewModels;
using BasheerCinamanApi.ViewModels.Responses.CategoriesResponses;
using Microsoft.EntityFrameworkCore;

namespace BasheerCinamanApi.UnitOfWork.Repos
{
    public class ProductsRepo : IProducts
    {

        private ApplicationDbContext _db;
        private IWebHostEnvironment _env;

        public ProductsRepo(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<string> AddProductByAdmin(AddProductViewModel newProductViewModel)
        {
            try
            {


                var DataBaseModel = new ProductModel();
                DataBaseModel.ProductName = newProductViewModel.ProductName;
                DataBaseModel.PriceOfPurchase = newProductViewModel.PriceOfPurchase;
                DataBaseModel.CatagoryId = newProductViewModel.CatagoryId;
                DataBaseModel.CompanyId = newProductViewModel.CompanyId;
                DataBaseModel.ProductImagePath = await InputImage(newProductViewModel.ProductImageFile);
                DataBaseModel.PriceOfSelling = newProductViewModel.PriceOfSelling;
                DataBaseModel.PriceOfWholeSales = newProductViewModel.PriceOfWholeSales;
                DataBaseModel.ProductDescription = newProductViewModel.ProductDescription;

                await _db.ProductsTable.AddAsync(DataBaseModel);




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
                return e.Message;
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

            return $"Images/{FullName}";
        }

        //https://localhost:7098/




        public async Task<bool> CheckIfProductExist(AddProductViewModel newProduct)
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

        public Task<ProductModel> GetProductsUnder10Amount(int ProductId)
        {
            throw new NotImplementedException();
        }

        public async Task<AddCategoryResponse> EditProductById(UpdateProductViewModel updateProductViewModel)
        {
            try
            {
                var CheckIfProductExistsInDataBase = await _db.ProductsTable.FirstOrDefaultAsync(a => a.ProductId == updateProductViewModel.Id);

                if (CheckIfProductExistsInDataBase is null)
                {
                    return new AddCategoryResponse()
                    {
                        IsSuccess = false,
                        Message = "The Product does exist in the database to be edited",
                    };

                }
                else
                {
                    CheckIfProductExistsInDataBase.ProductDescription = updateProductViewModel.ProductDescription;
                    CheckIfProductExistsInDataBase.ProductName = updateProductViewModel.ProductName;
                    CheckIfProductExistsInDataBase.PriceOfWholeSales = updateProductViewModel.PriceOfWholeSales;
                    CheckIfProductExistsInDataBase.PriceOfSelling = updateProductViewModel.PriceOfSelling;
                    CheckIfProductExistsInDataBase.PriceOfPurchase = updateProductViewModel.PriceOfPurchase;
                    CheckIfProductExistsInDataBase.CompanyId = updateProductViewModel.CompanyId;
                    CheckIfProductExistsInDataBase.CatagoryId = updateProductViewModel.CatagoryId;

                    if (updateProductViewModel.ProductImageFile != null)
                    {
                        var Result = DeleteOldProductImage(CheckIfProductExistsInDataBase.ProductImagePath);
                        var ResultOfImageStoring = await InputImage(updateProductViewModel.ProductImageFile);
                        CheckIfProductExistsInDataBase.ProductImagePath = ResultOfImageStoring;
                    }

                    _db.ProductsTable.Update(CheckIfProductExistsInDataBase);
                    await _db.SaveChangesAsync();

                    return new AddCategoryResponse()
                    {
                        IsSuccess = true,
                        Message = "The Product has been updated successfuly"
                    };


                }

            }
            catch (Exception e)
            {

                return new AddCategoryResponse()
                {
                    Message = e.Message,    
                    IsSuccess = false,
                };
            }
        }




        private bool DeleteOldProductImage(string ImagePath)
        {
            var FullPath = Path.Combine(_env.WebRootPath, ImagePath);
            if (File.Exists(FullPath))
            {
                File.Delete(FullPath);
                return true;
            }
            else
            {
                return false;
            }
        }











    }
}
