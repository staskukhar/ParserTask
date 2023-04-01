using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace TasteWork
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(){ }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { }

        public virtual DbSet<Vacancy> Vacancy {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Stas;Database=TestDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vacancy>();
        }
    }        
}