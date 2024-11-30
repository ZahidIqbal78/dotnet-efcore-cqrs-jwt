using employee.web.api.Contexts;
using employee.web.api.Installers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace employee.web.api.Installers
{
	public class DatabaseInstaller : IInstaller
	{
		public void InstallServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<DatabaseContext>(optionsBuilder =>
			{
				optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
			});
		}
	}
}
