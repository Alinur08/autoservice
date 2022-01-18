using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class AutoServiceContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Initial Catalog = AutoService; Integrated Security = true");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<CarSupply> CarSupplies { get; set; }
        public DbSet<CarPhoto> CarPhotos { get; set; }
        public DbSet<SparePartVideo> SparePartVideos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<SparePartPhoto> SparePartPhotos { get; set; }
        public DbSet<TransCare> TransCares { get; set; }
        public DbSet<TransCarePhoto> TransCarePhotos { get; set; }
    }
}
