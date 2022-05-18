﻿using System;
using System.Threading.Tasks;
using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.SharedKernel.Webhooks;

namespace WD.Botifier.BotRegistry.Application.RedditBots.AddWebhookToTrigger;

public class AddWebhookToTriggerCommandHandler
{
    private readonly IRedditBotRepository _redditBotRepository;

    public AddWebhookToTriggerCommandHandler(IRedditBotRepository redditBotRepository)
    {
        _redditBotRepository = redditBotRepository;
    }

    public async Task<AddWebhookToTriggerCommandResult> HandleAsync(AddWebhookToTriggerCommand command)
    {
        var bot = await _redditBotRepository.GetAsync(command.UserId, command.BotId);
        if (bot is null)
            return new AddWebhookToTriggerCommandBotNotFoundResult();

        try
        {
            bot.AddWebhookToTrigger(command.TriggerId, Webhook.NewWebhook(command.WebhookName, command.WebhookUrl));
            await _redditBotRepository.UpdateAsync(bot);
            return new AddWebhookToTriggerCommandSuccessResult();
        }
        catch (TriggerAlreadyHasAWebhookWithThisNameException e)
        {
            return new AddWebhookToTriggerWebhookNameAlreadyExistsResult();
        }
        catch (TriggerDoesNotExistException e)
        {
            return new AddWebhookToTriggerTriggerNotFoundResult();
        }
    }
}