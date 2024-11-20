using Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Todos.Commands.DeleteTodo;

public sealed class DeleteTodoCommandHandler(ITodoRepository todoRepository) : IRequestHandler<DeleteTodoCommand, IResult>
{
    private readonly ITodoRepository _todoRepository = todoRepository;

    public async Task<IResult> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var isDeleted = await _todoRepository.DeleteAsync(request.id);

        return isDeleted ? TypedResults.NoContent() : TypedResults.NotFound();
    }
}
