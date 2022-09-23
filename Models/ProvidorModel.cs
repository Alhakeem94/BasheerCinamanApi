using System.ComponentModel.DataAnnotations;

namespace BasheerCinamanApi.Models
{
    public class ProvidorModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
