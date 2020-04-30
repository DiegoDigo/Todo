using Microsoft.EntityFrameworkCore;
using Todo.Domain.TodoContext.Entities;
using Todo.Domain.UserContext.Entities;
using Todo.Infra.Maps;

namespace Todo.Infra.Context
{
    public class TodoDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TodoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}