using BasheerCinamanApi.Data;
using BasheerCinamanApi.Models;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BasheerCinamanApi.UnitOfWork.Repos
{
    public class UsersRepo : IUsers
    {

        private ApplicationDbContext _db;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;



        public UsersRepo(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }




        public async Task<string> AddUserByAdminToTheSystem(UsersModel newUser)
        {


            var Hasher = new PasswordHasher<IdentityUser>();
            var CheckIfUserExistsInDataBase = await _userManager.FindByNameAsync(newUser.UserName);

            if (CheckIfUserExistsInDataBase is null)
            {
                var newIdentityUser = new IdentityUser();

                newIdentityUser.UserName = newUser.UserName;
                newIdentityUser.NormalizedUserName = newUser.UserName.ToUpper();
                newIdentityUser.Email = newUser.UserName;
                newIdentityUser.NormalizedEmail = newUser.UserName.ToUpper();
                newIdentityUser.EmailConfirmed = true;
                newIdentityUser.PasswordHash = Hasher.HashPassword(null, newUser.UserPassWord);
                newIdentityUser.SecurityStamp = RandomString(20);
                newIdentityUser.ConcurrencyStamp = Guid.NewGuid().ToString();

                await _userManager.CreateAsync(newIdentityUser);
                await _db.SaveChangesAsync();
                return "The user Has Been Added To the Database";
            }
            else
            {
                return "The User Already Exists in the database";
            }



        }



        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }



        public async Task<List<IdentityUser>> GetAllUsers()
        {
            var AllUsers = await _db.Users.ToListAsync();
            return AllUsers;
        }

        public async Task<IdentityUser> GetUserById(string UserId)
        {
            var User = await _db.Users.FirstOrDefaultAsync(a => a.Id == UserId);
            // These Two Functions Work the Same 
            //  var User2 = await _userManager.FindByIdAsync(UserId);
            return User;
        }

        public async Task<IdentityUser> GetUserByName(string UserName)
        {
            var User = await _db.Users.FirstOrDefaultAsync(a => a.UserName.ToLower() == UserName.ToLower());
            //  These Two Functions Work the Same
            //  var User2 = await _userManager.FindByNameAsync(UserName);
            return User;
        }
    }
}
