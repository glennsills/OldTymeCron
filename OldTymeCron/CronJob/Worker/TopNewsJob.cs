using System.Net.Http.Json;
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
        if (topStory.Id > 0)
        {
            await RecordTopStory(topStory);
            return true;
        }
        return false;
    }

    private async Task RecordTopStory(Story topStory)
    {
        var topNewsClient = new TopNewsHttpClient(_configuration.TopNewsBaseUrl, new HttpClient());
        await topNewsClient.AddAsync(null, topStory.Title,
        topStory.Text, DateTimeOffset.FromUnixTimeMilliseconds(topStory.Time));
    }

    private async Task<Story> GetTopStory()
    {
        HttpClient hackerNewsClient = new HttpClient();
        hackerNewsClient.BaseAddress = new Uri(_configuration.HackerNewsBaseUrl);
        long id = await GetTopStoryId(hackerNewsClient);
        if (id > 0)
        {
            return await GetTopStory(id, hackerNewsClient);
        }
        return Story.Default();
    }

    private async Task<Story> GetTopStory(long id, HttpClient hackerNewsClient)
    {
        var story = await hackerNewsClient.GetFromJsonAsync<Story>($"item/{id}.json");
        if (story != null)
        {
            return story;
        }
        return Story.Default();
    }

    private async Task<long> GetTopStoryId(HttpClient hackerNewsClient)
    {
        var storyList = await hackerNewsClient.GetFromJsonAsync<TopStoryList>(_configuration.HackerNewsTopStoryPath);
        return storyList?.ItemIds[0]??-1;
    }
}

