using System;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Application.RedditBots.AddWebhookToRedditBot;

public class AddWebhookToRedditBotCommand : IAuthenticatedCommand
{
    public UserId UserId { get; }
    public RedditBotId BotId { get; }
    public Uri WebhookUrl { get; }
    
}