using Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Todos.Queries.GetAllTodos;

public sealed class GetAllTodosQueryHandler(ITodoRepository todoRepository) : IRequestHandler<GetAllTodosQuery, IResult>
{
    private readonly ITodoRepository _todoRepository = todoRepository;

    public async Task<IResult> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
    {
        var todos = await _todoRepository.GetAllAsync();

        return TypedResults.Ok(todos);
    }
}
