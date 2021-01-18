using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HrisApi.Function.Interface;
using HrisApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BioLogsController : ControllerBase
    {
        private readonly IFBioLogs _iFBioLogs;
        private string loggedUser;

        public BioLogsController(IFBioLogs iFBioLogs,IHttpContextAccessor iHttpContextAccessor) 
        {
            _iFBioLogs = iFBioLogs;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Get
        [HttpGet("{id}")]
        public async Task<BioLogs> Get(int id)
        {
            return await _iFBioLogs.Get(id);
        }

        [HttpGet]
        public async Task<List<BioLogs>> GetAll()
        {
            return await _iFBioLogs.GetAll();
        }
        #endregion
    }
}
