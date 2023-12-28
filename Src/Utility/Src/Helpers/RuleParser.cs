using System.Dynamic;
using Kasp1_Review.Src.Objects;

namespace Kasp1_Review.Src.Helpers
{
    public static class RuleParser
    {
        // TODO: make generic parser for all types
        public static List<Rule> FromDynamic(ExpandoObject rawRules)
        {
            var rules = new List<Rule>();
            foreach (var rawItem in rawRules)
            {
                var newRule = new Rule();
                newRule.Name = rawItem.Key;
                if (rawItem.Value is Dictionary<object, object> dict)
                {
                    foreach (var kvp in dict)
                    {
                        if (kvp.Key as string == "reviewers")
                        {
                            newRule.Reviewers = (kvp.Value as List<object>).Select(x => x.ToString()).ToList();
                            continue;
                        }
                        if (kvp.Key as string == "included_paths")
                        {
                            newRule.Paths = (kvp.Value as List<object>).Select(x => x.ToString()).ToList();
                            continue;
                        }
                    }
                    rules.Add(newRule);
                }
                continue;
            }

            return rules;
        }
    }
}
