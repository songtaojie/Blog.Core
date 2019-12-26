using HxCore.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HxCore.Web.Auth
{
    public class JwtToken
    {
        /// <summary>
        /// 获取基于JWT的Token
        /// </summary>
        /// <param name="claims">需要在登陆的时候配置</param>
        /// <param name="permissionRequirement">在startup中定义的参数</param>
        /// <returns></returns>
        public static LoginViewModel BuildJwtToken(List<Claim> claims, PermissionRequirement model)
        {
            var now = DateTime.Now;
            if (claims != null)
            {
                claims.Add(new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(model.Expiration.TotalSeconds).ToString()));
                if (model.Roles!=null && model.Roles.Count>0)
                {
                    claims.AddRange(model.Roles.Select(s => new Claim(ClaimTypes.Role, s)));
                }
            }
            // 实例化JwtSecurityToken
            var jwt = new JwtSecurityToken(
                issuer: model.Issuer,
                audience: model.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(model.Expiration),
                signingCredentials: model.SigningCredentials
            );
            // 生成 Token
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            //打包返回前台
            var responseJson = new LoginViewModel
            {
                Token = encodedJwt,
                Expires = model.Expiration.TotalSeconds,
            };
            return responseJson;
        }
    }
}
