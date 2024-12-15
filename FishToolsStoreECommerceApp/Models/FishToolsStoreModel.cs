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
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
