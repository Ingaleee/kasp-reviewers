using Kasp1_Review.Src.Objects;

namespace Kasp1_Review.Abstractions;

public interface IRulesReader
{
    public ICollection<Rule> FromFile(string file);
}
