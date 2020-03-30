using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Motel.EntityDb.Entities;
using Motel.Utilities.Exceptions;
using Motel.ViewModel.System.User;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Motel.Application.Category.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signManager;
        private readonly RoleManager<AppRoles> _roleManager;
        private readonly IConfiguration _config;
        public UserService(UserManager<AppUser> user, SignInManager<AppUser> signIn, RoleManager<AppRoles> role, IConfiguration config)
        {
            _signManager = signIn;
            _userManager = user;
            _roleManager = role;
            _config = config;
        }

        public async Task<string> Authentication(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null) throw new MotelExceptions("can find");

            var result = await _signManager.PasswordSignInAsync(request.UserName, request.PassWord, true, true);

            if (!result.Succeeded)
                return null;
            var roles = await _userManager.GetRolesAsync(user);
           
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var credis = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokendescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.GivenName,user.FirstName),
                    new Claim(ClaimTypes.Role, string.Join(";",roles)),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = credis,
            };
            var tokenhandle = new JwtSecurityTokenHandler();
            var token = tokenhandle.CreateToken(tokendescriptor);
            return tokenhandle.WriteToken(token);
        }
        public async Task<bool> register(RegisterRequest requset)
        {
            var user = new AppUser()
            {
                UserName = requset.UserName,
                Email = requset.Email,
                FirstName = requset.FirstName,
                LastName = requset.LastName,
                PhoneNumber = requset.PhoneNumber,
                Dob = DateTime.Now,
            };
            var result = await _userManager.CreateAsync(user, requset.PassWord);
            if (result.Succeeded)
                return true;
            return false;
        }
    }
}
