using System.Dynamic;
using Kasp1_Review.Abstractions;
using Kasp1_Review.Src.Helpers;
using Kasp1_Review.Src.Objects;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Kasp1_Review.Readers
{
    public class YamlRulesReader : IRulesReader
    {
        // TODO: can be used configurations
        public ICollection<Rule> FromFile(string file)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var rawRules = deserializer.Deserialize<ExpandoObject>(File.ReadAllText(file));

            return RuleParser.FromDynamic(rawRules);

        }
    }
}
