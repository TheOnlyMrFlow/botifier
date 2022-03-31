using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Triggers;

public abstract class RedditTriggerDocument<TTrigger> where TTrigger : IRedditTrigger
{
    public RedditTriggerDocument(TTrigger trigger)
    {
        
    }
    
    public abstract TTrigger ToRedditTrigger();
}