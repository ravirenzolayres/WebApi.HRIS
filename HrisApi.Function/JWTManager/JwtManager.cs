using HrisApi.Data.Interface;
using HrisApi.Model;
using HrisApi.Model.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.JWTManager
{
    public class JwtManager: IJwtManager
    {
        private readonly IConfiguration _iConfig;

        private IDUser _iDUser;

        public JwtManager(IConfiguration iConfig,IDUser iDUser)
        {
            _iConfig = iConfig;
            _iDUser = iDUser;
        }

        public async Task<string> Authenticate(UserCredential userCredential)
        {
            var verified = await AuthenticateUser(userCredential);

            if (!verified)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iConfig["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name,userCredential.Username)
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials  = signingCredentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> AuthenticateUser(UserCredential userCredential)
        {
            var checkUser = await _iDUser.Get(x => x.IsActive == true && x.Username == userCredential.Username && x.Password == userCredential.Password);
            return checkUser != null ? true : false;
        }
    }
}
