using OldTymeCron.CronJob.Config;
using OldTymeCron.CronJob.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostcontext,services) =>
    {
        var configurationRoot = hostcontext.Configuration;

        services.Configure<TopNewsJobConfig>(
            configurationRoot.GetSection(nameof(TopNewsJobConfig)));

        services.AddHostedService<TopNewsJob>();
    })
    .Build();

await host.RunAsync();
