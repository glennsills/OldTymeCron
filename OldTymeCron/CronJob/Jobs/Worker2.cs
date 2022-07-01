using Microsoft.Extensions.Options;
using OldTymeCron.CronJob.Config;

namespace OldTymeCron.CronJob.Jobs
{
    public class Worker2 : BaseCronJob
    {
        private readonly IOptions<Worker2Config> _configuration;

        public Worker2(
            ILogger<BaseCronJob> logger,
            IOptions<Worker2Config> configuration
        ) :
            base(nameof(Worker2), logger, configuration.Value.Schedule)
        {
            ArgumentNullException.ThrowIfNull (logger);

            _configuration = configuration;
        }

        protected override Task<bool> DoWork(CancellationToken stoppingToken)
        {
            Console.WriteLine("Hello from worker 2");
            return Task.FromResult(true);
        }
    }
}
