using Tasks.Objects;

namespace Tasks.Domain;

// TODO: use EF core memory db
public class MemoryApplicationContext 
{
    public Dictionary<ulong, ReviewerTask> ReviewerTasks { get; init; } = new();
}