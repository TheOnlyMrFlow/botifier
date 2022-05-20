using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WD.Botifier.RedditBotRunner.Application.Ports;
using WD.Botifier.RedditBotRunner.Domain.Bots;
using WD.Botifier.RedditBotRunner.Domain.Bots.Triggers.NewPostInSubredit;
using WD.Botifier.RedditBotRunner.Domain.Bots.Triggers.UserNameMentionInComment;
using WD.Botifier.RedditBotRunner.Domain.Webhooks;

namespace WD.Botifier.RedditBotRunner.Application;

public class BotRunner : IDisposable
{
    private readonly Bot _bot;
    private readonly IAuthlessRedditApi _authlessRedditApi;
    private readonly IAuthfulRedditApi _authfulRedditApi;
    private readonly WebhookCaller _webhookCaller;
    private readonly ICollection<IDisposable> _subscriptions = new List<IDisposable>();

    public BotRunner(Bot bot, IAuthlessRedditApi authlessRedditApi, IAuthfulRedditApiFactory authfulRedditApiFactory, WebhookCaller webhookCaller)
    {
        _bot = bot;
        _webhookCaller = webhookCaller;
        _authlessRedditApi = authlessRedditApi;
        _authfulRedditApi = authfulRedditApiFactory.Create(bot.RefreshToken);
    }
    
    public void Run()
    {
        foreach (var trigger in _bot.NewPostInSubredditTriggers)
        {
            var subscription = _authlessRedditApi.WatchNewPostsInSubreddit(trigger.Subreddits, post => OnTriggerMatchAsync(trigger.Match(post)).GetAwaiter().GetResult());
            _subscriptions.Add(subscription);
        }
        
        foreach (var trigger in _bot.UserNameMentionInCommentTriggers)
        {
            var subscription = _authfulRedditApi.WatchUserNameMentions(post => OnTriggerMatchAsync(trigger.Match(post)).GetAwaiter().GetResult());
            _subscriptions.Add(subscription);
        }
    }
    
    private async Task OnTriggerMatchAsync(NewPostInSubredditTriggerMatch newPostInSubredditTriggerMatch)
    {
        foreach (var webhook in newPostInSubredditTriggerMatch.Trigger.Webhooks)
        {
            var webhookResponse = await _webhookCaller.CallWebhookAsync(webhook, new NewPostInSubredditWebhookPayload(newPostInSubredditTriggerMatch));
            await ProcessWebhookResponseAsync(webhookResponse);
        }
    }
    
    private async Task OnTriggerMatchAsync(UserNameMentionInCommentTriggerMatch userNameMentionInCommentTriggerMatch)
    {
        foreach (var webhook in userNameMentionInCommentTriggerMatch.Trigger.Webhooks)
        {
            var webhookResponse = await _webhookCaller.CallWebhookAsync(webhook, new UserNameMentionInCommentWebhookPayload(userNameMentionInCommentTriggerMatch));
            await ProcessWebhookResponseAsync(webhookResponse);
        }
    }

    private async Task ProcessWebhookResponseAsync(WebhookResponse webhookResponse)
    {
        foreach (var intent in webhookResponse.ReplyToCommentIntents) 
            await _authfulRedditApi.ReplyToCommentAsync(intent);
        
        foreach (var intent in webhookResponse.ReplyToPostIntents) 
            await _authfulRedditApi.ReplyToPostAsync(intent);
    }

    public void Dispose()
    {
        foreach (var subscription in _subscriptions)
            subscription.Dispose();
    }
}