using System;
using System.Resources;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SrcFramework.Security.JsonWebToken
{
	public  class JsonWebTokenSettings
	{
		private  static SecurityKey _securityKey;

		public  string Audience => nameof(Audience);

        private  DateTime? _expires;
		public  DateTime Expires
        {
            get
            {
                if (_expires.HasValue)
                {
                    return _expires.Value;
                }
                return DateTime.UtcNow.AddDays(2);
            }
            set => _expires = value;
        }

        public  string Issuer => nameof(Issuer);

	    public static string Key => "EWv6krMhbZGsjmY9aClf"; //=> Guid.NewGuid() + DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);

		public static  SecurityKey SecurityKey => _securityKey ??= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));

		public  SigningCredentials SigningCredentials => new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha512);
	}
}
