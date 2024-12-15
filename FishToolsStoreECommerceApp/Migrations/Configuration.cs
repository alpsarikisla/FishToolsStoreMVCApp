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

            //context.Managers.AddOrUpdate(m => m.ID, new Manager() { ID = 1, Name = "Developer", Surname = "Developer", Mail = "d@d.com", Password = "12345678", UserName = "Developer", CreationTime = DateTime.Now, LastLoginTime = DateTime.Now });

            #endregion

            #region Brands

            //context.Brands.AddOrUpdate(b => b.ID, new Brand() { ID = 1, Name = "Brand1" });
            //context.Brands.AddOrUpdate(b => b.ID, new Brand() { ID = 2, Name = "Brand2" });
            //context.Brands.AddOrUpdate(b => b.ID, new Brand() { ID = 3, Name = "Brand3" });

            #endregion

            #region Categories

            //context.Categories.AddOrUpdate(c => c.ID, new Category() { ID = 1, Name = "Category1" });
            //context.Categories.AddOrUpdate(c => c.ID, new Category() { ID = 2, Name = "Category2" });
            //context.Categories.AddOrUpdate(c => c.ID, new Category() { ID = 3, Name = "Category3" });

            #endregion

            #region Members

            //context.Members.AddOrUpdate(m => m.ID, new Member() { ID = 1, Name = "Member", Surname = "Member", UserName = "Member", Mail = "u@u.com", Password = "12345678", CreationTime = DateTime.Now, LastLoginTime = DateTime.Now });

            #endregion

        }
    }
}
