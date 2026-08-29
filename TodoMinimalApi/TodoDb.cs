namespace TodoMinimalApi
{
    using Microsoft.EntityFrameworkCore;
    public class TodoDb : DbContext
    {
        // Constructor, receiving options like database, what type, etc
        public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }

        // DbSet is EF Cores database table representation
        // Which will keep track of data with model Todo
        public DbSet<Todo> Todos => Set<Todo>();
    }
}
