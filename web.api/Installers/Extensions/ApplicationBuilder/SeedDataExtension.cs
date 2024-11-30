using employee.web.api.Contexts;
using employee.web.api.Services;

namespace employee.web.api.Installers.Extensions.ApplicationBuilder
{
	public static class SeedDataExtension
	{
		public static async void Seed(this IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
				await DatabaseSeederService.SeedInitialUser(databaseContext);
			}
		}
	}
}
