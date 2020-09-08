using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;
using Senai.Senatur.WebApi.ViewModels;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuariosRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="login">Email e Senha</param>
        /// <returns>Login de usuário</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModels login)
        {
            Usuario usuariosBuscado = _usuarioRepository.BuscarSenhaEmail(login.Email, login.Senha);
        
            if(usuariosBuscado == null)
            {
                return StatusCode(404, "E-mail ou senha inválido!");
            }

            // Criando as claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuariosBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuariosBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuariosBuscado.IdTipoUsuario.ToString())
            };

            // Criando a chave
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senatur-key-autenticate"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Criando o token
            var token = new JwtSecurityToken(
                issuer: "Senatur.WebApi",
                audience: "Senatur.WebApi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}