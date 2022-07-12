﻿using System.Runtime.Serialization;

namespace OldTymeCron.CronJob.Config;

/// <summary>
/// Illustrates add a new property to a configuration 
/// for TopNewsJobConfig
/// </summary>
public class TopNewsJobConfig : BaseWorkerConfig
{
    public string HackerNewsBaseUri {get;set;} = string.Empty;
    public string TopNewsPath {get;set;} = string.Empty;
    public string TopNewsItemPath {get;set;}  = string.Empty;
    public string TopNewsBaseUri { get; set; } = string.Empty;
}
