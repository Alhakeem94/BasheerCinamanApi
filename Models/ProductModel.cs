using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasheerCinamanApi.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int TotalQuantityOfBatches { get; set; } = 0 ;
        public double PriceOfPurchase { get; set; }
        public double PriceOfSelling { get; set; }
        public double PriceOfWholeSales { get; set; }
        public string ProductImagePath { get; set; }




        [ForeignKey("Catagory")]
        public int CatagoryId { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }



        public ProductCatagoryModel Catagory { get; set; }
        public ProductCompanyModel Company { get; set; }



    }
}
