using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RSBrasil.Model.Entidades;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RSBrasil.API.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {

        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SolicitaToken([FromBody] Login request)
        {
            if (request.Usuario == "catedrall" && request.Senha == "just4Fun$")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Usuario)
                };

                /*ClaimsIdentity identity = new ClaimsIdentity
                    (
                        new GenericIdentity(request.Usuario, "Login"),
                        new[]
                        {
                            new Claim("Menu","admin"),
                            new Claim("Data", DateTime.Now.ToString("dd/MM/yyyy"))
                        }
                    );*/

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                        issuer: "RSBrasilServicos",
                        audience: "RSBrasilServicos",
                        expires: DateTime.Now.AddMinutes(30),
                        claims: claims,
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return BadRequest("Credenciais inválidas...");
        }
    }
}