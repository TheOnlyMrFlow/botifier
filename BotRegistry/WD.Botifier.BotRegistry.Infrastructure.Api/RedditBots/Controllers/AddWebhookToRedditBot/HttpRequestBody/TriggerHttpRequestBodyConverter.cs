using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WD.Botifier.BotRegistry.Infrastructure.Api.RedditBots.Controllers.AddWebhookToRedditBot.HttpRequestBody;

public class Totoconverter : JsonConverter<TriggerHttpRequestBody>
{
    public override TriggerHttpRequestBody? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var trigger = JsonSerializer.Deserialize<TriggerHttpRequestBody>(ref reader, options);
        return trigger?.TriggerType switch {
            TriggerHttpRequestBody.NewPostInSubredditTriggerType => JsonSerializer.Deserialize<NewPostInSubredditTriggerHttpRequestBody>(ref reader, options),
            TriggerHttpRequestBody.BotUsernameMentionInCommentTriggerType => JsonSerializer.Deserialize<BotUsernameMentionInCommentTriggerHttpRequestBody>(ref reader, options),
            _ => throw new NotImplementedException()
        };
    }

    public override void Write(Utf8JsonWriter writer, TriggerHttpRequestBody value, JsonSerializerOptions options)
        => writer.WriteRawValue(JsonSerializer.Serialize(value, options));
}