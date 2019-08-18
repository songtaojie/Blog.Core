using HxCore.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Auth
{
    public class JwtHelper
    {
        /// <summary>
        /// 颁发jwt字符串
        /// </summary>
        /// <param name="model">jwt实体类</param>
        /// <returns>token字符串</returns>
        public static string IssueJwt(JwtModel model)
        {
            JwtSettings settings = AppSettings.Get<JwtSettings>("JwtSettings");
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,model.Uid.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                //这个就是过期时间，目前是过期1000秒，可自定义，注意JWT有自己的缓冲过期时间
                new Claim(JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddHours(2)).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Iss,settings.Issuer),
                new Claim(JwtRegisteredClaimNames.Aud,settings.Audience)
            };
            if (!string.IsNullOrEmpty(model.Role))
            {
                claims.AddRange(model.Role.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                issuer: settings.Issuer,
                claims:claims,
                //expires:DateTime.Now.AddMinutes(2),
                signingCredentials: creds
                );
            var jwtHandler = new JwtSecurityTokenHandler();
            return jwtHandler.WriteToken(jwt);
        }

        /// <summary>
        /// 序列化jwt字符串
        /// </summary>
        /// <param name="jwtStr">jwt字符串</param>
        /// <returns>序列化后的jwt实体类</returns>
        public static JwtModel SerializeJwt(string jwtStr)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = handler.ReadJwtToken(jwtStr);
            JwtModel model = new JwtModel();
            try
            {
                jwtToken.Payload.TryGetValue(ClaimTypes.Role, out object role);
                model.Uid = Convert.ToInt64(jwtToken.Id);
                model.Role = role.ToString();
            }
            catch
            {
                throw;
            }
            return model;
        }
    }
}
