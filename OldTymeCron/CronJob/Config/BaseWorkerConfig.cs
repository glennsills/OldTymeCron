namespace OldTymeCron.CronJob.Config;

/// <summary>
/// This class contains properties necessary for scheduling and
/// reporting. Inherit from this class to add specialized 
/// properties need for your worker.
/// </summary>
public class BaseWorkerConfig
{
    public string Name { get; set; } = string.Empty;
    public string Schedule { get; set; } = string.Empty;
}

