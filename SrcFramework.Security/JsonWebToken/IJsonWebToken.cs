using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace SrcFramework.Security.JsonWebToken
{
	public interface IJsonWebToken
	{
		TokenValidationParameters TokenValidationParameters { get; }
		
		//TODO kullanilmiyor ama development icin gerekebilir
	    bool IsDevelopment { get; set; }

	    JwtSecurityToken BuildToken(string sub, string[] roles=null);

	    Dictionary<string, object> Decode(string token);

	    JwtSecurityToken DecodeSecurityToken(string token);

		string Encode(JwtSecurityToken token);
	}
}
