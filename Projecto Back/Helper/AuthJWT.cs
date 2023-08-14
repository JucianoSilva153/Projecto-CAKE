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
using Projecto_Front.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Projecto_Back.Helper
{
    public static class AuthJWT
    {


        public static string GerarToken(Usuario usuario, DataContext data)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var chave = Encoding.ASCII.GetBytes(Settings.Chave);

            var token = tokenHandler.CreateToken(TokenDecriptor(chave, usuario, data));

            return tokenHandler.WriteToken(token);
        }

        private static SecurityTokenDescriptor TokenDecriptor(byte[] chave, Usuario usuario, DataContext data)
        {
            var usuarioCliente = data.Clientes
                                .Include(c => c.usuario)
                                .FirstOrDefault(u => u.usuario == usuario);
            string UsuarioEmail = "";
            int UsuarioContacto = 0;
            int CountContacto = 0;
            bool ContactoValido = false;

            if (!(usuarioCliente is null))
            {
                UsuarioEmail = usuarioCliente.email;

                UsuarioContacto = usuarioCliente.contacto;
                CountContacto = usuarioCliente.contacto.ToString().Count();
                ContactoValido = CountContacto == 9;
            }

            var tokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]{
                        new Claim(ClaimTypes.Name, usuario.nome),
                        new Claim(ClaimTypes.Email, UsuarioEmail != string.Empty ? UsuarioEmail : ""),
                        new Claim(ClaimTypes.MobilePhone, ContactoValido ? UsuarioContacto.ToString() : ""),
                        new Claim(ClaimTypes.Role, usuario.tipo)
                    }
                ),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenDescritor;
        }
    }
}