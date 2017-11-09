using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BookAndLearn.DataAccess.Repositories;
using Microsoft.Owin.Security.OAuth;

namespace BookAndLearn.API
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (var userRepository = new UserRepository())
            {
                var identityUser = await userRepository.FindUser(context.UserName, context.Password);

                if (identityUser == null)
                {
                    context.SetError("invalid_grant", "Username or/and password is incorrect");
                    return;
                }
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaims(new List<Claim>
            {
                new Claim("sub", context.UserName),
                new Claim("role", "user")
            });

            context.Validated(identity);
        }
    }
}
