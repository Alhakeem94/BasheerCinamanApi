using BasheerCinamanApi.Configuration;
using BasheerCinamanApi.Data;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using BasheerCinamanApi.ViewModels;
using BasheerCinamanApi.ViewModels.IdentityViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace BasheerCinamanApi.UnitOfWork.Repos
{
    public class IdentityRepo : IIdentityProvidor
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtConfiq _JwtConfig;

        public IdentityRepo(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IOptionsMonitor<JwtConfiq> OptionsMonitor)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _JwtConfig = OptionsMonitor.CurrentValue; ;
        }

        public async Task<GeneralResponse> AddNewUserToTheSystem(RegisterViewModel NewUser)
        {
            var CheckIfUserExistsInDataBase = await _userManager.FindByNameAsync(NewUser.Email);

            if (CheckIfUserExistsInDataBase is null)
            {
                var IdentityUser = new IdentityUser()
                {
                    UserName = NewUser.Email,
                    Email = NewUser.Email,
                    PhoneNumber = NewUser.UserPhoneNumber,
                };


                await _userManager.CreateAsync(IdentityUser, NewUser.PassWord);
                await _userManager.AddToRoleAsync(IdentityUser, "DataEntry");

                await _db.SaveChangesAsync();
                
                var RegistrationReposne = new GeneralResponse()
                {
                    IsSuccess = true,
                    Message = "The User Has Been Added Successfuly to the system",
                };

                return RegistrationReposne;

            }
            else
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "Unable to register user"
                };
            }
        }




        public async Task<LoginResponse> UserLogin(LoginViewModel UserLogIn)
        {
            try
            {
                var CheckIfUserExistsInTheDataBase = await _userManager.FindByNameAsync(UserLogIn.Email);
                if (CheckIfUserExistsInTheDataBase is null)
                {
                    return new LoginResponse()
                    {
                        Success = false,
                        Token = null,
                        Errors = new List<string>
                        {
                            $"There is no registered user Of the Name {UserLogIn.Email}"
                        },
                        UserRole = null,
                    };
                }
                else
                {
                    var CheckIfUserPasswordIsCorrect = await _userManager.CheckPasswordAsync(CheckIfUserExistsInTheDataBase, UserLogIn.PassWord);

                    if (CheckIfUserPasswordIsCorrect)
                    {
                        var JwtToken = await GenerateJwtToken(CheckIfUserExistsInTheDataBase);
                        return new LoginResponse()
                        {
                            Success = true,
                            Token = JwtToken,
                            UserRole = await GetUserRoleName(CheckIfUserExistsInTheDataBase)
                        };
                    }
                    else
                    {
                        return new LoginResponse()
                        {
                            Success = false,
                        };
                    }
                }

            }
            catch (Exception e)
            {

                return new LoginResponse()
                {
                    Errors = new List<string>()
                    {
                        e.Message
                    }
                };
            }
        }






        private async Task<string> GetUserRoleName(IdentityUser User)
        {
            var ListOfUserRoles = await _userManager.GetRolesAsync(User);
            if (ListOfUserRoles.Count == 0)
            {
                return "No Role";
            }
            else
            {
                return ListOfUserRoles[0];
            }
        }



        private async Task<string> GenerateJwtToken(IdentityUser user)
        {
            var ListOfClaims = await GetClaims(user);

            var tokenDiscreptor = new SecurityTokenDescriptor()
            {

                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role ,await GetUserRoleName(user)),
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_JwtConfig.Secret)), SecurityAlgorithms.HmacSha256Signature),
            };

            var JwtTokenHandler = new JwtSecurityTokenHandler();
            var token = JwtTokenHandler.CreateToken(tokenDiscreptor);
            var jwtToken = JwtTokenHandler.WriteToken(token);

            return jwtToken;
        }


        private async Task<Claim> GetClaims(IdentityUser user)
        {

            var roles = await _userManager.GetRolesAsync(user);

            var claim = (new Claim(ClaimTypes.Role, roles[0]));

            return claim;
        }



    }
}
