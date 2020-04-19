using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SrcFramework.Security.RecoveryToken
{
    public interface IRecoveryToken
    {
        string Encode(IEnumerable<Claim> claims, DateTime notBefore, DateTime expires);

        JwtSecurityToken Decode(string token);

        ClaimsPrincipal Validate(string token);
    }
}
