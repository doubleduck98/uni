using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace zad3
{
    public class JWTAuthenticationFilter : Attribute, IAuthenticationFilter
    {
        private const string _headerName = "jwt_header";
        private static readonly string _secret = "bounty czy lubie no jest okej mi tam sie podoba nie wiem";
        private readonly TokenValidationParameters _vazlidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret))
        };
        private readonly JwtSecurityTokenHandler _handler = new JwtSecurityTokenHandler();

        public bool AllowMultiple => true;

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            if (context.Request.Headers.TryGetValues(_headerName, out IEnumerable<string> headers))
            {
                var token = headers.FirstOrDefault();
                if (token != null)
                {
                    try
                    {
                        var validatedPrincipal = _handler.ValidateToken(token, _vazlidationParameters, out SecurityToken outToken);
                        if (validatedPrincipal.IsInRole("authenticated"))
                        {
                            return Task.FromResult(true);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e.Message);
                    }
                }
            }

            context.ErrorResult =
                new ResponseMessageResult(
                    context.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Nieautoryzowany dostęp."));
            return Task.FromResult(0);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}