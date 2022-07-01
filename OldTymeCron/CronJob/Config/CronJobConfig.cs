﻿namespace OldTymeCron.CronJob.Config;

public class CronJobConfig
{
    public string Name { get; set; } = string.Empty;
    public string Schedule { get; set; } = string.Empty;
    public Uri[] NotificationRecipients { get; set; } = new Uri[0];
}

