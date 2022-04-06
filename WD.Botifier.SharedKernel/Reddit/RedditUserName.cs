using System.Linq;

namespace WD.Botifier.SharedKernel.Reddit;

public class RedditUserName
{
    public string WithoutUSlash { get; }
    
    public string WithUSlash => $"u/{WithoutUSlash}";
    
    public RedditUserName(string name)
    {
        WithoutUSlash = name.Split("/").Last().ToLowerInvariant();
    }

    public override string ToString() => WithUSlash;
}