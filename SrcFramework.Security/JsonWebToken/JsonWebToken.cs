using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace SrcFramework.Security.JsonWebToken
{
    public class JsonWebToken : IJsonWebToken
    {
        public bool IsDevelopment { get; set; }

        //public TokenValidationParameters TokenValidationParameters =>
        //    new TokenValidationParameters
        //    {
        //        IssuerSigningKey = JsonWebTokenSettings.SecurityKey,
        //        ValidateActor = true,
        //        ValidateAudience = true,
        //        ValidateIssuerSigningKey = true,
        //        ValidateLifetime = true,
        //        ValidAudience = JsonWebTokenSettings.Audience,
        //        ValidIssuer = JsonWebTokenSettings.Issuer
        //    };

        public Dictionary<string, object> Decode(string token)
        {
            return DecodeSecurityToken(token)
                .Payload;
        }

        public JwtSecurityToken DecodeSecurityToken(string token)
        {
            return new JwtSecurityTokenHandler().ReadJwtToken(token);
        }

        public JwtSecurityToken BuildToken(string sub, JsonWebTokenSettings jsonWebTokenSettings, string[] roles=null)
        {
            var claims = new List<Claim>();
            claims.AddJti();
            claims.AddSub(sub);
            if (roles != null && roles.Length > 0)
            {
                claims.AddRoles(roles);
            }

            return GetJwtSecurityToken(claims,jsonWebTokenSettings);
        }

        public string Encode(JwtSecurityToken token)
        {
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static JwtSecurityToken GetJwtSecurityToken(IEnumerable<Claim> claims, JsonWebTokenSettings jsonWebTokenSettings)
        {
            return new JwtSecurityToken(
                jsonWebTokenSettings.Issuer,
                jsonWebTokenSettings.Audience,
                claims,
                DateTime.UtcNow,
                jsonWebTokenSettings.Expires,
                jsonWebTokenSettings.SigningCredentials
            );
        }
    }
}