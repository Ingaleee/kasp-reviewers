using TaskStatus = Tasks.Objects.TaskStatus;

namespace Tasks.CQRS.Queries.ReviewerTasks;

public class ReviewersTaskModel
{
    public ulong Id { get; set; }
    public string Path { get; set; }
    public TaskStatus Status { get; set; }
    public string Rules { get; set; }
    public ICollection<string> Reviewers { get; set; }
}