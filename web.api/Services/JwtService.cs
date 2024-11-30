using employee.web.api.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace employee.web.api.Services
{
	public static class JwtService
	{
		public static string GenerateToken(UserEntity user, IConfiguration configuration)
		{
			var handler = new JwtSecurityTokenHandler();
			var secret = configuration.GetValue<string>("JwtSettings:SecretString");
			var key = Encoding.UTF8.GetBytes(secret);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>
				{
					new Claim(ClaimTypes.Email, user.Email)
				}),
				Expires = DateTime.UtcNow.AddHours(8),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
			};

			var token = handler.CreateToken(tokenDescriptor);
			return handler.WriteToken(token);
		}
	}
}
