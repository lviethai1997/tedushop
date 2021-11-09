namespace TeduShop.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TeduShop.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TeduShop.Data.TeduShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TeduShop.Data.TeduShopDbContext context)
        {
            CreateProductCategorySample(context);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TeduShopDbContext()));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TeduShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "haile",
            //    Email = "haile@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDate = DateTime.Now,
            //    FullName = "TEDU Shop"
            //};

            //manager.Create(user, "123456$");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("haile@gmail.com");
            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategorySample(TeduShop.Data.TeduShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() { Name = "haile",ParentID=1,HomeFlag=true,CreatedDate=DateTime.Now, Status = true },
                new ProductCategory() { Name = "haile122",ParentID=2,HomeFlag=true,CreatedDate=DateTime.Now, Status = true },
                new ProductCategory() { Name = "haile233",ParentID=3,HomeFlag=true,CreatedDate=DateTime.Now, Status = true },
                new ProductCategory() { Name = "haile344",ParentID=4,HomeFlag=true,CreatedDate=DateTime.Now, Status = true }
            };

                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }
    }
}