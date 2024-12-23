using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Todo.Core.Models;

namespace Todo.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {}

        public DbSet<Tarefa> Tarefas {get;set;} = null!;
        public DbSet<User> Users {get;set;} = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}