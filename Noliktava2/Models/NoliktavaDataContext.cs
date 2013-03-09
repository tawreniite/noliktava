using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Noliktava2.Models
{
    public class NoliktavaDataContext : DbContext
    {
        public NoliktavaDataContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<PositionModel> Positions { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<VendorModel> Vendors { get; set; }
        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<PurchaseModel> Purchases { get; set; }
        public DbSet<SalesModel> Sales { get; set; }
        public DbSet<PurchaseLineModel> PurchaseLines { get; set; }
        public DbSet<SalesLineModel> SalesLines { get; set; }



        
    }
}