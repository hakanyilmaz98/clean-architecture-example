using Domain.Exceptions;

namespace Domain.Entities;
public sealed class Todo
{
    public Todo(string name, bool isComplete)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new TodoArgumentNullException("Name cannot be null, empty or white-space");
        }

        Name = name;
        IsComplete = isComplete;
    }

    public Guid Id { get; init; }
    public string Name { get; init; }
    public bool IsComplete { get; init; }
}
