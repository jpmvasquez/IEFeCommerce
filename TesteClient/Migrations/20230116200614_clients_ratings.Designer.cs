﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteClient.Data;

#nullable disable

namespace TesteClient.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230116200614_clients_ratings")]
    partial class clients_ratings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6",
                            ConcurrencyStamp = "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6",
                            Name = "SuperAdmin",
                            NormalizedName = "SUPERADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                            RoleId = "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TesteClient.Models.Adresse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Complement")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Num")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Road")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("TesteClient.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Civility")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Civility = 0,
                            ConcurrencyStamp = "db5ca169-7658-46fa-bc44-8f37ac5bcdbe",
                            Email = "Admin@test.com",
                            EmailConfirmed = true,
                            FirstName = "MONTIZA",
                            LastName = "Tira",
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN@TEST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEHYsGF9dMl8YWRz8GpqV0vByRDybyqWXcRHYVokzg9lAAWwRFHTQoSfJOovu+FkmfA==",
                            PhoneNumber = "0666673314",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "311b37bf-ff6a-43f2-8bf8-10a6e94acaec",
                            TwoFactorEnabled = false,
                            UserName = "Admin@test.com"
                        });
                });

            modelBuilder.Entity("TesteClient.Models.ApplicationUserAdresse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdAdresse")
                        .HasColumnType("int");

                    b.Property<string>("IdApplicationUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IdAdresse");

                    b.HasIndex("IdApplicationUser");

                    b.ToTable("ApplicationUserAdresse");
                });

            modelBuilder.Entity("TesteClient.Models.ClientsRating.ProductRating", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<DateTime>("publishedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("productId");

                    b.ToTable("ProductRating");
                });

            modelBuilder.Entity("TesteClient.Models.Commands.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("addressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("reference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("totalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("addressId");

                    b.HasIndex("userId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("TesteClient.Models.Commands.OrderDetails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("orderId")
                        .HasColumnType("int");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("qty")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("orderId");

                    b.HasIndex("productId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("TesteClient.Models.Products.Brand", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Brand");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "Sony"
                        },
                        new
                        {
                            id = 2,
                            name = "Kodak"
                        },
                        new
                        {
                            id = 3,
                            name = "Panasonic"
                        },
                        new
                        {
                            id = 4,
                            name = "Nikon"
                        },
                        new
                        {
                            id = 5,
                            name = "Olympus"
                        },
                        new
                        {
                            id = 6,
                            name = "Fujifilm"
                        },
                        new
                        {
                            id = 7,
                            name = "Canon"
                        });
                });

            modelBuilder.Entity("TesteClient.Models.Products.Image", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Image");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "DC-FZ82 EF-K.webp"
                        },
                        new
                        {
                            id = 2,
                            name = "DC-FZ82 EF-K.webp"
                        });
                });

            modelBuilder.Entity("TesteClient.Models.Products.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("imageId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("productBrandId")
                        .HasColumnType("int");

                    b.Property<int>("productDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("productTechnoId")
                        .HasColumnType("int");

                    b.Property<int>("productTypeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("imageId");

                    b.HasIndex("productBrandId");

                    b.HasIndex("productDetailsId");

                    b.HasIndex("productTechnoId");

                    b.HasIndex("productTypeId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            id = 1,
                            imageId = 1,
                            name = "D80",
                            price = "1200,99",
                            productBrandId = 1,
                            productDetailsId = 1,
                            productTechnoId = 1,
                            productTypeId = 2
                        },
                        new
                        {
                            id = 2,
                            imageId = 2,
                            name = "Canon D80",
                            price = "1400,00",
                            productBrandId = 2,
                            productDetailsId = 2,
                            productTechnoId = 3,
                            productTypeId = 3
                        });
                });

            modelBuilder.Entity("TesteClient.Models.Products.ProductDetails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("isoMax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("resolution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("stabilisator")
                        .HasColumnType("bit");

                    b.Property<string>("video")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("zoomOptic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ProductDetails");

                    b.HasData(
                        new
                        {
                            id = 1,
                            isoMax = "1",
                            resolution = "D80",
                            stabilisator = true,
                            video = "1",
                            zoomOptic = "1"
                        },
                        new
                        {
                            id = 2,
                            isoMax = "1",
                            resolution = "D80",
                            stabilisator = false,
                            video = "1",
                            zoomOptic = "1"
                        });
                });

            modelBuilder.Entity("TesteClient.Models.Products.ProductType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ProductType");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "Reflex"
                        },
                        new
                        {
                            id = 2,
                            name = "Hybride"
                        },
                        new
                        {
                            id = 3,
                            name = "Bridge"
                        },
                        new
                        {
                            id = 4,
                            name = "Compact"
                        });
                });

            modelBuilder.Entity("TesteClient.Models.Products.Techno", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Techno");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "Numérique"
                        },
                        new
                        {
                            id = 2,
                            name = "Argentique"
                        },
                        new
                        {
                            id = 3,
                            name = "Instantanée"
                        },
                        new
                        {
                            id = 4,
                            name = "Jetable"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TesteClient.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TesteClient.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TesteClient.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TesteClient.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TesteClient.Models.ApplicationUserAdresse", b =>
                {
                    b.HasOne("TesteClient.Models.Adresse", "Adresse")
                        .WithMany("ApplicationUserAdresses")
                        .HasForeignKey("IdAdresse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TesteClient.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUserAdresses")
                        .HasForeignKey("IdApplicationUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adresse");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("TesteClient.Models.ClientsRating.ProductRating", b =>
                {
                    b.HasOne("TesteClient.Models.Products.Product", "product")
                        .WithMany("productRatings")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("TesteClient.Models.Commands.Order", b =>
                {
                    b.HasOne("TesteClient.Models.Adresse", "address")
                        .WithMany()
                        .HasForeignKey("addressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TesteClient.Models.ApplicationUser", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("address");

                    b.Navigation("user");
                });

            modelBuilder.Entity("TesteClient.Models.Commands.OrderDetails", b =>
                {
                    b.HasOne("TesteClient.Models.Commands.Order", "order")
                        .WithMany("orderItems")
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TesteClient.Models.Products.Product", "product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("TesteClient.Models.Products.Product", b =>
                {
                    b.HasOne("TesteClient.Models.Products.Image", "image")
                        .WithMany()
                        .HasForeignKey("imageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TesteClient.Models.Products.Brand", "productBrand")
                        .WithMany()
                        .HasForeignKey("productBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TesteClient.Models.Products.ProductDetails", "productDetails")
                        .WithMany()
                        .HasForeignKey("productDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TesteClient.Models.Products.Techno", "productTechno")
                        .WithMany()
                        .HasForeignKey("productTechnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TesteClient.Models.Products.ProductType", "productType")
                        .WithMany()
                        .HasForeignKey("productTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("image");

                    b.Navigation("productBrand");

                    b.Navigation("productDetails");

                    b.Navigation("productTechno");

                    b.Navigation("productType");
                });

            modelBuilder.Entity("TesteClient.Models.Adresse", b =>
                {
                    b.Navigation("ApplicationUserAdresses");
                });

            modelBuilder.Entity("TesteClient.Models.ApplicationUser", b =>
                {
                    b.Navigation("ApplicationUserAdresses");
                });

            modelBuilder.Entity("TesteClient.Models.Commands.Order", b =>
                {
                    b.Navigation("orderItems");
                });

            modelBuilder.Entity("TesteClient.Models.Products.Product", b =>
                {
                    b.Navigation("productRatings");
                });
#pragma warning restore 612, 618
        }
    }
}
