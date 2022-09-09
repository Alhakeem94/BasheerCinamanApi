using System.ComponentModel.DataAnnotations;

namespace BasheerCinamanApi.Models
{
    public class UsersModel
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassWord { get; set; }

    }
}
