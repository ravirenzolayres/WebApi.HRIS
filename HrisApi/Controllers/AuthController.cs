using HrisApi.Function.JWTManager;
using HrisApi.Model.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtManager _iJwtManager;

        public AuthController(IJwtManager iJwtManager)
        {
            _iJwtManager = iJwtManager;
        }

        #region Authenticate User
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Auth(UserCredential userCredential)
        {
            var token = await _iJwtManager.Authenticate(userCredential);

            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
        #endregion

    }
}
