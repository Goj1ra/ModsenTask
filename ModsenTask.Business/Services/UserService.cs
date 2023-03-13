using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModsenTask.Business.Mapper;
using ModsenTask.Business.Models;
using ModsenTask.Business.Services.Interfaces;
using ModsenTask.Data.Entities;
using ModsenTask.Data.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ModsenTask.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;


        public UserService(
            IConfiguration configuration,
            IMapper mapper,
            IUserRepository userRepository)

        {
            _configuration = configuration;
            _userRepository = userRepository;
        }
            

        public async Task<UserModel> Login(UserModel userModel)
        {

            var user = Authenticate(userModel).Result;

            userModel.Token = Generate(user);

            return userModel;
        }

        public async Task<UserModel> Register(UserModel userModel)
        {
            try
            {
                var user = ApplicationMapper.Mapper.Map<User>(userModel);
                var userToFind = _userRepository.GetUserWithEmail(user);
                if (userToFind == null)
                {
                    user.PasswordHash = BCryptNet.HashPassword(userModel.Password);
                    user.PasswordSalt = BCryptNet.GenerateSalt();
                    await _userRepository.Register(user);
                    return userModel;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Surname, user.Surname)
            };

            var token = new JwtSecurityToken
            (
               issuer: _configuration["Jwt:Issuer"],
               audience: _configuration["Jwt:Audience"],
               claims: claims,
               expires: DateTime.UtcNow.AddDays(7),
               signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private async Task<User> Authenticate(UserModel userModel)
        {
            var user = ApplicationMapper.Mapper.Map<User>(userModel);
            user = await _userRepository.GetUserWithEmail(user);
            if (user == null || !BCryptNet.Verify(userModel.Password, user.PasswordHash))
                return null;

            return user;
        }
    }
}
