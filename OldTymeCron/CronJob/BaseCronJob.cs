
using OldTymeCron.CronJob.Config;
using Microsoft.Extensions.Options;
using Cronos;

namespace OldTymeCron.CronJob;

public abstract class BaseCronJob : BackgroundService
{
    protected readonly ILogger<BaseCronJob> _logger;
    protected readonly ApplicationConfig _configuration;
    protected readonly string _name;

    public BaseCronJob(string name, ILogger<BaseCronJob> logger, IOptions<ApplicationConfig> configuration)
        {
            _logger = logger;
            _configuration = configuration.Value;
            _name = name;
        }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation($"Background Task {_name} initializing");

        var taskConfiguration = _configuration.GetConfigForName(_name);
        CronExpression expression = CronExpression.Parse(taskConfiguration.Schedule, CronFormat.Standard);

        for (DateTime? nextOccurance = expression.GetNextOccurrence(DateTime.UtcNow, inclusive:true);
        nextOccurance.HasValue;
        nextOccurance = expression.GetNextOccurrence(DateTime.UtcNow, inclusive:true))
        {
            bool continueRunning = await ScheduleJob(nextOccurance.Value, stoppingToken);
        }  

        _logger.LogInformation($"Background Task {_name} terminating");      
    }

    protected async Task<bool> ScheduleJob(DateTime nextOccurance, CancellationToken stoppingToken)
    {
            TimeSpan delay = nextOccurance - DateTime.UtcNow;
            if (delay.TotalSeconds < 1)
                return true;

            using var timer = new PeriodicTimer(delay);

            if (await timer.WaitForNextTickAsync(stoppingToken))
            {
                return await DoWork(stoppingToken);
            }
            return false;
    }

    protected abstract Task<bool> DoWork(CancellationToken stoppingToken);
}
