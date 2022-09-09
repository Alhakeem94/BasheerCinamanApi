using BasheerCinamanApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BasheerCinamanApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }


        public DbSet<ProductCompanyModel> ProductCompaniesTable { get; set; }
        public DbSet<ProductCatagoryModel> ProductCatagoryTable { get; set; }
        public DbSet<ProductModel> ProductsTable { get; set; }
        public DbSet<UsersModel> UsersTable { get; set; }
        public DbSet<ShoppingCartModel> ShoppingCartTable { get; set; }



    }
}
