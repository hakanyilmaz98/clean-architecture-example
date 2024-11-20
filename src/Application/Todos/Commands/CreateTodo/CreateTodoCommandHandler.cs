using Domain.Abstractions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Todos.Commands.CreateTodo;

public sealed class CreateTodoCommandHandler(ITodoRepository todoRepository) : IRequestHandler<CreateTodoCommand, IResult>
{
    private readonly ITodoRepository _todoRepository = todoRepository;

    public async Task<IResult> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new Todo(request.Name, request.IsComplete);

        await _todoRepository.AddAsync(todo);

        return TypedResults.Created($"/todoitems/{todo.Id}", todo);
    }
}
