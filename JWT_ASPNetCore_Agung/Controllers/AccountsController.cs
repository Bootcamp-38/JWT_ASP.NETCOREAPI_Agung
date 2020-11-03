using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using JWT_ASPNetCore_Agung.Models;
using JWT_ASPNetCore_Agung.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JWT_ASPNetCore_Agung.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        public IConfiguration _configuration;
        private readonly IDapper _dapper;

        public AccountsController(IDapper dapper, IConfiguration configuration)
        {
            _dapper = dapper;
            _configuration = configuration;
        }
        [HttpGet(nameof(Login))]
        public async Task<string> Login(User data)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Email", data.Email, DbType.String);
            dbparams.Add("Password", data.Password, DbType.String);
            var result = await Task.FromResult(_dapper.Get<User>("SP_Login", dbparams, commandType: CommandType.StoredProcedure));
            var claims = new[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Email", result.Email),
                    new Claim("Password", result.Password)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost(nameof(Register))]
        public async Task<int> Register(User data)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Email", data.Email, DbType.String);
            dbparams.Add("Password", data.Password, DbType.String);
            var result = await Task.FromResult(_dapper.Insert<int>("SP_Register", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        [HttpPatch(nameof(ChangePass))]
        public Task<int> ChangePass(User data)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Id", data.Id);
            dbPara.Add("Password", data.Password, DbType.String);
            var updateUser = Task.FromResult(_dapper.Update<int>("[dbo].[SP_ChangePass]",
                            dbPara,
                            commandType: CommandType.StoredProcedure));
            return updateUser;
        }
    }
}
