namespace OldTymeCron.CronJob.Config;

/// <summary>
/// If a worker only needs the basic scheduling and
/// reporting properties, it still needs to inherit
/// a new class so that it can be bound from the 
/// appsettings[env].json file.
/// </summary>
public class Worker2Config : BaseWorkerConfig
{
}

