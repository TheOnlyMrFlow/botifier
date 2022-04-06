namespace WD.Botifier.RedditBotRunner.Domain.Triggers;

public abstract class TriggerBase
{
    public Guid Id { get; }
    
    public Guid RedditBotId { get; set; }
    
    public IEnumerable<Webhook> Webhooks { get; set; }
}