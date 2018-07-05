using BussinessContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace FakeMoodle.Authorization
{
    public class AuthenticationFilter : Attribute, IAuthenticationFilter
    {
        private IAuthService authService;

        public bool AllowMultiple => true;

        public AuthenticationFilter(IAuthService authService)
        {
            this.authService = authService;
        }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;
            if (authorization == null)
            {
                return;
            }

            if (String.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing credentials", request);
                return;
            }

            var existing = authService.ValidateToken(authorization.Parameter);

            if (existing == null || !existing.Status)
            {

                context.ErrorResult = new AuthenticationFailureResult("Invalid token", request);
                return;
            }
            var role = existing.Role == 0 ? "Admin" : null;
            role = existing.Role == 1 ? "Manager" : role;
            role = existing.Role == 2 ? "Admin" : role;
            string[] roles = { role};
            IPrincipal principal = new CustomPrincipal(new GenericIdentity(existing.Name), roles, existing);
            context.Principal = principal;
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
        }
    }
}
