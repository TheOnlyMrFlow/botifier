using WD.Botifier.SeedWork;

namespace WD.Botifier.SharedKernel.Webhooks;

public class WebhookSecret : StringValueBase
{
    public WebhookSecret(string value) : base(value)
    {
    }
    
    public static WebhookSecret NewWebhookSecret() 
        => new(StringExtensions.RandomString(64, StringExtensions.AlphaNumericLowercaseCharacterSet));
}