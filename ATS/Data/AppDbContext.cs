using ATS.Models;
using Microsoft.EntityFrameworkCore;

namespace ATS.Data
{
    //Это класс контекст для связи с БД (строка подключенгия в файле appsettings.json)
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }
        //тут коротко говоря устанавливаются какие будут таблицы
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Debts> Debts { get; set; }
    }
}
