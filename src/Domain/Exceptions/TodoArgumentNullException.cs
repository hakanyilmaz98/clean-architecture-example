namespace Domain.Exceptions;

[Serializable]
public sealed class TodoArgumentNullException(string? message) : Exception(message)
{
}