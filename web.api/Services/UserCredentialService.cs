using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace employee.web.api.Services
{
	public static class UserCredentialService
	{
		public static string HashPassword(string password)
		{
			byte[] salt = new byte[16];
			var randomNumberGenerator = RandomNumberGenerator.Create();
			randomNumberGenerator.GetBytes(salt);

			string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password, salt,KeyDerivationPrf.HMACSHA256, 10000, 32)
				);
			return Convert.ToBase64String(salt) + "." + hash;
		}

		public static bool VerifyPassword(string password, string hashPassword)
		{
			var hashParts = hashPassword.Split(".", 2);
			if (hashParts.Length != 2)
			{
				return false;
			}

			var salt = Convert.FromBase64String(hashParts[0]);
			var hash = hashParts[1];

			var verifiedHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password, salt, KeyDerivationPrf.HMACSHA256, 10000, 32));

			return hash == verifiedHash;
		}
	}
}
