using Microsoft.Extensions.Hosting;
using Worker_Service;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddHttpClient();
    }).UseWindowsService()
.Build();

host.Run();
