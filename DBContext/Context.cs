
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using todo_item.Entities;

namespace todo_item.DBContext
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Todo_item> Todo_items { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            modelBuilder.Entity<User>().HasData(
                new User
                { 
                    Name = "Nicolas",
                    Email = "ngomez@gmail.com",
                    Address = "Rivadavia 111",
                    Id_user = 1
                },

                new User
                { 
                    Name = "Juan",
                    Email = "juanperez@gmail.com",
                    Address = "Colon 212",
                    Id_user = 2
                });

            modelBuilder.Entity<Todo_item>().HasData(
                new Todo_item
                {
                    Id_item = 1,
                    Title = "Completar tarea Laboratorio",
                    Description = "La tarea consta de realizar el backend para una todo list. Se debe entregar el 17/4"

                });


            // // Relación entre user y todo_item (uno a muchos)
             modelBuilder.Entity<User>()
            .HasMany(c => c.Todo_items)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId);



            base.OnModelCreating(modelBuilder);


        }
            
          

    }
}
