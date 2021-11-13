using ECommerce.DataAccess.Concrete.EntityFramework.Mapping;
using ECommerce.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.Contexts
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {

        }
        public ECommerceContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = "Server=BURAK\\SQLEXPRESS;Database=ECommerceDb;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
