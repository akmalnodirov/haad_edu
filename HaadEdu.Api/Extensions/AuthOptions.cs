using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HaadEdu.Api.Extensions;

public class AuthOptions
{
    public const string ISSUER = "MyAuthServer";
    public const string AUDIENCE = "MyAuthClient";
    const string KEY = "mysupersecret_secretkey!123hellobaby";
    public const int LIFETIME = 1;
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new(Encoding.UTF8.GetBytes(KEY));
}
