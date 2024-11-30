using Asp.Versioning;
using employee.web.api.Installers.Interfaces;

namespace employee.web.api.Installers
{
	public class ApiVersioningInstaller : IInstaller
	{
		public void InstallServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddApiVersioning(options =>
			{
				options.DefaultApiVersion = new ApiVersion(1, 0);
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.ReportApiVersions = true;
			});
		}
	}
}
