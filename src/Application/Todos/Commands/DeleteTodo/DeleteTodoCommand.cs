using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Todos.Commands.DeleteTodo;
public sealed record DeleteTodoCommand(Guid id) : IRequest<IResult>;
