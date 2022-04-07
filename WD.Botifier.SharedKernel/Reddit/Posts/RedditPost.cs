using System;

namespace WD.Botifier.SharedKernel.Reddit.Posts;

public class RedditPost
{
    public RedditPost(string rawJson, RedditPostId id, RedditPostTitle title, RedditPostContent content, SubredditName subreddit, DateTime postedAt)
    {
        RawJson = rawJson;
        Id = id;
        Title = title;
        Content = content;
        Subreddit = subreddit;
        PostedAt = postedAt;
    }
    
    public string RawJson { get; }
    
    public RedditPostId Id { get; }
    
    public RedditPostTitle Title { get; }
    
    public RedditPostContent Content { get; }
    
    public SubredditName Subreddit { get; }
    
    public DateTime PostedAt { get; }
}