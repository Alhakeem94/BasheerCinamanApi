using System.ComponentModel.DataAnnotations.Schema;

namespace BasheerCinamanApi.ViewModels.BatchesViewModels
{
    public class AddNewBatchViewModel
    {
        public int ProductId { get; set; }
        public int ProvidorId { get; set; }
        public string BatchNumber { get; set; }
        public DateTime DateOfProduction { get; set; }
        public DateTime DateOfExpiration { get; set; }
        public int BatchQuantity { get; set; }

    }
}
