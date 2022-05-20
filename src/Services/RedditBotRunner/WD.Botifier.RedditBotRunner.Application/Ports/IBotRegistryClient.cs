using System.Collections.Generic;
using WD.Botifier.RedditBotRunner.Domain;
using WD.Botifier.RedditBotRunner.Domain.Bots;
using WD.Botifier.RedditBotRunner.Domain.Triggers;

namespace WD.Botifier.RedditBotRunner.Application.Ports;

public interface IBotRegistryClient
{
    IEnumerable<Bot> FetchAllBots();
}