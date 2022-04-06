using System;

namespace WD.Botifier.SharedKernel.Reddit.Posts;

public class RedditPost
{
    public static RedditPost FromRawJson(string rawJson)
    {
        return new RedditPost();
    }
    
    public string RawJson { get; }
    
    public RedditPostId Id { get; }
    
    public RedditPostTitle Title { get; }
    
    public RedditPostContent Content { get; }
    
    public SubredditName Subreddit { get; }
    
    public DateTime PostedAt { get; }
}