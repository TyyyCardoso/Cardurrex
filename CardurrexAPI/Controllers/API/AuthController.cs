using CardurrexAPI.Data;
using CardurrexAPI.Data.Beans;
using CardurrexAPI.Data.Beans.Requests;
using CardurrexAPI.Data.Beans.Responses;
using CardurrexAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CardurrexAPI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;

        public AuthController(UserManager<Users> userManager,
            SignInManager<Users> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///  Método para fazer login na aplicação, são recebidos vários parâmetros e validados
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginRequest loginRequest)
        {
            ResponseBean response = new ResponseBean();
            LoginResponse loginResponse = new LoginResponse();

            var user = await _userManager.FindByEmailAsync(loginRequest.Email);

            if (user != null)
            {
                PasswordVerificationResult passWorks = new PasswordHasher<Users>().VerifyHashedPassword(null, user.PasswordHash, loginRequest.Password);
                if (passWorks.Equals(PasswordVerificationResult.Success))
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    response.SetSuccessResponse();
                    response.SetPayDataObject(loginResponse);
                    return Ok(response);
                }
            }

            response.SetErrorResponse();
            return Ok();
        }
    }
}
