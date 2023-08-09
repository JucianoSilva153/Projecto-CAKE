using System.Security.Cryptography;
using System.Security.Claims;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projecto_Back.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Projecto_Back.Helper
{
    public static class AuthJWT
    {
        public static string GerarToken(Usuario usuario)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var chave = Encoding.ASCII.GetBytes(Settings.Chave);

            var tokenDescritor = new SecurityTokenDescriptor(){
                
                Subject = new ClaimsIdentity(
                    new Claim[]{
                        new Claim(ClaimTypes.Name, usuario.nome),
                        new Claim(ClaimTypes.Role, usuario.tipo)
                    }
                ),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescritor);

            return tokenHandler.WriteToken(token);
        }
    }
}