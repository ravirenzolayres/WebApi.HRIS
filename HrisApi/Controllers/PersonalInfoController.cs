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
    public class PersonalInfoController : ControllerBase
    {
        private readonly IFPersonalInfo _iFPersonalInfo;
        private string loggedUser;

        public PersonalInfoController(IFPersonalInfo iFPersonalInfo, IHttpContextAccessor iHttpContextAccessor)
        {
            _iFPersonalInfo = iFPersonalInfo;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(PersonalInfo personalInfo)
        {
            var createdPersonalInfo = await _iFPersonalInfo.Add(loggedUser,personalInfo);
            return CreatedAtAction(nameof(Get), new { id = createdPersonalInfo.IDNo }, createdPersonalInfo);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(PersonalInfo personalInfo)
        {
            var editPersonalInfo = await _iFPersonalInfo.Edit(loggedUser,personalInfo);
            return Ok(editPersonalInfo);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<PersonalInfo> Get(int id)
        {
            return await _iFPersonalInfo.Get(id);
        }
        #endregion
    }
}
