using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.ServiceModel.Security.Tokens;

namespace Base.SinglePageApplication.Infrastructure
{
    public class TokenManager
    {

        public static string CreateJwtToken(string userName, string role)
        {
            var claimList = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role)     
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = ConfigurationManager.AppSettings["app:secretKey"];
            var sSKey = new InMemorySymmetricSecurityKey(GetBytes(secretKey));

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                issuer: "http://issuer.com",
                audience: "http://mysite.com",
                claims: new List<Claim>() {new Claim(ClaimTypes.Name, "Andras Nemes")},
                notBefore: null,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(sSKey,
                    "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256",
                    "http://www.w3.org/2001/04/xmlenc#sha256")
                );

            return tokenHandler.WriteToken(jwtToken);
        }

        public static ClaimsPrincipal ValidateJwtToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            TokenValidationParameters validationParams = new TokenValidationParameters()
                {
                    ValidAudience = "demoApp",
                    ValidIssuer = "demoApp",
                    ValidateIssuer = true,
                    IssuerSigningToken = new BinarySecretSecurityToken(GetBytes("ThisIsAnImportantStringAndIHaveNoIdeaIfThisIsVerySecureOrNot!"))
                };

            SecurityToken validatedToken;
             var claimPrincipal = tokenHandler.ValidateToken(jwtToken, validationParams, out validatedToken);
            return claimPrincipal;
        }

        private static SecurityTokenDescriptor GetSecurityTokenDescriptor(InMemorySymmetricSecurityKey sSKey, List<Claim> claimList, string username)
        {
            var now = DateTime.UtcNow;
            Claim[] claims = claimList.ToArray();
            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                TokenIssuerName = "demoApp",
                AppliesToAddress = "demoApp",
                Lifetime = new Lifetime(now, now.AddMinutes(30)),
                SigningCredentials = new SigningCredentials(sSKey,
                    "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256",
                    "http://www.w3.org/2001/04/xmlenc#sha256"),                
            };
        }
        private static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;

        }

    }
}