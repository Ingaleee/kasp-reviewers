namespace Client.API;

public class ReviewersTaskWebResult
{
    public ulong Id { get; set; }
    public string Path { get; set; }
    public ReviewersTaskStatus Status { get; set; }
    public string Rules { get; set; }
    public ICollection<string> Reviewers { get; set; }
}