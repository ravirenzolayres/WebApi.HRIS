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
    public class AccessController : ControllerBase
    {
        private readonly IFAccess _iFAccess;
        private string loggedUser;

        public AccessController(IFAccess iFAccess,IHttpContextAccessor iHttpContextAccessor) 
        {
            _iFAccess = iFAccess;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(Access access)
        {
            var accessCode = _iFAccess.GetCode(access.AccessCode);

            if (accessCode != null)
            {
                ModelState.AddModelError("AccessCode", accessCode + " is already in use. ");
                return BadRequest(ModelState);
            }

            var createdAccess = await _iFAccess.Add(loggedUser, access);
            return CreatedAtAction(nameof(Get), new { id = createdAccess.IDNo }, createdAccess);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(Access access)
        {
            var editAccess = await _iFAccess.Edit(loggedUser, access);
            return Ok(editAccess);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(Access access)
        {
            var deleteAccess = await _iFAccess.Delete(loggedUser, access);
            return Ok(deleteAccess);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<Access> Get(int id)
        {
            return await _iFAccess.Get(id);
        }

        [HttpGet]
        public async Task<List<Access>> GetAll()
        {
            return await _iFAccess.GetAll();
        }
        #endregion
    }
}
