using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace WorkersApp.Infrastructure.PG
{
    public class PGContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }

        public PGContext(DbContextOptions<PGContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
