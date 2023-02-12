﻿using System;
using Microsoft.EntityFrameworkCore;
using Ecom_API.DTO.Models;

namespace Ecom_API.DBHelpers
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<Information> Informations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>();
            modelBuilder.Entity<Information>();
        }
    }
}