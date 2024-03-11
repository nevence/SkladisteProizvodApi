using AutoMapper;
using AutoMapper.Configuration;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User? _user;

        public AuthenticationService(ILoggerManager loggerManager, IMapper mapper,
            UserManager<User> userManager, IConfiguration configuration)
        {
            _loggerManager = loggerManager;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user,
                userForRegistration.Password);

            if (result.Succeeded)
            {
                foreach (var role in userForRegistration.Roles)
                {
                    await _userManager.AddToRoleAsync(user, role);

                }

            }
            return result;
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName);

            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));
            if (!result)
            {
                _loggerManager.LogWarn($"{nameof(ValidateUser)}: Autentifikacija nije uspela. Pogresno korisnicko ime ili lozinka.");
            }
            return result;

        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName),
                new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString()),
            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;

        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"]
                )),
                signingCredentials: signingCredentials
                );

            return tokenOptions;
        }

        public async Task<IdentityResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByNameAsync(userId);
            if(user == null)
            {
                throw new UserNotFoundException(userId);
            }

            var result = await _userManager.DeleteAsync(user);
            return result;
        }

        public async Task<IdentityResult> ChangePassword(string userId, string oldPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null )
            {
                throw new UserNotFoundException(userId);
            }

            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            return result;            
        }

        public async Task<IdentityResult> UpdateUser(string userId, UserForUpdateDto userForUpdate)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                throw new UserNotFoundException(userId);
            }
            
            _mapper.Map(userForUpdate, user);
            var result = await _userManager.UpdateAsync(user);
            return result;
        }

        public async Task<(IEnumerable<UserDto> users, MetaData metaData)> GetUsers(UserParameters userParameters)
        {
            var users = await GetUsersAsync(userParameters);
            var usersDto = new List<UserDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userDto = _mapper.Map<UserDto>(user);
                userDto.Roles = roles.ToList(); 
                usersDto.Add(userDto); 
            }

            return (users: usersDto, metaData: users.MetaData);
        }


        private async Task<PagedList<User>> GetUsersAsync(UserParameters userParameters)
        {
            var users = _userManager.Users
                .OrderBy(u => u.Ime)
                .Skip((userParameters.PageNumber - 1) * userParameters.PageSize)
                .Take(userParameters.PageSize)
                .ToList();

            var count = _userManager.Users.Count();
            return PagedList<User>.ToPagedList(users, count, userParameters.PageNumber, userParameters.PageSize);
        }

    }
}
