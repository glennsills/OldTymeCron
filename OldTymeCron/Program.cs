using OldTymeCron.CronJob;
using OldTymeCron.CronJob.Config;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostcontext,services) =>
    {
        var configurationRoot = hostcontext.Configuration;
        services.Configure<ApplicationConfig>(
            configurationRoot.GetSection(nameof(ApplicationConfig)));

        services.AddHostedService<Worker1>();
        services.AddHostedService<Worker2>();
    })
    .Build();

await host.RunAsync();
