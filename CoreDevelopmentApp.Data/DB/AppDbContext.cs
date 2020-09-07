using CoreDevelopmentApp.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoreDevelopmentApp.Data.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Создаём базу если её нет, при запуске
            Database.EnsureCreated();
        }
        // Модели для таблиц базы
        public DbSet<RequestModel> Requests { get; set; }
        public DbSet<ApplicationListModel> ApplicationLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DevelopmentAppDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        // Заполняем начальными данными базу
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestModel>()
                .ToTable("Requests")
                .HasKey(x => x.Id);
            modelBuilder.Entity<RequestModel>()
                .HasData(
                new RequestModel[]
                {
                    new RequestModel { Id = 1, ListItemId = 2 , Name = "Доработать шапку приложения", DeadLine = new DateTime(2020, 01, 23), Description = "В шапке приложения найден баг: 225 страниц описания следуют...", Email = "innokentij@looser.com" },
                    new RequestModel { Id = 2, ListItemId = 1 , Name = "Доработать что-то", DeadLine = new DateTime(2020, 12, 02), Description = "Я не знаю, чего хочу, но: 11225 страниц объяснений следуют...", Email = "petrovich@kotik.com" },
                    new RequestModel { Id = 3, ListItemId = 4 , Name = "Это должно быть сделано ещё вчера!", DeadLine = new DateTime(2020, 08, 30), Description = "Итак, мне не нравится и срочно переделать: 1000 000 страниц описания следуют...", Email = "innokentij@looser.com" },

                    new RequestModel { Id = 4, ListItemId = 3 , Name = "Доработать шапку приложения", DeadLine = new DateTime(2020, 02, 9), Description = "В шапке приложения найден баг: 225 страниц описания следуют...", Email = "innokentij@looser.com" },
                    new RequestModel { Id = 5, ListItemId = 1 , Name = "Доработать что-то", DeadLine = new DateTime(2020, 11, 02), Description = "Я не знаю, чего хочу, но: 11225 страниц объяснений следуют...", Email = "petrovich@kotik.com" },
                    new RequestModel { Id = 6, ListItemId = 2 , Name = "Это должно быть сделано ещё вчера!", DeadLine = new DateTime(2020, 08, 30), Description = "Итак, мне не нравится и срочно переделать: 1000 000 страниц описания следуют...", Email = "innokentij@looser.com" },

                    new RequestModel { Id = 7, ListItemId = 1 , Name = "Доработать шапку приложения", DeadLine = new DateTime(2020, 03, 03), Description = "В шапке приложения найден баг: 225 страниц описания следуют...", Email = "innokentij@looser.com" },
                    new RequestModel { Id = 8, ListItemId = 2 , Name = "Доработать что-то", DeadLine = new DateTime(2020, 04, 02), Description = "Я не знаю, чего хочу, но: 11225 страниц объяснений следуют...", Email = "petrovich@kotik.com" },
                    new RequestModel { Id = 9, ListItemId = 4 , Name = "Это должно быть сделано ещё вчера!", DeadLine = new DateTime(2020, 05, 21), Description = "Итак, мне не нравится и срочно переделать: 1000 000 страниц описания следуют...", Email = "innokentij@looser.com" },

                    new RequestModel { Id = 10, ListItemId = 4 , Name = "Доработать шапку приложения", DeadLine = new DateTime(2020, 10, 18), Description = "В шапке приложения найден баг: 225 страниц описания следуют...", Email = "innokentij@looser.com" },
                    new RequestModel { Id = 11, ListItemId = 3 , Name = "Доработать что-то", DeadLine = new DateTime(2020, 06, 17), Description = "Я не знаю, чего хочу, но: 11225 страниц объяснений следуют...", Email = "petrovich@kotik.com" },
                    new RequestModel { Id = 12, ListItemId = 2 , Name = "Это должно быть сделано ещё вчера!", DeadLine = new DateTime(2020, 07, 22), Description = "Итак, мне не нравится и срочно переделать: 1000 000 страниц описания следуют...", Email = "innokentij@looser.com" }

                });

            modelBuilder.Entity<ApplicationListModel>()
                .ToTable("ApplicationLists")
                .HasKey(x => x.Id);
            modelBuilder.Entity<ApplicationListModel>().HasData(
                new ApplicationListModel[]
                {
                    new ApplicationListModel { Id = 1, Name = "Компьютерные приложения" },
                    new ApplicationListModel { Id = 2, Name = "Android приложения" },
                    new ApplicationListModel { Id = 3, Name = "iOS приложения" },
                    new ApplicationListModel { Id = 4, Name = "Web приложения" }
                });
        }
    }
}
