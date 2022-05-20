using Reddit.Things;
using WD.Botifier.SharedKernel.Reddit;
using WD.Botifier.SharedKernel.Reddit.Comments;
using WD.Botifier.SharedKernel.Reddit.Posts;
using SubredditName = WD.Botifier.SharedKernel.Reddit.SubredditName;

namespace WD.Botifier.RedditBotRunner.Infra.RedditWatcher.RedditDotNet;

public static class RedditDotnetExtensions
{
    public static RedditPost ToDomainRedditPost(this Post post)
    {
        return new RedditPost(post.Permalink, new RedditPostId(post.Id), new RedditPostTitle(post.Title), new RedditPostContent(post.SelfText), new SubredditName(post.Subreddit), post.CreatedUTC);
    }
    
    public static RedditComment ToDomainRedditComment(this Comment comment)
    {
        return new RedditComment(comment.Permalink, new RedditCommentId(comment.Id), new RedditUserName(comment.Author), new RedditCommentContent(comment.Body), comment.CreatedUTC);
    }
}