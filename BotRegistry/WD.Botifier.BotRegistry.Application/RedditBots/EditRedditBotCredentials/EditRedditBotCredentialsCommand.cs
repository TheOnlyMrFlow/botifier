using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.SharedKernel;
using WD.Botifier.SharedKernel.Reddit.AppCredentials;

namespace WD.Botifier.BotRegistry.Application.RedditBots.EditRedditBotCredentials;

public class EditRedditBotCredentialsCommand : AuthenticatedCommandBase
{
    public EditRedditBotCredentialsCommand(UserId userId, RedditBotId botId, RedditUserName userName, RedditPassword password, RedditAppClientId appClientId, RedditAppClientSecret appClientSecret) : base(userId)
    {
        BotId = botId;
        UserName = userName;
        Password = password;
        AppClientId = appClientId;
        AppClientSecret = appClientSecret;
    }

    public RedditBotId BotId { get; }
    public RedditUserName UserName { get; }
    public RedditPassword Password { get; }
    public RedditAppClientId AppClientId { get; }
    public RedditAppClientSecret AppClientSecret { get; }
}