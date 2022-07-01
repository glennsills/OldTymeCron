namespace OldTymeCron.CronJob.Config;

/// <summary>
/// Illustrates add a new property to a configuration 
/// for Worker 1
/// </summary>
public class Worker1Config : BaseWorkerConfig
{
    public Uri[] NotificationRecipients { get; set; } = new Uri[0];
}

