using Microsoft.EntityFrameworkCore;
using TodoMinimalApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddOpenApi();
var app = builder.Build();

// Enables the use of swagger ui and Endpoints Explore only for development purposes.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// With this we group endpoints, and are able to reduce the amount of times we use /todoitems
var todoItems = app.MapGroup("/todoitems");

todoItems.MapGet("/", async (TodoDb db) => await db.Todos.ToListAsync());

todoItems.MapGet("/complete", async (TodoDb db) => await db.Todos.Where(t => t.isComplete).ToListAsync());

todoItems.MapGet("/{id}", async (int id, TodoDb db) => await db.Todos.FindAsync(id) is Todo todo ? Results.Ok(todo) : Results.NotFound());

todoItems.MapPost("/", async (Todo todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});

// Requires all todo attributes to be able to update row.
todoItems.MapPut("/{id}", async (int id, Todo inputTodo, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null)
    {
        return Results.NotFound();
    }

    todo.Name = inputTodo.Name;
    todo.isComplete = inputTodo.isComplete;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

todoItems.MapDelete("/{id}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

todoItems.MapPatch("/{id}", async (int id, TodoPatchDto inputTodo, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is null)
    {
        return Results.NotFound();
    }

    if (inputTodo.Name is not null)
    {
        todo.Name = inputTodo.Name;
    }
    if (inputTodo.isComplete is not null)
    {
        todo.isComplete = inputTodo.isComplete.Value;
    }

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();