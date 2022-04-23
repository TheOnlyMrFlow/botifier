using System;

namespace WD.Botifier.SharedKernel.Reddit.Comments;

public class RedditComment
{
    public RedditComment( string rawJson, RedditCommentId id, RedditUserName author, RedditCommentContent content, DateTime postedAt)
    {
        RawJson = rawJson;
        Id = id;
        Author = author;
        Content = content;
        PostedAt = postedAt;
    }
    
    public string RawJson { get; set; }
    
    public RedditCommentId Id { get; }
    
    public RedditUserName Author { get; set; }
    
    public RedditCommentContent Content { get; set; }
    
    public DateTime PostedAt { get; }
}