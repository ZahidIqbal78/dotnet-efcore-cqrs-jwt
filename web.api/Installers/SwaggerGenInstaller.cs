using employee.web.api.Installers.Interfaces;
using Microsoft.OpenApi.Models;

namespace employee.web.api.Installers
{
	public class SwaggerGenInstaller : IInstaller
	{
		public void InstallServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc(
					"v1",
					new Microsoft.OpenApi.Models.OpenApiInfo
					{
						Title = "Employee API",
						Version = "v1",
					}
				);
				options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{ 
					In = ParameterLocation.Header,
					Description = "Enter bearer token.",
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					BearerFormat = "JWT",
					Scheme = "bearer"
				});
				options.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{new OpenApiSecurityScheme{Reference = new OpenApiReference
					{
						Id = "Bearer",
						Type = ReferenceType.SecurityScheme
					}}, 
					new List<string>()}
				});
			});
		}
	}
}
