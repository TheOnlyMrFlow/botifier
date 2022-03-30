namespace WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.EditRedditBotCredentials;

public class EditRedditBotCredentialsHttpRequestBody
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}