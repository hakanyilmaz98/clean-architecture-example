using Domain.Entities;

namespace Domain.Abstractions;
public interface ITodoRepository
{
    public Task<IReadOnlyList<Todo>> GetAllAsync();
    public Task<Todo?> GetTodoAsync(Guid id);
    public Task AddAsync(Todo todo);
    public Task<bool> UpdateAsync(Guid id, Todo updatedTodo);
    public Task<bool> DeleteAsync(Guid id);
}
