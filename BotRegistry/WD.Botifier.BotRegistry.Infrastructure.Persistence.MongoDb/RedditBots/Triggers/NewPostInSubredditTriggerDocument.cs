using System.Collections.Generic;
using System.Linq;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.NewPostInSubreddit;
using WD.Botifier.SharedKernel.Reddit;

namespace WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.RedditBots.Triggers;

public class NewPostInSubredditTriggerDocument : RedditTriggerDocument<NewPostInSubredditTrigger>
{
    public NewPostInSubredditTriggerDocument(NewPostInSubredditTrigger trigger) : base(trigger)
    {
        SubredditNames = trigger.SubredditNames.Select(sr => sr.WithoutRSlash).ToList();
    }
    
    public ICollection<string> SubredditNames { get; set; }

    public override NewPostInSubredditTrigger ToRedditTrigger() 
        => new(SubredditNames.Select(sr => new SubredditName(sr)));
}