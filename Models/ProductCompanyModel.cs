using System.ComponentModel.DataAnnotations;

namespace BasheerCinamanApi.Models
{
    public class ProductCompanyModel
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyRegion { get; set; }
    }
}
