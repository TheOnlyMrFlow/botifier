using RestSharp;
using WD.Botifier.RedditBotRunner.Application.Ports;
using WD.Botifier.RedditBotRunner.Domain.Triggers;
using WD.Botifier.SharedKernel.Reddit;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.RedditBotRunner.Infra.BotRegistryClient;

public class BotRegistryClient : IBotRegistryClient
{
    public IEnumerable<TriggerBase> FetchAllTriggers()
    {
        // using var restClient = new RestClient();
        return new[]
        {
            new NewPostInSubredditTrigger( 
                new TriggerId(Guid.NewGuid()), 
                Guid.NewGuid(),
                new []{new Webhook(new WebhookName("Toto"), 
                    new Uri("localhost:80"))},
                new [] {new SubredditName("r/test")})
        };
    }
}