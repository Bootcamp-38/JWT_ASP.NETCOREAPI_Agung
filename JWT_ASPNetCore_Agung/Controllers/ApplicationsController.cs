using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using JWT_ASPNetCore_Agung.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JWT_ASPNetCore_Agung.Services;
using JWT_ASPNetCore_Agung.Repositories;
using JWT_ASPNetCore_Agung.Bases;

namespace JWT_ASPNetCore_Agung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : BaseController<Application, ApplicationsRepository>
    {
        public ApplicationsController(ApplicationsRepository application) : base(application)
        {

        }
        //private readonly IDapper _dapper;
        //public ApplicationsController(IDapper dapper)
        //{
        //    _dapper = dapper;
        //}
        //[HttpPost(nameof(Create))]
        //public async Task<int> Create(Application data)
        //{
        //    var dbparams = new DynamicParameters();
        //    dbparams.Add("Name", data.Name, DbType.String);
        //    var result = await Task.FromResult(_dapper.Insert<int>("[dbo].[SP_Insert_Application]", dbparams, commandType: CommandType.StoredProcedure));
        //    return result;
        //}
        //[HttpGet(nameof(GetById))]
        //public async Task<Application> GetById(int id)
        //{
        //    var result = await Task.FromResult(_dapper.Get<Application>($"Select * from TB_M_Application where Id = {id}", null, commandType: CommandType.Text));
        //    return result;
        //}
        //[HttpGet(nameof(GetAllData))]
        //public List<Application> GetAllData()
        //{
        //    var result = (_dapper.GetAll<Application>($"Select * from TB_M_Application", null, commandType: CommandType.Text));
        //    return result;
        //}
        //[HttpDelete(nameof(Delete))]
        //public async Task<int> Delete(int id)
        //{
        //    var result = await Task.FromResult(_dapper.Execute($"DELETE FROM TB_M_Application WHERE Id = {id}", null, commandType: CommandType.Text));
        //    return result;
        //}
        //[HttpPatch(nameof(Update))]
        //public Task<int> Update(Application data)
        //{
        //    var dbPara = new DynamicParameters();
        //    dbPara.Add("Id", data.Id);
        //    dbPara.Add("Name", data.Name, DbType.String);

        //    var updateApp = Task.FromResult(_dapper.Update<int>("[dbo].[SP_Update_Application]",
        //                    dbPara,
        //                    commandType: CommandType.StoredProcedure));
        //    return updateApp;
        //}



    }
}
