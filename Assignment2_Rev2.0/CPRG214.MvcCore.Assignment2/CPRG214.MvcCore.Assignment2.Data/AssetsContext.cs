using CPRG214.MvcCore.Assignment2.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPRG214.MvcCore.Assignment2.Data
{
    public class AssetsContext: DbContext
    {
        public AssetsContext() : base () { }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=M-10M3-MJ05R7M7\SQLEXPRESS;
             Database=AssetsDatabase;
             Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Asset>().HasData(
            new Asset { Id = 1, TagNumber = "abc123", AssetTypeID = 100, Manufacturer = "Dell", Model = "SX-10", Description = "The most powerful computer you have ever owned", SerialNumber = "100123963" },
            new Asset { Id = 2, TagNumber = "def456", AssetTypeID = 200, Manufacturer = "LG", Model = "LG-X3", Description = "The best monitor for developer", SerialNumber = "200123963" },
            new Asset { Id = 3, TagNumber = "ghi789", AssetTypeID = 300, Manufacturer = "Cisco", Model = "Cisco-100", Description = "The most stylish phone for the ladies", SerialNumber = "300123963" }
            );

            modelBuilder.Entity<AssetType>().HasData(
            new AssetType { Id = 100, Name = "Computers by Dell" },
            new AssetType { Id = 200, Name = "Monitor by LG" },
            new AssetType { Id = 300, Name = "Phones by Cisco" }

            );
        }
    }
}
