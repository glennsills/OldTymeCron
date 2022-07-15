using System.Runtime.Serialization;

namespace OldTymeCron.CronJob.Config;

/// <summary>
/// Illustrates add a new property to a configuration 
/// for TopNewsJobConfig
/// </summary>
public class TopNewsJobConfig : BaseWorkerConfig
{
    public string HackerNewsBaseUrl {get;set;} = string.Empty;
    public string? HackerNewsTopStoryPath { get; set; }
    public string HackerNewsItemPath {get;set;}  = string.Empty;
    public string TopNewsBaseUrl { get; set; } = string.Empty;
}
