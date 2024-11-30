using employee.web.api.Contexts;
using employee.web.api.Entities;

namespace employee.web.api.Services
{
	public static class DatabaseSeederService
	{
		public static async Task SeedInitialUser(DatabaseContext context)
		{
			if (!context.Users.Any())
			{
				var initialUser = new UserEntity
				{
					Id = Guid.NewGuid(),
					Email = "admin@email.com",
					PasswordHash = UserCredentialService.HashPassword("Abcd@1234"),
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					Remarks = "Default user created. Should be deleted after creating another admin user."
				};

				context.Users.Add(initialUser);
				await context.SaveChangesAsync();
			}
		}
	}
}
