using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrisApi.Function.Interface;
using HrisApi.Function.JWTManager;
using HrisApi.Model;
using HrisApi.Model.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IFUser _iFUser;
        private string loggedUser;

        public UserController(IFUser iFUser,IHttpContextAccessor iHttpContextAccessor)
        {
            _iFUser = iFUser;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            var username = _iFUser.GetCode(user.Username);

            if (username != null)
            {
                ModelState.AddModelError("Username", username + " is already in use. ");
                return BadRequest(ModelState);
            }

            var createdUser = await _iFUser.Add(loggedUser, user);
            return CreatedAtAction(nameof(Get), new { id = createdUser.IDNo }, createdUser);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(User user)
        {
            var editUser = await _iFUser.Edit(loggedUser, user);
            return Ok(editUser);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(User user)
        {
            var deleteUser = await _iFUser.Delete(loggedUser, user);
            return Ok(deleteUser);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _iFUser.Get(id);
        }

        [HttpGet]
        public async Task<List<User>> GetAll()
        {
            return await _iFUser.GetAll();
        }
        #endregion

    }
}
