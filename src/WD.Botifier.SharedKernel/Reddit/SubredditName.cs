using System.Linq;
using WD.Botifier.SeedWork;

namespace WD.Botifier.SharedKernel.Reddit;

public class SubredditName : ValueObject
{
    public string WithoutRSlash { get; }
    
    public string WithRSlash => $"r/{WithoutRSlash}";
    
    public SubredditName(string name)
    {
        WithoutRSlash = name.Split("/").Last().ToLowerInvariant();
    }

    public override string ToString() => WithRSlash;
}