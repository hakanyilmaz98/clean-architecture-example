using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Todos.Queries.GetAllTodos;
public record GetAllTodosQuery() : IRequest<IResult>;
