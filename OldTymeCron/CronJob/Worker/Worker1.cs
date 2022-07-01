using Microsoft.Extensions.Options;
using OldTymeCron.CronJob.Config;

namespace OldTymeCron.CronJob.Worker
{
    public class Worker1 : BaseCronWorker
    {
        private readonly IOptions<Worker1Config> _configuration;

        public Worker1(
            ILogger<BaseCronWorker> logger,
            IOptions<Worker1Config> configuration
        ) :
            base(nameof(Worker1), logger, configuration.Value.Schedule)
        {
            ArgumentNullException.ThrowIfNull (configuration);

            _configuration = configuration;
        }

        protected override Task<bool> DoWork(CancellationToken stoppingToken)
        {
            Console.WriteLine("Hello from worker 1");
            return Task.FromResult(true);
        }
    }
}
