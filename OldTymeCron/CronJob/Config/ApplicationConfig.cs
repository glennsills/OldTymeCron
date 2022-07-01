namespace OldTymeCron.CronJob.Config;

public class ApplicationConfig
{
    public CronJobConfig[] CronJobConfig { get; set; } = new CronJobConfig[0];
    public CronJobConfig GetConfigForName(string name)
    {
       return CronJobConfig.AsQueryable<CronJobConfig>().FirstOrDefault(x => x.Name == name, new CronJobConfig());
    }
}
