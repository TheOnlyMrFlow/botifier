using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.RedditBotRunner.Domain.Triggers;

public abstract class TriggerBase
{
    protected TriggerBase(TriggerId id, Guid redditBotId, IEnumerable<Webhook> webhooks)
    {
        Id = id;
        RedditBotId = redditBotId;
        Webhooks = webhooks;
    }

    public TriggerId Id { get; }
    
    public Guid RedditBotId { get; set; }
    
    public IEnumerable<Webhook> Webhooks { get; set; }
}