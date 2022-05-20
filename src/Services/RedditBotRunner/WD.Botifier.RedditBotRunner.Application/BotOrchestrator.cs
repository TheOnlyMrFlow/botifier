using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using WD.Botifier.RedditBotRunner.Application.Ports;
using WD.Botifier.RedditBotRunner.Domain;
using WD.Botifier.RedditBotRunner.Domain.Bots;
using WD.Botifier.SharedKernel.Reddit.Comments;

namespace WD.Botifier.RedditBotRunner.Application;

public class BotOrchestrator : BackgroundService
{
    private readonly IAuthlessRedditApi _sharedRedditApiClient;

    private readonly IDictionary<Guid, BotRunner> _botRunners = new Dictionary<Guid, BotRunner>(); //key is bot id
    private readonly IAuthfulRedditApiFactory _authfulRedditApiFactory;
    private readonly WebhookCaller _webhookCaller;
    private readonly IBotRegistryClient _botRegistryClient;
    
    public BotOrchestrator(IAuthlessRedditApiFactory authlessRedditApiFactory, IAuthfulRedditApiFactory authfulRedditApiFactory, WebhookCaller webhookCaller, IBotRegistryClient botRegistryClient)
    {
        _sharedRedditApiClient = authlessRedditApiFactory.Create();
        _authfulRedditApiFactory = authfulRedditApiFactory;
        _webhookCaller = webhookCaller;
        _botRegistryClient = botRegistryClient;
    }

    public void AddBot(Bot bot)
    {
        var botRunner = new BotRunner(bot, _sharedRedditApiClient, _authfulRedditApiFactory, _webhookCaller);
        _botRunners.Add(bot.BotId, botRunner);
        botRunner.Run();
    }
    
    public void RemoveBot(Guid botId)
    {
        _botRunners[botId].Dispose();
        _botRunners.Remove(botId);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        foreach (var bot in _botRegistryClient.FetchAllBots())
        {
            AddBot(bot);
        }

        return Task.CompletedTask;
    }
    
     public override async Task StopAsync(CancellationToken cancellationToken)
     {
         foreach (var botId in _botRunners.Keys)
             RemoveBot(botId);
         
         _sharedRedditApiClient.Dispose();
         
         await base.StopAsync(cancellationToken);
     }
}