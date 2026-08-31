//using Microsoft.EntityFrameworkCore;
//using System.Net.NetworkInformation;
//using TodoMinimalApi;

//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
//builder.Services.AddOpenApi();
//var app = builder.Build();

//// Enables the use of swagger ui and Endpoints Explore only for development purposes.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

//// With this we group endpoints, and are able to reduce the amount of times we use /todoitems
//var todoItems = app.MapGroup("/todoitems");

//todoItems.MapGet("/", GetAllTodos);

//todoItems.MapGet("/complete", GetCompletedTodos);

//todoItems.MapGet("/{id}", GetTodo);

//todoItems.MapPost("/", CreateTodo);

//// Requires all todo attributes to be able to update row.
//todoItems.MapPut("/{id}", UpdateTodo);

//todoItems.MapDelete("/{id}", DeleteTodo);

//todoItems.MapPatch("/{id}", PatchTodo);

//app.Run();

//static async Task<IResult> GetAllTodos(TodoDb db)
//{
//    return TypedResults.Ok(await db.Todos.ToListAsync());
//}

//static async Task<IResult> GetTodo(int id,  TodoDb db)
//{
//    if (await db.Todos.FindAsync(id) is Todo todo)
//    {
//        return TypedResults.Ok(todo);
//    }

//    return TypedResults.NotFound();
//}

//static async Task<IResult> GetCompletedTodos(TodoDb db)
//{
//    return TypedResults.Ok(await db.Todos.Where(t => t.isComplete).ToListAsync());
//}

//static async Task<IResult> CreateTodo(Todo todo, TodoDb db)
//{
//    db.Todos.Add(todo);
//    await db.SaveChangesAsync();

//    return TypedResults.Created($"/todoitems/{todo.Id}", todo);
//}

//static async Task<IResult> UpdateTodo(int id, Todo inputTodo, TodoDb db)
//{
//    var todo = await db.Todos.FindAsync(id);

//    if (todo == null) return TypedResults.NotFound();

//    todo.Name = inputTodo.Name;
//    todo.isComplete = inputTodo.isComplete;

//    await db.SaveChangesAsync();

//    return TypedResults.NoContent();
//}

//static async Task<IResult> PatchTodo(int id, TodoPatchDto inputTodo, TodoDb db)
//{
//    var todo = await db.Todos.FindAsync(id);

//    if (todo is null) return TypedResults.NotFound();

//    if (inputTodo.Name is not null) todo.Name = inputTodo.Name;
//    if (inputTodo.isComplete is not null) todo.isComplete = inputTodo.isComplete.Value;

//    await db.SaveChangesAsync();

//    return TypedResults.NoContent();
//}

//static async Task<IResult> DeleteTodo(int id, TodoDb db)
//{
//    if (await db.Todos.FindAsync(id) is Todo todo)
//    {
//        db.Todos.Remove(todo);
//        await db.SaveChangesAsync();
//        return TypedResults.NoContent();
//    }

//    return TypedResults.NotFound();
//}