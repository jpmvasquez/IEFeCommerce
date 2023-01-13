using Aspose.Cells;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using TesteClient.Data;
using TesteClient.Models;
using TesteClient.Models.Products;

namespace TesteClient.Data
{
public class AppDbInitializer
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        //using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //{
        //    var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

        //    context.Database.EnsureCreated();


        modelBuilder.Entity<Brand>().HasData(new List<Brand>()
        {

                    new Brand()
                        {
                            id = 1,
                            name = "Sony"
                        },
                        new Brand()
                        {
                            id = 2,
                            name = "Kodak"
                        },
                        new Brand()
                        {
                            id = 3,
                            name = "Panasonic"
                        },
                        new Brand()
                        {
                            id = 4,
                            name = "Nikon"
                        },
                        new Brand()
                        {
                            id = 5,
                            name = "Olympus"
                        },
                        new Brand()
                        {
                            id = 6,
                            name = "Fujifilm"
                        },
                        new Brand()
                        {
                            id = 7,
                            name = "Canon"
                        }
                });
        //context.SaveChanges();
        //}

        modelBuilder.Entity<Techno>().HasData(new List<Techno>()
        {

                    new Techno()
                        {
                            id = 1,
                            name = "Numérique"
                        },
                        new Techno()
                        {
                            id = 2,
                            name = "Argentique"
                        },
                        new Techno()
                        {
                            id = 3,
                            name = "Instantanée"
                        },
                        new Techno()
                        {
                            id = 4,
                            name = "Jetable"
                        }
                });
        //    context.SaveChanges();
        //}

        modelBuilder.Entity<ProductType>().HasData(new List<ProductType>()
                {

                    new ProductType()
                        {
                            id = 1,
                            name = "Reflex"
                        },
                        new ProductType()
                        {
                            id = 2,
                            name = "Hybride"
                        },
                        new ProductType()
                        {
                            id = 3,
                            name = "Bridge"
                        },
                        new ProductType()
                        {
                            id = 4,
                            name = "Compact"
                        }
                });
        //context.SaveChanges();
        //}

        modelBuilder.Entity<Image>().HasData(new List<Image>()
                {

                    new Image()
                        {
                            id = 1,
                            name = "DC-FZ82 EF-K.webp"
                        },
                        new Image()
                        {
                            id = 2,
                            name = "DC-FZ82 EF-K.webp"
                        }
                });
        //context.SaveChanges();
        //}

        modelBuilder.Entity<ProductDetails>().HasData(new List<ProductDetails>()
                {

                    new ProductDetails()
                    {
                        id = 1,
                        resolution = "D80",
                        zoomOptic = "1",
                        video= "1",
                        stabilisator = true,
                        isoMax="1"

                    },

                    new ProductDetails()
                    {
                        id = 2,
                        resolution = "D80",
                        zoomOptic = "1",
                        video="1",
                        stabilisator = false,
                        isoMax="1"
                    }
                });
        //context.SaveChanges();
        //}

        modelBuilder.Entity<Product>().HasData(new List<Product>()
                {

                    new Product()
                    {
                        id = 1,
                        name = "D80",
                        productTechnoId =1,
                        productBrandId=1,
                        price = "1200,99",
                        productDetailsId=1,
                        imageId = 1,
                        productTypeId = 2
                    },

                    new Product()
                    {
                        id = 2,
                        name = "Canon D80",
                        productTechnoId = 3,
                        productBrandId=2,
                        price= "1400,00",
                        productDetailsId=2,
                        imageId = 2,
                        productTypeId = 3
                    }
                });
        //context.SaveChanges();
        //}
    }
    public static async Task SeedUser(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {

            //Roles
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            //Admin User with Address
            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string adminUserEmail = "jepim84@yahoo.fr";

            var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
            if (adminUser == null)
            {
                    var newAdminUser = new ApplicationUser()
                    {
                        Civility = ApplicationUser.eCivility.Monsieur,
                    //addressId = 1,
                    FirstName = "Admin",
                    LastName = "User",
                    UserName = "admin-user",
                    Email = adminUserEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(newAdminUser, "Azerty1_");
                await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            }
        }
    }
        //context.SaveChanges();
        //}




        ////-------- Application User

        //Workbook wb = new Workbook("D:\\Ecommerce.xlsx");
        //WorksheetCollection collection = wb.Worksheets;
        ////Application User




        //for (int worksheetIndex = 0; worksheetIndex < collection.Count; worksheetIndex++)
        //{

        //    Worksheet worksheet = collection[worksheetIndex];


        //    int rows = worksheet.Cells.MaxDataRow;
        //    int cols = worksheet.Cells.MaxDataColumn;
        //    //string Ville;


        //    worksheetIndex = 0;

        //    for (int i = 0; i < rows; i++)
        //    {
        //        if (!context.ApplicationUser.Any())
        //        {
        //            context.ApplicationUser.AddRange(new List<ApplicationUser>()
        //            {
        //                new ApplicationUser()
        //                {
        //                    UserName = Convert.ToString(worksheet.Cells[i, 0].Value),
        //                    PasswordHash = Convert.ToString(worksheet.Cells[i, 1].Value),
        //                    Email = Convert.ToString(worksheet.Cells[i, 3].Value),
        //                    EmailConfirmed = true,
        //                    PhoneNumber = Convert.ToString(worksheet.Cells[i, 2].Value),
        //                    PhoneNumberConfirmed = true,
        //                    Civility = (ApplicationUser.eCivility)worksheet.Cells[i, 4].Value,
        //                    LastName = Convert.ToString(worksheet.Cells[i, 5].Value),
        //                    FirstName = Convert.ToString(worksheet.Cells[i, 6].Value),
        //                    BirthDate = Convert.ToDateTime(worksheet.Cells[i, 7].Value),
        //                }
        //                 });
        //            context.SaveChanges();

        //        }

        //    }

        //}


    }

}

