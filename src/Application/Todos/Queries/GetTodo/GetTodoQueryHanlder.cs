using Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Todos.Queries.GetTodo;

public sealed class GetTodoQueryHanlder(ITodoRepository todoRepository) : IRequestHandler<GetTodoQuery, IResult>
{
    private readonly ITodoRepository _todoRepository = todoRepository;

    public async Task<IResult> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.GetTodoAsync(request.Id);

        return todo is not null ? TypedResults.Ok(todo) : TypedResults.NotFound();
    }
}
