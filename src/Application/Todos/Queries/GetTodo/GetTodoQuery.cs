using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Todos.Queries.GetTodo;
public sealed record GetTodoQuery(Guid Id) : IRequest<IResult>;
