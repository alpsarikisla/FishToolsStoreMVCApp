using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FishToolsStoreECommerceApp.Models
{
    public partial class FishToolsStoreModel : DbContext
    {
        public FishToolsStoreModel()
            : base("name=FishToolsStoreModel")//Bu alandaki name Web.config dosyas�ndaki ConnectionStrings Elementinin i�indeki ba�lant� yolundan veri al�r
        {
        }
        //Model'de (DbContext) yer almayan S�n�flar�n tablosu olu�maz
        //DbSet Olu�turulacak tablonun t�r�d�r.

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
            //OrderDetails tablosunda Order_ID ve Product_ID s�tunlar�n�n birle�tirilmesiyle composite key olu�turuluyor.
            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.Order_ID, od.Product_ID });

            // Order_ID'nin Order tablosuna ba�l� oldu�unu belirtiriz
            modelBuilder.Entity<OrderDetail>()
                .HasRequired(od => od.Order)         // Her OrderDetail, bir Order'a ait olmal�
                .WithMany(o => o.OrderDetails)       // Bir Order, bir�ok OrderDetail bar�nd�rabilir
                .HasForeignKey(od => od.Order_ID);   // Order_ID, Order tablosuna foreign key

            modelBuilder.Entity<OrderDetail>()
                .HasRequired(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.Product_ID);
        }
    }
}
