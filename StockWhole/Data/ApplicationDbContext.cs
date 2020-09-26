using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockWhole.Models;

namespace StockWhole.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<StockWhole.Models.Shopkeeper> Shopkeeper { get; set; }
        public DbSet<StockWhole.Models.Stock> Stock { get; set; }
        public DbSet<StockWhole.Models.NeededStock> NeededStock { get; set; }
        public DbSet<StockWhole.Models.AvailableProduct> AvailableProduct { get; set; }
        
    }
}
