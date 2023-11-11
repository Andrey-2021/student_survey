using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    /// <summary>
    /// Работа с БД
    /// </summary>
    public class UserContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CreateTest> CreateTests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TestExecution> TestExecutions { get; set; }

        public DbSet<Group> Groups { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            //Database.EnsureDeleted(); //удалить БД
            //Database.EnsureCreated(); //Создать новую БД
            //CreateOneTest.CreateTest(this);  //Создаём 1й тест
            //CreateSecondTest.CreateTest(this); //Создаём 2й тест
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";
            

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };

            //создаём администратора
            User adminUser = new User { Id = 1, 
                Name = "Admin", 
                Login="admin",
                Password = "1234", 
                RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
