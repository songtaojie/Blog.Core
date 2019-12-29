using HxCore.Common;
using HxCore.Model.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HxCore.Web.Auth
{
    /// <summary>
    /// jwt的帮助类
    /// </summary>
    public class JwtHelper
    {

        /// <summary>
        /// 获取基于JWT的Token
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public static LoginViewModel BuildJwtToken(JwtModel model)
        {
            JwtSettings settings = AppSettings.Get<JwtSettings>("JwtSettings");
            var now = DateTime.Now;
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, model.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, model.UserId),
                new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(model.Expiration.TotalSeconds).ToString()),
                new Claim(JwtRegisteredClaimNames.Iss,settings.Issuer),
                new Claim(JwtRegisteredClaimNames.Aud,settings.Audience)
            };
            if (!string.IsNullOrEmpty(model.Role))
            {
                claims.AddRange(model.Role.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));
            }
            // 实例化JwtSecurityToken
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                issuer: settings.Issuer,
                audience: settings.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(model.Expiration),
                signingCredentials: creds
            );
            // 生成 Token
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            //打包返回前台
            var responseJson = new LoginViewModel
            {
                UserId = model.UserId,
                UserName = model.UserName,
                Token = encodedJwt,
                Expires = model.Expiration.TotalSeconds,
            };
            return responseJson;
        }

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
                new Claim(JwtRegisteredClaimNames.Jti,model.UserId),
                new Claim(JwtRegisteredClaimNames.Iat,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                //这个就是过期时间，目前是过期1000秒，可自定义，注意JWT有自己的缓冲过期时间
                new Claim(JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddSeconds(120)).ToUnixTimeSeconds()}"),
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
                model.UserId = jwtToken.Id;
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
