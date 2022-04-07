using WD.Botifier.SharedKernel.Reddit;
using WD.Botifier.SharedKernel.Reddit.Posts;

namespace WD.Botifier.RedditBotRunner.Infra.RedditApIClient;

public static class RedditSharpExtensions
{
    public static RedditPost ToDomainRedditPost(this RedditSharpPost post)
    {
        return new RedditPost(post.RawJson.ToString(), new RedditPostId(post.Id), new RedditPostTitle(post.Title), new RedditPostContent(post.SelfText), new SubredditName(post.SubredditName), post.CreatedUTC);
    }
}