using System.Security.Claims;
using System.Threading.Tasks;
using IdentityWithoutEF.Models;
using Microsoft.AspNet.Identity;

namespace IdentityWithoutEF
{
    public class ExampleUserPrincipalFactory : IUserClaimsPrincipalFactory<ApplicationUser>
    {
        public Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            ClaimsIdentity identity = new ClaimsIdentity("Microsoft.AspNet.Identity.Application");
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserId));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            return Task.FromResult(principal);
        }
    }
}
