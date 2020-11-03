using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using JWT_ASPNetCore_Agung.Models;
using JWT_ASPNetCore_Agung.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_ASPNetCore_Agung.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IDapper _dapper;
        public AccountsController(IDapper dapper)
        {
            _dapper = dapper;
        }
        [HttpGet(nameof(Login))]
        public async Task<User> Login(User data)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Email", data.Email, DbType.String);
            dbparams.Add("Password", data.Password, DbType.String);
            var result = await Task.FromResult(_dapper.Get<User>("SP_Login", dbparams, commandType: CommandType.StoredProcedure));
            return result;
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
