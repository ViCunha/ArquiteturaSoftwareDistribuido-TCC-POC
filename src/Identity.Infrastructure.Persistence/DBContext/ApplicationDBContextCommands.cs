﻿using Identity.Domain.Models;
using Identity.Domain.Models.EventSourcing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.DBContext
{
    public class ApplicationDbContextCommands : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<TransactionProcessingControlHistory> TransactionProcessingControlHistory { get; set; }

        public DbSet<EventSourcingHistory> EventSourcingHistory { get; set; }


        public ApplicationDbContextCommands(DbContextOptions<ApplicationDbContextCommands> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContextCommands).Assembly);
        }
    }
}
