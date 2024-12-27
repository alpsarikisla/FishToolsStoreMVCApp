namespace FishToolsStoreECommerceApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FishToolsStoreECommerceApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FishToolsStoreModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FishToolsStoreModel context)
        {
            #region Managers

            //context.Managers.AddOrUpdate(x => x.ID, new Manager() { ID = 1, Name = "Developer", Surname = "Developer", Mail = "d@d.com", Password = "12345678", UserName = "Developer", CreationTime = DateTime.Now, LastLoginTime = DateTime.Now });

            #endregion

            #region Members

            //context.Members.AddOrUpdate(x => x.ID, new Member() { ID = 1, Name = "Member", Surname = "Member", Mail = "u@u.com", Password = "12345678", UserName = "Member", CreationTime = DateTime.Now, LastLoginTime = DateTime.Now });

            #endregion

            #region Categories

            //context.Categories.AddOrUpdate(x => x.ID, new Category() { ID = 1, Name = "Category1" });
            //context.Categories.AddOrUpdate(x => x.ID, new Category() { ID = 2, Name = "Category2" });
            //context.Categories.AddOrUpdate(x => x.ID, new Category() { ID = 3, Name = "Category3" });

            #endregion

            #region Brands

            //context.Brands.AddOrUpdate(x => x.ID, new Brand() { ID = 1, Name = "Brand1" });
            //context.Brands.AddOrUpdate(x => x.ID, new Brand() { ID = 2, Name = "Brand2" });
            //context.Brands.AddOrUpdate(x => x.ID, new Brand() { ID = 3, Name = "Brand3" });

            #endregion

            #region Shippers

            //context.Shippers.AddOrUpdate(x => x.ID, new Shipper() { ID = 1, Name = "Shipper1" });
            //context.Shippers.AddOrUpdate(x => x.ID, new Shipper() { ID = 2, Name = "Shipper2" });
            //context.Shippers.AddOrUpdate(x => x.ID, new Shipper() { ID = 3, Name = "Shipper3" });

            #endregion

            #region Products

            //context.Products.AddOrUpdate(x => x.ID, new Product() { ID = 1, Category_ID = 1, Brand_ID = 1, Manager_ID = 1, Barcode = "1111111111111", Name = "Product1", Price = 100, ListPrice = 200, Stock = 10, ReorderLevel = 5, CreationTime = DateTime.Now });
            //context.Products.AddOrUpdate(x => x.ID, new Product() { ID = 2, Category_ID = 2, Brand_ID = 2, Manager_ID = 1, Barcode = "2222222222222", Name = "Product2", Price = 100, ListPrice = 200, Stock = 10, ReorderLevel = 5, CreationTime = DateTime.Now });
            //context.Products.AddOrUpdate(x => x.ID, new Product() { ID = 3, Category_ID = 3, Brand_ID = 3, Manager_ID = 1, Barcode = "3333333333333", Name = "Product3", Price = 100, ListPrice = 200, Stock = 10, ReorderLevel = 5, CreationTime = DateTime.Now });

            #endregion
        }
    }
}
