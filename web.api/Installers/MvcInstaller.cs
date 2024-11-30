using employee.web.api.Installers.Interfaces;

namespace employee.web.api.Installers
{
	public class MvcInstaller : IInstaller
	{
		public void InstallServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddControllers();
		}
	}
}
