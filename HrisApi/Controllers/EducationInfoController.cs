using System;
using System.Collections.Generic;
using System.Linq;
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
    public class EducationInfoController : ControllerBase
    {
        private readonly IFEducationInfo _iFEducationInfo;
        private string loggedUser;

        public EducationInfoController(IFEducationInfo iFEducationInfo, IHttpContextAccessor iHttpContextAccessor)
        {
            _iFEducationInfo = iFEducationInfo;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(EducationInfo educationInfo)
        {
            var createdEducationInfo = await _iFEducationInfo.Add(loggedUser,educationInfo);
            return CreatedAtAction(nameof(Get), new { id = createdEducationInfo.IDNo }, createdEducationInfo);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult >Edit(EducationInfo educationInfo)
        {
            var editEductionInfo = await _iFEducationInfo.Edit(loggedUser,educationInfo);
            return Ok(editEductionInfo);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<EducationInfo> Get(int id)
        {
            return await _iFEducationInfo.Get(id);
        }

        [HttpGet]
        public async Task<List<EducationInfo>> GetAll()
        {
            return await _iFEducationInfo.GetAll();
        }
        #endregion
    }
}
