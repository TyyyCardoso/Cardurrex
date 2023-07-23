using CardurrexAPI.Data;
using CardurrexAPI.Data.Beans;
using CardurrexAPI.Data.Beans.Requests;
using CardurrexAPI.Data.Beans.Responses;
using CardurrexAPI.Models;
using CardurrexAPI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CardurrexAPI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;

        public AuthController(UserManager<Users> userManager,
            SignInManager<Users> signInManager, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;

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
            //Iniciados objetos de resposta
            var responseBean = new ResponseBean();
            var loginResponse = new LoginResponse();

            //Valida se o utilizador realmente existe
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);

            if (user != null)
            {
                //Verifica a password com a hashed em BD
                PasswordVerificationResult passWorks = new PasswordHasher<Users>().VerifyHashedPassword(null, user.PasswordHash, loginRequest.Password);
                if (passWorks.Equals(PasswordVerificationResult.Success))
                {
                    //Efetua o login do utilizador
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    loginResponse.UserInfo = user;
                    responseBean.SetSuccessResponseWithMessage("SUCCESS_LOGIN");
                    responseBean.SetPayDataObject(loginResponse);
                    return Ok(responseBean);
                }
            }

            //Aconteceu algum erro ao fazer login
            responseBean.SetErrorResponse();
            return Ok(responseBean);
        }

        /// <summary>
        /// Método para criar uma conta na aplicação
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("createAccount")]
        public async Task<ActionResult> Register(RegisterRequest registerRequest)
        {
            ResponseBean responseBean = new ResponseBean();
            RegisterResponse registerResponse = new RegisterResponse();

            // Cria o objeto do utilizador
            var user = new Users
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Email,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,   
                Gender = registerRequest.Gender,
                PhoneNumber = registerRequest.PhoneNumber,
                BirthDate = DateTime.Parse(registerRequest.BirthDate),
                CreatedDate = DateTime.Now,
                LastLoginDate = DateTime.Now,
            };
            //Obter a imagem e dar upload da mesma
            byte[] imageBytes = ImageUtils.Base64StringToByteArray(registerRequest.ProfilePicture);
            String imageName = ImageUtils.SaveImageToServer(imageBytes, _webHostEnvironment.WebRootPath);
            if (imageName != null) //imagem foi uploaded com sucesso
            {
                user.ProfilePicture = imageName;
            }
            else
            {
                //Erro de upload de imagem
            }

            // Criar o utilizador
            var result = await _userManager.CreateAsync(user, registerRequest.Password);
            if (result.Succeeded)
            {
                //Realizar o login do cliente acabado de criar
                await _signInManager.SignInAsync(user, isPersistent: false);
                registerResponse.UserInfo = user;
                responseBean.SetSuccessResponseWithMessage("SUCCESS_REGISTER");
                responseBean.SetPayDataObject(registerResponse);
                return Ok(responseBean);
            }
            else
            {
                //Eliminar imagem do servidor caso aconteca algum erro com a criação de conta
                ImageUtils.DeleteImageFromServer(user.ProfilePicture, _webHostEnvironment.WebRootPath);
                responseBean.SetErrorResponse();
                return Ok(responseBean);
            }
        }

        /// <summary>
        /// Método para efetuar o logout de um utilizador
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("logout")]
        public async Task<ActionResult> Logout()
        {
            ResponseBean responseBean = new ResponseBean();
            responseBean.SetSuccessResponse();
            await _signInManager.SignOutAsync();
            return Ok(responseBean);
        }

    }
}
