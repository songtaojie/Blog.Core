using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog.IdentityServer.Authorization
{
    public class UserClaimsPrincipal : IUserClaimsPrincipalFactory<IdentityUser>
    {
        //private readonly IUserStoreService _storeService;
        //public UserClaimsPrincipal(IUserStoreService storeService)
        //{
        //    _storeService = storeService;
        //}
        public async Task<ClaimsPrincipal> CreateAsync(IdentityUser user)
        {
            //var claims = await _storeService.GetAllClaimsByUser(user);
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new List<Claim>());
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return await Task.FromResult(claimsPrincipal);

        }
    }
}
