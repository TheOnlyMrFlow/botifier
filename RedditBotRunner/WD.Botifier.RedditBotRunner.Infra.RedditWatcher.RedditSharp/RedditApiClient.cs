using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using RedditSharp;
using RedditSharp.Things;
using WD.Botifier.RedditBotRunner.Application.Ports;
using WD.Botifier.RedditBotRunner.Domain.Intents;

namespace WD.Botifier.RedditBotRunner.Infra.RedditApIClient;

public class RedditApiClient : IRedditWriter
{
    private readonly Reddit _reddit;

    public RedditApiClient(Reddit reddit)
    {
        _reddit = reddit;
    }
    
    public Task<object> ReplyToCommentAsync(ReplyToCommentIntent intent)
    {
        throw new System.NotImplementedException();
    }

    public Task<object> ReplyToPostAsync(ReplyToPostIntent intent)
    {
        throw new System.NotImplementedException();
    }



}


