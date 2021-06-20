using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Internship.Web.Configuration
{
    public static class AuthenticationConfiguration
    {
        public const string Issuer = "Internship-System-Backend";

        public const string Audience = "Internship-System-Frontend";

        const string Key = "SomePseudoRandomSymmetricalKey";

        public const int Lifetime = 60;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
