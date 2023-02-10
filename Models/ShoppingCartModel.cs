using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasheerCinamanApi.Models
{
    [Keyless]
    public class ShoppingCartModel
    {
        [ForeignKey("ShoppingReceiptsTable")]
        public Guid ShoppingCartId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public double ProductSellAmount { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductTotalAmount { get; set; }
        public DateTime DateOfinvoice { get; set; } = DateTime.Now;
        public ProductModel Product { get; set; }
        public ShoppingReceipt ShoppingReceiptsTable { get; set; }
    }
}
