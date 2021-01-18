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
    public class UserAccessController : ControllerBase
    {
        private readonly IFUserAccess _iFUserAccess;
        private string loggedUser;

        public UserAccessController(IFUserAccess iFUserAccess, IHttpContextAccessor iHttpContextAccessor)
        {
            _iFUserAccess = iFUserAccess;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(UserAccess userAccess)
        {
            var createdUserAccess = await _iFUserAccess.Add(loggedUser,userAccess);
            return CreatedAtAction(nameof(Get), new { id = createdUserAccess.IDNo }, createdUserAccess);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(UserAccess userAccess)
        {
            var editUserAccess = await _iFUserAccess.Edit(loggedUser,userAccess);
            return Ok(editUserAccess);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<UserAccess> Get(int id)
        {
            return await _iFUserAccess.Get(id);
        }

        [HttpGet]
        public async Task<List<UserAccess>> GetAll()
        {
            return await _iFUserAccess.GetAll();
        }
        #endregion
    }
}
