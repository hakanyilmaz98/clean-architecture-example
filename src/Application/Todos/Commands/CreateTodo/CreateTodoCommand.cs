using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Todos.Commands.CreateTodo;

public sealed record CreateTodoCommand(string Name, bool IsComplete) : IRequest<IResult>;
