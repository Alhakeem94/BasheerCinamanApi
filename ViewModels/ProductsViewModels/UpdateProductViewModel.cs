namespace BasheerCinamanApi.ViewModels.ProductsViewModels
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double PriceOfPurchase { get; set; }
        public double PriceOfSelling { get; set; }
        public double PriceOfWholeSales { get; set; }
        public IFormFile? ProductImageFile { get; set; }

        public int CatagoryId { get; set; }
        public int CompanyId { get; set; }

    }
}
