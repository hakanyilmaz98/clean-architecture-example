using Domain.Abstractions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Todos.Commands.UpdateTodo;

public sealed class UpdateTodoCommandHandler(ITodoRepository todoRepository) : IRequestHandler<UpdateTodoCommand, IResult>
{
    private readonly ITodoRepository _todoRepository = todoRepository;

    public async Task<IResult> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new Todo(request.Name, request.IsComplete);

        var isUpdated = await _todoRepository.UpdateAsync(request.Id, todo);

        return isUpdated ? TypedResults.NoContent() : TypedResults.NotFound();
    }
}

