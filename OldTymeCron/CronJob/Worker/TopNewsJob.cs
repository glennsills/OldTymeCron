using Microsoft.Extensions.Options;
using OldTymeCron.CronJob.Config;

namespace OldTymeCron.CronJob.Worker;

public class TopNewsJob : BaseCronWorker
{
    private readonly TopNewsJobConfig _configuration;

    public TopNewsJob(
        ILogger<BaseCronWorker> logger,
        IOptions<TopNewsJobConfig> configuration
    ) :
        base(nameof(TopNewsJob), logger, configuration.Value.Schedule)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        _configuration = configuration.Value;
    }

    protected override async Task<bool> DoWork(CancellationToken stoppingToken)
    {
        Story topStory = await GetTopStory();
        if (topStory != null)
        {
            return await RecordTopStory(topStory);
        }
        return false;
    }

    private Task<bool> RecordTopStory(Story topStory)
    {  
        HttpClient topNewsClient = new HttpClient();
        topNewsClient.BaseAddress = new Uri(_configuration.TopNewsBaseUri);
        throw new NotImplementedException();
    }

    private Task<Story> GetTopStory()
    {
        HttpClient hackerNewsClient = new HttpClient();
        hackerNewsClient.BaseAddress = new Uri(_configuration.HackerNewsBaseUri);
        throw new NotImplementedException();
    }
}

