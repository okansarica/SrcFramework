using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using SrcFramework.Security.JsonWebToken;

namespace SrcFramework.Security.RecoveryToken
{
    public class RecoveryToken : IRecoveryToken
    {
        private const string AUDIENCE = "Recovery";
        private const string ISSUER = "Src";
        private readonly JwtSecurityTokenHandler tokenHandler;

        public RecoveryToken()
        {
            tokenHandler = new JwtSecurityTokenHandler();
        }

        public JwtSecurityToken Decode(string token)
        {
            return tokenHandler.ReadJwtToken(token);
        }

        public string Encode(IEnumerable<Claim> claims, DateTime notBefore, DateTime expires)
        {
            SecurityTokenDescriptor securityTokenDescriptor = GetSecurityTokenDescriptor(notBefore, expires);
            JwtSecurityToken token = tokenHandler.CreateJwtSecurityToken(securityTokenDescriptor);
            token.Payload.AddClaims(claims);
            return tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal Validate(string token)
        {
            TokenValidationParameters validationParameters = GetTokenValidationParameters();
            SecurityToken securityToken;
            return tokenHandler.ValidateToken(token, validationParameters, out securityToken);
        }

        private SecurityTokenDescriptor GetSecurityTokenDescriptor(DateTime notBefore, DateTime expires)
        {
            throw new NotImplementedException();
            //return new SecurityTokenDescriptor
            //{
            //    Audience = AUDIENCE,
            //    IssuedAt = notBefore,
            //    NotBefore = notBefore,
            //    Expires = expires,
            //    Issuer = ISSUER,
            //    SigningCredentials = JsonWebTokenSettings.SigningCredentials
            //};
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            throw new NotImplementedException();
            //return new TokenValidationParameters
            //{
            //    RequireExpirationTime = true,
            //    ValidateLifetime = true,
            //    ValidateIssuer = true,
            //    ValidIssuer = ISSUER,
            //    ValidateAudience = true,
            //    ValidAudience = AUDIENCE,
            //    RequireSignedTokens = true,
            //    IssuerSigningKey = JsonWebTokenSettings.SecurityKey,
            //    ValidateIssuerSigningKey = true
            //};
        }
    }
}
