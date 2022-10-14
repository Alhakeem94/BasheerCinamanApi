using BasheerCinamanApi.Data;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BasheerCinamanApi.UnitOfWork.Repos
{
    public class SuperAdminRepo : ISuperAdmin
    {

        private ApplicationDbContext _db;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public SuperAdminRepo(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<string> AddUserToAdminRole(string UserId)
        {
            try
            {
                var Result = await CheckIfUserHasMoreThanOneRole(UserId);
                if (Result.Item1)
                {
                    return $"The User {Result.Item2.UserName} Has More Than One Role";
                }
                else
                {
                    await _userManager.AddToRoleAsync(Result.Item2, "ADMIN");
                    return $"The User {Result.Item2.UserName} Has Been Added To ADMIN Role";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }



        public async Task<string> AddUserToDataEntryRole(string UserId)
        {
            try
            {
                var Result = await CheckIfUserHasMoreThanOneRole(UserId);
                if (Result.Item1)
                {
                    return $"The User {Result.Item2.UserName} Has More Than One Role";
                }
                else
                {
                    await _userManager.AddToRoleAsync(Result.Item2, "DATAENTRY");
                    return $"The User {Result.Item2.UserName} Has Been Added To DataEntry Role";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> AddUserToDevRole(string UserId)
        {
            try
            {
                var Result = await CheckIfUserHasMoreThanOneRole(UserId);
                if (Result.Item1)
                {
                    return $"The User {Result.Item2.UserName} Has More Than One Role";
                }
                else
                {
                    await _userManager.AddToRoleAsync(Result.Item2, "DEV");
                    return $"The User {Result.Item2.UserName} Has Been Added To DEV Role";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> AddUserToSuperAdminRole(string UserId)
        {
            try
            {
               var Result = await CheckIfUserHasMoreThanOneRole(UserId);
                if (Result.Item1)
                {
                    return $"The User {Result.Item2.UserName} Has More Than One Role";
                }
                else
                {
                    await _userManager.AddToRoleAsync(Result.Item2, "SUPERADMIN");
                    return $"The User {Result.Item2.UserName} Has Been Added To SUPERADMIN Role";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> UpdateToAdminRole(string UserId)
        {
            var User = await _userManager.FindByIdAsync(UserId);
            var UserRole = await _db.UserRoles.FirstOrDefaultAsync(a => a.UserId == UserId);
            var Role = await _db.Roles.FirstOrDefaultAsync(a => a.Id == UserRole.RoleId);
            await _userManager.RemoveFromRoleAsync(User, Role.Name);

            await _userManager.AddToRoleAsync(User, "ADMIN");
            return $"The User {User.UserName} Has Been Added To The ADMIN Role";

        }





        // This Function Checks If The User Has More than one Database role And Returns the IdentityUser Recored with REsult Of Checking 

        private async Task<Tuple<bool,IdentityUser>> CheckIfUserHasMoreThanOneRole(string UserId)
        {

            var User = await _userManager.FindByIdAsync(UserId);
            var ListOfRolesForUser = await _userManager.GetRolesAsync(User);

            if (ListOfRolesForUser.Count > 0)
            {
                return new Tuple<bool,IdentityUser>(true,User);
            }
            else
            {
               return new Tuple<bool,IdentityUser>(false,User);
            }

        }






    }
}
