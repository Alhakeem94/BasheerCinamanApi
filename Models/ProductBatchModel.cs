using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace BasheerCinamanApi.Models
{
    public class ProductBatchModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Providor")]
        public int ProvidorId { get; set; }

        public string BatchNumber { get; set; }
        public DateTime DateOfProduction { get; set; }
        public DateTime DateOfExpiration { get; set; }
        public int BatchQuantity { get; set; }

        public ProductModel Product { get; set; }
        public ProvidorModel Providor { get; set; }
    }
}
