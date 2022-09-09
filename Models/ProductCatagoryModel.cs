using System.ComponentModel.DataAnnotations;

namespace BasheerCinamanApi.Models
{
    public class ProductCatagoryModel
    {
        [Key]
        public int CatagoryId { get; set; }
        public string CatagoryName { get; set; }
        public string CatagoryImagePath { get; set; }

    }
}
