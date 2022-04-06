using System;

namespace WD.Botifier.SharedKernel.Reddit.Comments;

public class RedditComment
{
    public static RedditComment FromRawJson(string rawJson)
    {
        return new RedditComment();
    }
    
    public RedditCommentId Id { get; }
    
    public string RawJson { get; set; }
    
    public RedditUserName Author { get; set; }
    
    public RedditCommentContent Content { get; set; }
    
    public DateTime PostedAt { get; }
}