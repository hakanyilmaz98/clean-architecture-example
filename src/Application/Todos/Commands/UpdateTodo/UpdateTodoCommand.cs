using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Todos.Commands.UpdateTodo;
public sealed record UpdateTodoCommand(Guid Id, string Name, bool IsComplete) : IRequest<IResult>;

