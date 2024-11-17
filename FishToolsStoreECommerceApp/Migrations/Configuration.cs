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
            #region Brands

            context.Brands.AddOrUpdate(b => b.ID, new Brand() { ID = 1, Name = "Nike" });

            #endregion

            #region Managers

            //context.Managers.AddOrUpdate(b => b.ID, new Manager() { ID = 3, Name = "Developer", Surname = "Developer", Mail="devdev@dev.com", Password="1234567", UserName="Developer", CreationTime= DateTime.Now,LastLoginTime=DateTime.Now });

            #endregion
        }
    }
}
