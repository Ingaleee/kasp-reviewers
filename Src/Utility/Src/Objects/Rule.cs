namespace Kasp1_Review.Src.Objects
{
    public class Rule
    {
        public string Name { get; set; }
        public ICollection<string> Reviewers { get; set; } = new List<string>();
        public ICollection<string> Paths { get; set; } = new List<string>();
    }
}
