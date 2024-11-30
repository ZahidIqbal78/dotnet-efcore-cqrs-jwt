using employee.web.api.Installers.Interfaces;

namespace employee.web.api.Installers
{
	public class MediatorInstaller : IInstaller
	{
		public void InstallServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddMediatR(config =>
			{
				config.RegisterServicesFromAssembly(typeof(Program).Assembly);
			});
		}
	}
}
