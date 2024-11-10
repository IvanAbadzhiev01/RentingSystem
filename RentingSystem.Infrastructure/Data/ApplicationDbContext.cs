﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentingSystem.Infrastructure.Data.Models;
using System.Reflection.Emit;

namespace RentingSystem.Infrasturcture.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Rent> Rents { get; set; } = null!;
        public DbSet<Review> Rewiews { get; set; } = null!;
        public DbSet<Dealer> Dealers { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>()
             .HasOne(r => r.Category)
             .WithMany(c => c.Cars)
             .HasForeignKey(r => r.CategoryId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Car>()
                .HasOne(r => r.Dealer)
                .WithMany(u => u.Cars)
                .HasForeignKey(r => r.DealerId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }
    }
}
