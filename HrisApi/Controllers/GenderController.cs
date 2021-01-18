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
    public class GenderController : ControllerBase
    {
        private readonly IFGender _iFGender;
        private string loggedUser;

        public GenderController(IFGender iFGender, IHttpContextAccessor iHttpContextAccessor)
        {
            _iFGender = iFGender;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(Gender gender)
        {
            var genderCode = _iFGender.GetCode(gender.GenderCode);

            if (genderCode != null)
            {
                ModelState.AddModelError("GenderCode", genderCode + " is already in use. ");
                return BadRequest(ModelState);
            }

            var createdGender = await _iFGender.Add(loggedUser,gender);
            return CreatedAtAction(nameof(Get), new { id = createdGender.IDNo }, createdGender);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(Gender gender)
        {
            var editGender = await _iFGender.Edit(loggedUser,gender);
            return Ok(editGender);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(Gender gender)
        {
            var deleteGender = await _iFGender.Delete(loggedUser,gender);
            return Ok(deleteGender);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<Gender> Get(int id)
        {
            return await _iFGender.Get(id);
        }

        [HttpGet]
        public async Task<List<Gender>> GetAll()
        {
            return await _iFGender.GetAll();
        }
        #endregion

    }
}
