namespace OldTymeCron.CronJob.Worker;
public partial class HackerNewsStory
{
    public string By { get; set; } = string.Empty;
    public long Descendants { get; set; }
    public long Id { get; set; }
    public long[] Kids { get; set; } = new long[0];
    public long Score { get; set; }
    public long Time { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Text {get;set;} = string.Empty;
    public string Url { get; set; } = string.Empty;

    public static HackerNewsStory Empty()
    {
        return new HackerNewsStory();
    }
}