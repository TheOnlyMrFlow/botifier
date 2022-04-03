using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.NewPostInSubreddit;
using WD.Botifier.BotRegistry.Domain.RedditBots.Webhooks;
using WD.Botifier.SharedKernel.Reddit;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Triggers;

[BsonDiscriminator(TriggerType)]
public class NewPostInSubredditTriggerDocument : RedditBotTriggerDocumentBase<NewPostInSubredditTriggerSettingsDocument>
{
    public const string TriggerType = "NewPostInSubreddit";
    
    public NewPostInSubredditTriggerDocument(NewPostInSubredditTrigger trigger)
    {
        Settings = new NewPostInSubredditTriggerSettingsDocument(trigger.Settings);
    }

    public NewPostInSubredditTrigger ToTrigger() 
        => new (new RedditTriggerId(Id), Settings.ToSettings(), new List<Webhook>());

    public override string Type => TriggerType;
}

public class NewPostInSubredditTriggerSettingsDocument : IRedditBotTriggerSettingsDocument
{
    public NewPostInSubredditTriggerSettingsDocument(NewPostInSubredditTriggerSettings triggerSettings)
    {
        Subreddits = triggerSettings.Subreddits.Select(sr => sr.WithoutRSlash).ToList();
    }
    
    public ICollection<string> Subreddits { get; set; }

    public NewPostInSubredditTriggerSettings ToSettings()
        => new(Subreddits.Select(sr => new SubredditName(sr)));
}