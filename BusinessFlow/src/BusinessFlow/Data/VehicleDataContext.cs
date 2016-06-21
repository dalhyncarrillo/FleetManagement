﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessFlow.Models;

namespace BusinessFlow.Data
{
    public class VehicleDataContext : DbContext
    {
        // Controller will use
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Vehicle> Parts { get; set; }
        public VehicleDataContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);           
            var connectionString = @"Data Source=(localdb)\v11.0;Initial Catalog=BusinessFlow;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ForSqlServerUseIdentityColumns();
            
        }
    }
}
