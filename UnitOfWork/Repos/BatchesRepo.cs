using BasheerCinamanApi.Data;
using BasheerCinamanApi.Models;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using BasheerCinamanApi.ViewModels.BatchesViewModels;
using Microsoft.EntityFrameworkCore;

namespace BasheerCinamanApi.UnitOfWork.Repos
{
    public class BatchesRepo : IBatch
    {

        private ApplicationDbContext _db;

        public BatchesRepo(ApplicationDbContext db)
        {
            _db = db;
        }




        public async Task<string> AddNewBatch(AddNewBatchViewModel newBatchViewModel)
        {
            try
            {
                var CheckIfBatchExistsInDataBase = await _db.ProductBatchTable.FirstOrDefaultAsync(a => a.BatchNumber == newBatchViewModel.BatchNumber);


                // Check if batch Exists then we add new Recored to the database : else we update the current batch quantity
                if (CheckIfBatchExistsInDataBase is null)
                {
                    var DbModel = new ProductBatchModel();
                    DbModel.BatchNumber = newBatchViewModel.BatchNumber;
                    DbModel.BatchQuantity = newBatchViewModel.BatchQuantity;
                    DbModel.ProductId = newBatchViewModel.ProductId;
                    DbModel.DateOfProduction = newBatchViewModel.DateOfProduction;
                    DbModel.DateOfExpiration = newBatchViewModel.DateOfExpiration;
                    DbModel.ProvidorId = newBatchViewModel.ProvidorId;


                    await _db.ProductBatchTable.AddAsync(DbModel);
                    await _db.SaveChangesAsync();

                    var Result = await EditCurrentQuantityOfProductsInDataBase(newBatchViewModel, true);
                    if (Result)
                    {
                        return "Update is success";
                    }
                    else
                    {
                        return "Update failed";
                    }
                    // Send To Function TO Edit The Product Total Quantity
                }
                else
                {
                    // Send To Function To Update the Product Quantity
                    var Result = await EditCurrentQuantityOfProductsInDataBase(newBatchViewModel, false);
                    if (Result)
                    {
                        return "Update is success";
                    }
                    else
                    {
                        return "Update failed";
                    }
                }

            }
            catch (Exception e)
            {
                return e.Message;
            }

        }



        // This Function will Edit the Product total Quantity when we make a shopping cart , Buying from the store
        private async Task<bool> EditCurrentQuantityOfProductsInDataBase(AddNewBatchViewModel addNewBatchViewModel , bool IsFirst)
        {
            try
            {
                if (IsFirst == true)
                {
                    var Product = await _db.ProductsTable.FirstOrDefaultAsync(a => a.ProductId == addNewBatchViewModel.ProductId);

                    Product.TotalQuantityOfBatches = await _db.ProductBatchTable.Where(a => a.ProductId == addNewBatchViewModel.ProductId).Select(a => a.BatchQuantity).SumAsync();
                    _db.ProductsTable.Update(Product);
                    await _db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    var Batch = await _db.ProductBatchTable.FirstOrDefaultAsync(a => a.BatchNumber == addNewBatchViewModel.BatchNumber);
                    Batch.BatchQuantity = Batch.BatchQuantity + addNewBatchViewModel.BatchQuantity;
                    // 10000                                 // 500   = 105000
                    _db.ProductBatchTable.Update(Batch);
                    await _db.SaveChangesAsync();
                    var Product = await _db.ProductsTable.FirstOrDefaultAsync(a => a.ProductId == addNewBatchViewModel.ProductId);

                    Product.TotalQuantityOfBatches = await _db.ProductBatchTable.Where(a => a.ProductId == addNewBatchViewModel.ProductId).Select(a => a.BatchQuantity).SumAsync();

                    _db.ProductBatchTable.Update(Batch);
                    _db.ProductsTable.Update(Product);

                    await _db.SaveChangesAsync();
                    return true;
               }

            }
            catch (Exception)
            {

                return false;
            }





          
        }












    }
}
