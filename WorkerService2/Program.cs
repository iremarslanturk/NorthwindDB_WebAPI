using WorkerService2;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    }).UseWindowsService()
    .Build();

host.Run();
