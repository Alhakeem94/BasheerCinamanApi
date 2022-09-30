using BasheerCinamanApi.Models;
using BasheerCinamanApi.ViewModels.BatchesViewModels;

namespace BasheerCinamanApi.UnitOfWork.Interfaces
{
    public interface IBatch
    {
        public Task<string> AddNewBatch(AddNewBatchViewModel newBatchViewModel);

    }
}
