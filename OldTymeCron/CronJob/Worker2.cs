using Microsoft.Extensions.Options;
using OldTymeCron.CronJob.Config;

namespace OldTymeCron.CronJob
{
    public class Worker2 : BaseCronJob
    {
        public Worker2(
            ILogger<BaseCronJob> logger,
            IOptions<ApplicationConfig> configuration
        ) :
            base(nameof(Worker2), logger, configuration)
        {
        }

        protected override Task<bool> DoWork(CancellationToken stoppingToken)
        {
            Console.WriteLine("Hello from worker 2");
            return Task.FromResult(true);
        }
    }
}
