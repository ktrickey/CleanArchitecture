using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Exceptions;

namespace CleanArchitecture.Web
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog((builderContext, loggerConfig) =>
                {
                    loggerConfig
                        .ReadFrom.Configuration(builderContext.Configuration)
                        .Enrich.FromLogContext()
                        .Enrich.WithExceptionDetails();
                });
    }
}