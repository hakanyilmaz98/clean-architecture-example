using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public sealed class TodoRepository(AppDbContext context) : ITodoRepository
{
    private readonly AppDbContext _context = context;

    public Task AddAsync(Todo todo)
    {
        _context.Todos.Add(todo);
        return _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var rowsAffected = await _context.Todos
            .Where(t => t.Id == id)
            .ExecuteDeleteAsync();

        return rowsAffected > 0;
    }

    public Task<Todo?> GetTodoAsync(Guid id)
    {
        return _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IReadOnlyList<Todo>> GetAllAsync()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Guid id, Todo updatedTodo)
    {
        var rowsAffected = await _context.Todos
            .Where(t => t.Id == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(t => t.Name, updatedTodo.Name)
                .SetProperty(t => t.IsComplete, updatedTodo.IsComplete));

        return rowsAffected > 0;
    }
}
