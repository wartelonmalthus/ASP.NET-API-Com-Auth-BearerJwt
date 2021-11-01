using ApiAuth.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer ;
using Microsoft.AspNetCore.Authentication.JwtBearer ;
using Services.TokenService;



namespace ApiAuth.Controllers


{

    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        [Route(template:"login")]
        public async Task<ActionResult<dynamic>> AsyncAuthenticate ( [FromBody] User model ){

            var user = UserRepository.Get(model.Username , model.Password);

            //VERIFICACAO
            if(user == null)
                return NotFound(new{
                message = "Usuário ou senha inválida"
                });

            //Gerar Token
            var token = TokenService.GenerateToken(user);

            //ocultando senha 
            user.Password = "";


            //retorna dados 
            return new
             {
                 user = user,
                 token = token
            };

        }

        
    }
}