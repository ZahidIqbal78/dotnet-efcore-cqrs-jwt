using employee.web.api.Installers.Extensions;
using employee.web.api.Installers.Extensions.ApplicationBuilder;
using Serilog;

namespace employee.web.api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.Seq("http://localhost:5431")
            .CreateLogger();
        builder.Host.UseSerilog();

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.InstallServicesInAssembly(builder.Configuration);

		var app = builder.Build();

        // Configure the HTTP request pipeline.
        // TODO: move to an application builder extension.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1."));
        }

        //app.UseHttpsRedirection();
        app.UseSerilogRequestLogging();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapGet("/", context =>
        {
            return context.Response.WriteAsync("Hello from employee tracker.");
        });

        app.MapControllers();

        app.Seed();

        app.Run();
    }
}