namespace WD.Botifier.RedditBotRunner.Domain.Webhooks;

public interface IWebhookPayload
{
    public string TriggerType { get; }
    public DateTime TriggeredOn { get; }
}