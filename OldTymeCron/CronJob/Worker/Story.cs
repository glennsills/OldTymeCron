namespace OldTymeCron.CronJob.Worker;
public partial class Story
{
    public string By { get; set; } = string.Empty;
    public long Descendants { get; set; }
    public long Id { get; set; }
    public long[] Kids { get; set; } = new long[0];
    public long Score { get; set; }
    public long Time { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public Uri? Url { get; set; }
}