using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(ConfigureServices)
    .Build();

await host.RunAsync();

static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
{
    services.Add(new ServiceDescriptor(typeof(IApplicationBootstrapper), typeof(ApplicationBootstrapper), ServiceLifetime.Scoped));
    services.AddHostedService<RunApplicationHostedService<IApplicationBootstrapper>>();
}