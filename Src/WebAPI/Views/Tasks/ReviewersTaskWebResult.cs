using TaskStatus = Tasks.Objects.TaskStatus;

namespace Tasks.Views.Tasks;

public class ReviewersTaskWebResult
{
    public ulong Id { get; set; }
    public string Path { get; set; }
    public TaskStatus Status { get; set; }
    public string Rules { get; set; }
    public ICollection<string> Reviewers { get; set; }
}