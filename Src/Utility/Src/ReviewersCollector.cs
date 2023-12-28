using Kasp1_Review.Src.Objects;
using System.Text.RegularExpressions;

namespace Kasp1_Review.Src
{
    public class DefaultReviewersCollector
    {
        // TODO: divide matching logic
        public ICollection<string> Find(ICollection<Rule> rules, string paths)
        {
            var reviewers = new List<string>();

            foreach (var rule in rules)
            {
                foreach (var rulePath in rule.Paths)
                {
                    var mask = new Regex(rulePath.Replace(".", "[.]")
                        .Replace("*", ".*")
                        .Replace("?", "."));
                    if (mask.IsMatch(paths))
                    {
                        reviewers.AddRange(rule.Reviewers);
                    }
                }
            }

            return reviewers.Distinct().ToList();
        }
    }
}
