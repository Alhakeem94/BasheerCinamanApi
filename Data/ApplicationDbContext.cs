using BasheerCinamanApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BasheerCinamanApi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }


        public DbSet<ProductCompanyModel> ProductCompaniesTable { get; set; }
        public DbSet<ProductCatagoryModel> ProductCatagoryTable { get; set; }
        public DbSet<ProductModel> ProductsTable { get; set; }
        public DbSet<UsersModel> UsersTable { get; set; }
        public DbSet<ShoppingCartModel> ShoppingCartTable { get; set; }
        public DbSet<ProductBatchModel> ProductBatchTable { get; set; }
        public DbSet<ProvidorModel> ProvidorsTable { get; set; }



        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            const string Owner_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string OwnerRole_ID = "oi2eoij-1oqjsdkj-kaslk-OwnerRole";

            var Hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = Owner_ID,
                UserName = "BasheerSuper@gmail.com",
                NormalizedUserName = "BASHEERSUPER@GMAIL.COM",
                Email = "BasheerSuper@gmail.com",
                NormalizedEmail = "BASHEERSUPER@GMAIL.COM",
                SecurityStamp = RandomString(20),
                PasswordHash = Hasher.HashPassword(null, "Bash123"),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = OwnerRole_ID,
                Name = "SuperAdmin",
                ConcurrencyStamp = RandomString(20),
                NormalizedName = "SUPERADMIN"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "a18be9c0-aa65-4af8-bd17-00bd93Admin",
                Name = "Admin",
                ConcurrencyStamp = RandomString(20),
                NormalizedName = "ADMIN"
            });


            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "a18be9c0-aa65-4af8-bd17-00bd93Dev",
                Name = "Dev",
                ConcurrencyStamp = RandomString(20),
                NormalizedName = "DEV"
            });


            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "a18be9c0-aa65-4af8-bd17-00bd93DataEntry",
                Name = "DataEntry",
                ConcurrencyStamp = RandomString(20),
                NormalizedName = "DATAENTRY"
            });


            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = Owner_ID,
                RoleId = OwnerRole_ID,
            });


        }





        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    const string Owner_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
        //    const string OwnerRole_ID = "oi2eoij-1oqjsdkj-kaslk-OwnerRole";

        //    const string SuperAdminRole_ID = "a18be9c0-aa65-4af8-bd17-123987asddsa";
        //    const string AdminRole_ID = "a18be9c0-aa65-4af8-bd17-123987moahYg";

        //    builder.Entity<IdentityRole>().HasData(new IdentityRole
        //    {
        //        Id = OwnerRole_ID,
        //        Name = "owner",
        //        NormalizedName = "OWNER"
        //    });


        //    var hasher = new PasswordHasher<IdentityUser>();
        //    builder.Entity<IdentityUser>().HasData(new IdentityUser
        //    {
        //        Id = Owner_ID,
        //        UserName = "DR.Aqeel@gmail.com",
        //        NormalizedUserName = "DR.AQEEL@GMAIL.COM",
        //        Email = "Dr.Aqeel@gmail.com",
        //        NormalizedEmail = "DR.AQEEL@GMAIL.COM",
        //        EmailConfirmed = true,
        //        PasswordHash = hasher.HashPassword(null, "AQ12345_"),
        //        SecurityStamp = Guid.NewGuid().ToString()
        //    });

        //    builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        //    {
        //        RoleId = OwnerRole_ID,
        //        UserId = Owner_ID
        //    });

        //}






    }

}
