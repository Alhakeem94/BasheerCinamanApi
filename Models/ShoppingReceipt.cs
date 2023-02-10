using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasheerCinamanApi.Models
{
    public class ShoppingReceipt
    {
        [Key]
        public Guid ShoppingCartId { get; set; } 
        [ForeignKey("IdentityUserTable")]
        public string UserId { get; set; }
        public string? UserNotes { get; set; }
        public DateTime DateOfReciept { get; set; } = DateTime.Now;
        public double RecieptTotalAmount { get; set; }


        public IdentityUser IdentityUserTable { get; set; }


    }
}
