using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class DBContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DBContext(DbContextOptions<DBContext> options)
              : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("EMPLOYEE");
                entity.Property(e => e.Address)
                     .HasMaxLength(255);
                entity.Property(e => e.Email)
                    .HasMaxLength(255);
                entity.Property(e => e.Name)
                    .HasMaxLength(255);
                entity.Property(e => e.Phone)
                    .HasMaxLength(100);
                    
            });
        }
    }
}
