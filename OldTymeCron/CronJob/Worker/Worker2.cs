using Microsoft.Extensions.Options;
using OldTymeCron.CronJob.Config;

namespace OldTymeCron.CronJob.Worker
{
    public class Worker2 : BaseCronWorker
    {
        private readonly IOptions<Worker2Config> _configuration;

        public Worker2(
            ILogger<BaseCronWorker> logger,
            IOptions<Worker2Config> configuration
        ) :
            base(configuration.Value.Name, logger, configuration.Value.Schedule)
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
