using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotzAPI.Modelos;
using Microsoft.IdentityModel.Tokens;

namespace DotzAPI.Servicos
{
    public static class TokenServico
    {
        public static string GerarToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var chavePrivada = Encoding.ASCII.GetBytes(Configuracoes.ChavePrivada);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email.ToString()),
                    new Claim("UsuarioId", usuario.UsuarioId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials (
                    new SymmetricSecurityKey(chavePrivada),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
