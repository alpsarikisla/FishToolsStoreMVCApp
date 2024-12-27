using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FishToolsStoreECommerceApp.Models
{
    public partial class FishToolsStoreModel : DbContext
    {
        public FishToolsStoreModel()
            : base("name=FishToolsStoreModel")//Bu alandaki name Web.config dosyasýndaki ConnectionStrings Elementinin içindeki baðlantý yolundan veri alýr
        {
        }
        //Model'de (DbContext) yer almayan Sýnýflarýn tablosu oluþmaz
        //DbSet Oluþturulacak tablonun türüdür.

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrdersDetails { get; set; }
        public DbSet<Shipper> Shippers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //OrderDetails tablosunda Order_ID ve Product_ID sütunlarýnýn birleþtirilmesiyle composite key oluþturuluyor.
            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.Order_ID, od.Product_ID });

            // Order_ID'nin Order tablosuna baðlý olduðunu belirtiriz
            modelBuilder.Entity<OrderDetail>()
                .HasRequired(od => od.Order)         // Her OrderDetail, bir Order'a ait olmalý
                .WithMany(o => o.OrderDetails)       // Bir Order, birçok OrderDetail barýndýrabilir
                .HasForeignKey(od => od.Order_ID);   // Order_ID, Order tablosuna foreign key

            modelBuilder.Entity<OrderDetail>()
                .HasRequired(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.Product_ID);
        }
    }
}
