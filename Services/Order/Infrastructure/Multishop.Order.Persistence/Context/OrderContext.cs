using Microsoft.EntityFrameworkCore;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1440;initial Catalog=MultiShopOrderDb;User=sa;Password=123456aA*");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
