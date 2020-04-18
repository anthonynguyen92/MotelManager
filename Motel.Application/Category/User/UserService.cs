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

        public async Task<string> Authentication(string username,string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null) return null;

            var result = await _signManager.PasswordSignInAsync(username, password, true, true);

            if (!result.Succeeded)
                return null;
            var roles = await _userManager.GetRolesAsync(user);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv"));
            var credis = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
            };

            var tokenhandle = new JwtSecurityTokenHandler();

            var token1 = new JwtSecurityToken(
                _config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credis
                );
            return tokenhandle.WriteToken(token1);
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
