using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace zad3klient
{
    internal class Program
    {
        static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:58005/api/persons/1")
            };

            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Role, "authenticated")
            }, "jwt");

            var securityKey = "bounty czy lubie no jest okej mi tam sie podoba nie wiem";
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claimsIdentity,
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var plainToken = tokenHandler.CreateToken(tokenDescriptor);
            var signedToken = tokenHandler.WriteToken(plainToken);
            Console.WriteLine(signedToken);

            request.Headers.Add("jwt_header", signedToken);
            var response = client.SendAsync(request).Result;
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            Console.ReadKey();
        }
    }
}
