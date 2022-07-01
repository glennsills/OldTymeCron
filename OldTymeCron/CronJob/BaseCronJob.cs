
using OldTymeCron.CronJob.Config;
using Microsoft.Extensions.Options;
using Cronos;

namespace OldTymeCron.CronJob;

public abstract class BaseCronJob : BackgroundService
{
    protected readonly ILogger<BaseCronJob> _logger;
    protected readonly string _schedule;
    protected readonly string _name;

    public BaseCronJob(string name, ILogger<BaseCronJob> logger, string schedule)
        {
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentNullException.ThrowIfNull(schedule);

            _logger = logger;
            _schedule = schedule;
            _name = name;
        }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation($"Background Task {_name} initializing");

        CronExpression expression = CronExpression.Parse(_schedule, CronFormat.Standard);

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
            {
                Thread.Sleep(1000);
                delay = nextOccurance - DateTime.UtcNow;
            }
            _logger.LogInformation($"delay for {_name} is {delay.TotalSeconds}");
            using var timer = new PeriodicTimer(delay);

            if (await timer.WaitForNextTickAsync(stoppingToken))
            {
                return await DoWork(stoppingToken);
            }
            return false;
    }

    protected abstract Task<bool> DoWork(CancellationToken stoppingToken);
}
