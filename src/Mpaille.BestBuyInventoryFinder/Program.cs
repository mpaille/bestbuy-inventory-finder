using Mpaille.BestBuyInventoryFinder;
using Mpaille.BestBuyInventoryFinder.Domain;
using Mpaille.BestBuyInventoryFinder.Infrastructure;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var applicationSettings = context.Configuration.Get<ApplicationSettings>();

        services.AddHostedService<Worker>();
        services.AddInfrastructure(applicationSettings);
    })
    .Build();

await host.RunAsync();
