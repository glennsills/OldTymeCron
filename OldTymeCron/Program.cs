using OldTymeCron.CronJob.Jobs;
using OldTymeCron.CronJob.Config;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostcontext,services) =>
    {
        var configurationRoot = hostcontext.Configuration;

        services.Configure<Worker1Config>(
            configurationRoot.GetSection(nameof(Worker1Config)));

        services.Configure<Worker2Config>(
            configurationRoot.GetSection(nameof(Worker2Config)));

        services.AddHostedService<Worker1>();     
        services.AddHostedService<Worker2>();
    })
    .Build();

await host.RunAsync();
