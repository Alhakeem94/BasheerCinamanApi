using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasheerCinamanApi.Models
{
    [Keyless]
    public class ShoppingCartModel
    {
        public Guid ShoppingCartId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public double ProductSellAmount { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductTotalAmount { get; set; }
        public string CustomerNotes { get; set; }
        public ProductModel Product { get; set; }

    }
}
