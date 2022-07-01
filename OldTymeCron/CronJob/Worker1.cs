using Microsoft.Extensions.Options;
using OldTymeCron.CronJob.Config;

namespace OldTymeCron.CronJob
{
    public class Worker1 : BaseCronJob
    {
        public Worker1(
            ILogger<BaseCronJob> logger,
            IOptions<ApplicationConfig> configuration
        ) :
            base(nameof(Worker1), logger, configuration)
        {
        }

        protected override Task<bool> DoWork(CancellationToken stoppingToken)
        {
            Console.WriteLine("Hello from worker 1");
            return Task.FromResult(true);
        }
    }
}
