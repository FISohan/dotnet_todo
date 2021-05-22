using Microsoft.EntityFrameworkCore;
using dotnet_todo.Model;
namespace dotnet_todo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Todo> Todos { get; set; }
    }
}