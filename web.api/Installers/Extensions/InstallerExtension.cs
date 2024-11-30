using employee.web.api.Installers.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace employee.web.api.Installers.Extensions
{
	public static class InstallerExtension
	{
		public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
		{
			typeof(Program).Assembly.ExportedTypes
				.Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
				.Select(Activator.CreateInstance)
				.Cast<IInstaller>()
				.ToList()
				.ForEach(i => i.InstallServices(services, configuration));
		}
	}
}
