using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BasheerCinamanApi.Models
{
    [Keyless]
    public class EmpClass
    {
        [Required]
        public string EmpName { get; set; }
        [MaxLength(15)]
        [Required]
        public string PhoneNumber { get; set; }
    }
}
