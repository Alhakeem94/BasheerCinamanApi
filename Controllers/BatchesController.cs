using BasheerCinamanApi.Data;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using BasheerCinamanApi.ViewModels.BatchesViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasheerCinamanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchesController : ControllerBase
    {

        private ApplicationDbContext _db;
        private IBatch _IBatches;
        public BatchesController(ApplicationDbContext db, IBatch iBatches)
        {
            _db = db;
            _IBatches = iBatches;
        }


        [HttpPost("AddNewBatch")]
        public async Task<IActionResult> AddNewBatchByAdmin([FromForm]AddNewBatchViewModel newBatch)
        {
            var Result = await _IBatches.AddNewBatch(newBatch);

            return Ok(Result);
        }




    }
}
