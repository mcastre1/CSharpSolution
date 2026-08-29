using Microsoft.EntityFrameworkCore;
using TodoMinimalApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddOpenApi();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/todoitems", async (TodoDb db) => await db.Todos.ToListAsync());

app.MapGet("/todoitems/complete", async (TodoDb db) => await db.Todos.Where(t => t.isComplete).ToListAsync());

app.MapGet("/todoitems/{id}", async (int id, TodoDb db) => await db.Todos.FindAsync(id) is Todo todo ? Results.Ok(todo) : Results.NotFound());