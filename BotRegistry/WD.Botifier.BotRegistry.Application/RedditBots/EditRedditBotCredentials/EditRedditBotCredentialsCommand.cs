using WD.Botifier.BotRegistry.Domain.RedditBots;
using WD.Botifier.BotRegistry.Domain.RedditBots.Credentials;
using WD.Botifier.SharedKernel;

namespace WD.Botifier.BotRegistry.Application.RedditBots.EditRedditBotCredentials;

public class EditRedditBotCredentialsCommand : AuthenticatedCommandBase
{
    public EditRedditBotCredentialsCommand(UserId userId, RedditBotId botId, RedditUserName userName, RedditPassword password, RedditClientId clientId, RedditClientSecret clientSecret) : base(userId)
    {
        BotId = botId;
        UserName = userName;
        Password = password;
        ClientId = clientId;
        ClientSecret = clientSecret;
    }

    public RedditBotId BotId { get; }
    public RedditUserName UserName { get; }
    public RedditPassword Password { get; }
    public RedditClientId ClientId { get; }
    public RedditClientSecret ClientSecret { get; }
}