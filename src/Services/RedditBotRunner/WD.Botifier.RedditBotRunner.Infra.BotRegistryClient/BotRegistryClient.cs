using RestSharp;
using WD.Botifier.RedditBotRunner.Application.Ports;
using WD.Botifier.RedditBotRunner.Domain.Bots;
using WD.Botifier.RedditBotRunner.Domain.Bots.Triggers.NewPostInSubredit;
using WD.Botifier.RedditBotRunner.Domain.Bots.Triggers.UserNameMentionInComment;
using WD.Botifier.RedditBotRunner.Domain.Triggers;
using WD.Botifier.SharedKernel.Reddit;
using WD.Botifier.SharedKernel.Reddit.AppCredentials;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.RedditBotRunner.Infra.BotRegistryClient;

public class BotRegistryClient : IBotRegistryClient
{
    public IEnumerable<Bot> FetchAllBots()
    {
        var newPostTrigger = new NewPostInSubredditTrigger(
            new TriggerId(Guid.NewGuid()),
            Guid.NewGuid(),
            new[]
            {
                new Webhook(new WebhookId(Guid.NewGuid()), new WebhookName("Toto"), new Uri("http://localhost:80"))
            },
            new [] {new SubredditName("r/test")}
        );
        
        var userNameMentionTrigger = new UserNameMentionInCommentTrigger(
            new TriggerId(Guid.NewGuid()),
            Guid.NewGuid(),
            new[]
            {
                new Webhook(new WebhookId(Guid.NewGuid()), new WebhookName("Toto"), new Uri("http://localhost:80"))
            }
        );

        return new Bot[]
        {
            new Bot(
                Guid.NewGuid(),
                new RedditRefreshToken("830878531732-cz4-E-8sO7XzObIL2e41jEmRNZMluA"),
                Array.Empty<NewPostInSubredditTrigger>(),//new[] {newPostTrigger},
                new[] {userNameMentionTrigger})
        };
    }
}