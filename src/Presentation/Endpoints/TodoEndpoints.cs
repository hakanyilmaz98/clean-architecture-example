using Application.Todos.Commands.CreateTodo;
using Application.Todos.Commands.DeleteTodo;
using Application.Todos.Commands.UpdateTodo;
using Application.Todos.Queries.GetAllTodos;
using Application.Todos.Queries.GetTodo;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Presentation.Dtos.Todos;

namespace Presentation.Endpoints;
public static class TodoEndpoints
{
    public static IEndpointRouteBuilder MapTodoEndpoints(this IEndpointRouteBuilder builder)
    {
        var todoItems = builder.MapGroup("/todoitems");

        todoItems.MapGet("/", GetAll);
        todoItems.MapGet("/{id}", GetTodo);
        todoItems.MapPost("/", CreateTodo);
        todoItems.MapPut("/{id}", UpdateTodo);
        todoItems.MapDelete("/{id}", DeleteTodo);

        return builder;
    }

    private static async Task<IResult> GetAll(ISender sender)
    {
        return await sender.Send(new GetAllTodosQuery());
    }

    private static async Task<IResult> GetTodo(Guid id, ISender sender)
    {
        return await sender.Send(new GetTodoQuery(id));
    }

    private static async Task<IResult> CreateTodo(TodoDto todo, ISender sender)
    {
        var command = new CreateTodoCommand(todo.Name, todo.IsComplete);

        return await sender.Send(command);
    }

    private static async Task<IResult> DeleteTodo(Guid id, ISender sender)
    {
        var command = new DeleteTodoCommand(id);

        return await sender.Send(command);
    }

    private static async Task<IResult> UpdateTodo(Guid id, TodoDto todo, ISender sender)
    {
        var command = new UpdateTodoCommand(id, todo.Name, todo.IsComplete);

        return await sender.Send(command);
    }
}
