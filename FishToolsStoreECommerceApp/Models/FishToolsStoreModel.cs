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
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
