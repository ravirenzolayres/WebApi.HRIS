using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrisApi.Function.Interface;
using HrisApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CivilStatusController : ControllerBase
    {
        private readonly IFCivilStatus _iFCivilStatus;
        private string loggedUser;

        public CivilStatusController(IFCivilStatus iFCivilStatus, IHttpContextAccessor iHttpContextAccessor)
        {
            _iFCivilStatus = iFCivilStatus;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(CivilStatus civilStatus)
        {
            var civilStatusCode = _iFCivilStatus.GetCode(civilStatus.CivilStatusCode);

            if (civilStatusCode != null)
            {
                ModelState.AddModelError("CivilStatusCode", civilStatusCode + " is already in use. ");
                return BadRequest(ModelState);
            }

            var createdCivilStatus = await _iFCivilStatus.Add(loggedUser,civilStatus);
            return CreatedAtAction(nameof(Get), new { id = createdCivilStatus.IDNo }, createdCivilStatus);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(CivilStatus civilStatus)
        {
            var editCivilStatus = await _iFCivilStatus.Edit(loggedUser,civilStatus);
            return Ok(editCivilStatus);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(CivilStatus civilStatus)
        {
            var deleteCivilStatus = await _iFCivilStatus.Delete(loggedUser,civilStatus);
            return Ok(deleteCivilStatus);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<CivilStatus> Get(int id)
        {
            return await _iFCivilStatus.Get(id);
        }

        [HttpGet]
        public async Task<List<CivilStatus>> GetAll()
        {
            return await _iFCivilStatus.GetAll();
        }
        #endregion
    }
}
