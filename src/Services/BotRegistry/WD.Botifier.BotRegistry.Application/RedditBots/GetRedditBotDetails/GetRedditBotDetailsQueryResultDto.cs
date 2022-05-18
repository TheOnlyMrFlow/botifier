using System;
using System.Collections.Generic;
using System.Linq;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.BotUserNameMentionInComment;
using WD.Botifier.BotRegistry.Domain.RedditBots.Triggers.NewPostInSubreddit;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.BotRegistry.Application.RedditBots.GetRedditBotDetails;

public class GetRedditBotDetailsQueryResultDto
{
    public GetRedditBotDetailsQueryResultDto(RedditBot redditBot)
    {
        Id = redditBot.Id.Value.ToString();
        OwnerId = redditBot.OwnerId.Value.ToString();
        Name = redditBot.Name.Value;
        Triggers = new TriggerCollectionDto(redditBot.Triggers);
        CreatedAt = redditBot.CreatedAt;
    }
    
    public string Id { get; }
    public string OwnerId { get; }
    public string Name { get; }
    public TriggerCollectionDto Triggers { get; }
    public DateTime CreatedAt { get; }
    
    public class TriggerCollectionDto
    {
        public TriggerCollectionDto(RedditBotTriggerReadonlyCollection triggerCollection)
        {
            BotUserNameMentionInCommentTriggers = triggerCollection.BotUserNameMentionInCommentTriggers.Select(t => new BotUserNameMentionInCommentTriggerDto(t));
            NewPostInSubredditTriggers = triggerCollection.NewPostInSubredditTriggers.Select(t => new NewPostInSubredditTriggerDto(t));
        }
        
        public IEnumerable<BotUserNameMentionInCommentTriggerDto> BotUserNameMentionInCommentTriggers { get; }
        public IEnumerable<NewPostInSubredditTriggerDto> NewPostInSubredditTriggers { get; }

        public class BotUserNameMentionInCommentTriggerDto
        {
            public BotUserNameMentionInCommentTriggerDto(BotUserNameMentionInCommentTrigger trigger)
            {
                Id = trigger.Id.Value.ToString(); 
                Name = trigger.Name.Value;
                Webhooks = trigger.Webhooks.Select(wh => new WebhookDto(wh));
            }
            
            public string Id { get; }
            public string Name { get; }
            public IEnumerable<WebhookDto> Webhooks { get; }
        }
        
        public class NewPostInSubredditTriggerDto
        {
            public NewPostInSubredditTriggerDto(NewPostInSubredditTrigger trigger)
            {
                Id = trigger.Id.Value.ToString(); 
                Name = trigger.Name.Value;
                Webhooks = trigger.Webhooks.Select(wh => new WebhookDto(wh));
                Settings = new SettingsDto(trigger.Settings);
            }
            
            public string Id { get; }
            public string Name { get; }
            public IEnumerable<WebhookDto> Webhooks { get; }
            public SettingsDto Settings { get; }

            public class SettingsDto
            {
                public SettingsDto(NewPostInSubredditTriggerSettings settings)
                {
                    Subreddits = settings.Subreddits.Select(sr => sr.WithRSlash);
                }
                
                public IEnumerable<string> Subreddits { get; }
            }
        }

        public class WebhookDto
        {
            public WebhookDto(Webhook webhook)
            {
                Id = webhook.Id.ToString();
                Name = webhook.Name.Value;
                Url = webhook.Url.ToString();
            }
            
            public string Id { get; }
            public string Name { get; }
            public string Url { get; }
        }
    }
}