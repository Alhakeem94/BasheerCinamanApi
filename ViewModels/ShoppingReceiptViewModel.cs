using BasheerCinamanApi.Models;

namespace BasheerCinamanApi.ViewModels
{
    public class ShoppingReceiptViewModel
    {

        public string UserId { get; set; }
        public string? UserNotes { get; set; }
        public double RecieptTotalAmount { get; set; }

        public List<ShoppingCartTestViewModel> ListOfShoppingProduct { get; set; }


    }
}
