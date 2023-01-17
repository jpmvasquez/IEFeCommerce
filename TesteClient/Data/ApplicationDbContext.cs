using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TesteClient.Models;
using TesteClient.Models.ClientsRating;
using TesteClient.Models.Commands;
using TesteClient.Models.Products;

namespace TesteClient.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string ADMIN_ID = "02174cf0–9412–4cfe - afbf - 59f706d72cf6";
            string ROLE_ID = "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6";

            //seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            //create user
            var ApplicationUser = new ApplicationUser
            {

                Id = ADMIN_ID,
                Email = "Admin@test.com",
                EmailConfirmed = true,
                FirstName = "MONTIZA",
                LastName = "Tira",
                UserName = "Admin@test.com",
                NormalizedUserName = "ADMIN@TEST.COM",
                PhoneNumber = "0666673314",
                Civility = TesteClient.Models.ApplicationUser.eCivility.Madame,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                BirthDate = new DateTime(05 / 08 / 1971)

            };

            //set user password
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            ApplicationUser.PasswordHash = ph.HashPassword(ApplicationUser, "Admin@2022");

            //seed user
            builder.Entity<ApplicationUser>().HasData(ApplicationUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            AppDbInitializer.Seed(builder);
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<ApplicationUserAdresse> ApplicationUserAdresse { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Techno> Techno { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<ProductRating> ProductRating { get; set; }
    }
}